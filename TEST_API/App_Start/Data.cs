using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;

namespace TEST_API.App_Start
{
    public class Data
    {
        private static Dictionary<string, object> MainArr;
        private static List<Dictionary<string, object>> ParentArr;
        private static Dictionary<string, object> ChildArr;
        private static bool _Status = false;
        private static string _jsonString = string.Empty;
        //private static dynamic response;
        private static JavaScriptSerializer _jsObj = new JavaScriptSerializer();
        private static DataTable dTable;

        /*********************************
          * Title :: Make DataTable to JSON String
          * Description :: 
          * Parameter :: Table Data
          * Return :: JSON String
          *********************************/
        public static string DatatableToJsonString(DataTable dt)
        {
            try
            {
                MainArr = new Dictionary<string, object>();
                if (dt.Rows.Count > 0)
                {
                    _Status = true;
                    ParentArr = new List<Dictionary<string, object>>();
                    foreach (DataRow row in dt.Rows)
                    {
                        ChildArr = new Dictionary<string, object>();
                        foreach (DataColumn column in dt.Columns)
                        {
                            ChildArr.Add(column.ColumnName, row[column]);
                        }
                        ParentArr.Add(ChildArr);
                    }
                    MainArr.Add("status", _Status);
                    MainArr.Add("response", ParentArr);
                }
                else
                {
                    MainArr.Add("status", _Status);
                    MainArr.Add("response", "No data found.");
                }
            }
            catch (Exception ex)
            {
                MainArr.Add("status", _Status);
                MainArr.Add("response", ex.Message);
            }
            return JsonConvert.SerializeObject(MainArr);
        }
        /*********************************
          * Title :: Make Exception Message to JSON String
          * Description :: 
          * Parameter :: exception string
          * Return :: JSON String
          *********************************/
        public static string ExceptionToJsonString(string exceptionMessage)
        {

            try
            {
                MainArr = new Dictionary<string, object>();

                MainArr.Add("status", _Status);
                MainArr.Add("response", exceptionMessage);
            }
            catch (Exception ex)
            {
                MainArr.Add("status", _Status);
                MainArr.Add("response", ex.Message);
            }
            return JsonConvert.SerializeObject(MainArr);
        }
        /*********************************
          * Title :: Make Exception Object to JSON String
          * Description :: 
          * Parameter :: exception string
          * Return :: JSON String
          *********************************/
        public static string ObjectToJsonString(dynamic arraydata)
        {
            if (arraydata != null)
            {
                return JsonConvert.SerializeObject(arraydata);
            }
            else
            {
                return string.Empty;
            }
        }

        /*********************************
          * Title :: Make Datatable To JsonString_array
          * Description :: 
          * Parameter :: exception string
          * Return :: JSON String
          *********************************/
        public static string DatatableToJsonString_array(DataTable dt)
        {
            try
            {
                MainArr = new Dictionary<string, object>();
                ParentArr = new List<Dictionary<string, object>>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ChildArr = new Dictionary<string, object>();
                        foreach (DataColumn column in dt.Columns)
                        {
                            ChildArr.Add(column.ColumnName, row[column]);
                        }
                        ParentArr.Add(ChildArr);
                    }

                }
                else
                {
                    MainArr.Add("status", _Status);
                    MainArr.Add("response", "No data found.");
                }
            }
            catch (Exception ex)
            {
                MainArr.Add("status", _Status);
                MainArr.Add("response", ex.Message);
            }
            return JsonConvert.SerializeObject(ParentArr);
        }

        /*********************************
          * Title :: Get an empty datatable to json
          * Description :: 
          * Parameter :: custom message
          * Return :: JSON String
          *********************************/
        public static string DatatableEmpty(string msg = "")
        {
            _Status = false;
            MainArr = new Dictionary<string, object>();
            msg = string.IsNullOrEmpty(msg.Trim()) ? "Data not available." : msg;
            MainArr.Add("status", _Status);
            MainArr.Add("response", msg);
            _jsonString = ObjectToJsonString(MainArr);
            return _jsonString;
        }

        /*********************************
          * Title :: Convert JSON to anyone dynamic
          * Description :: 
          * Parameter :: custom message, type
          * Return :: dynamic
          *********************************/
        public static dynamic Deserialize(string content, Type convertType = null)
        {
            if (content != null)
            {
                if (convertType != null)
                {
                    return _jsObj.Deserialize(content, convertType);
                }
                else
                {
                    return _jsObj.Deserialize(content, content.GetType());
                }
            }
            else
            {
                return "Data not available.";
            }
        }

        /*********************************
          * Title :: Convert JSON to DataTable
          * Description :: 
          * Parameter :: json data
          * Return :: dynamic
          *********************************/
        public static DataTable JsonToDatatable(string content)
        {
            dTable = new DataTable();
            MainArr = new Dictionary<string, object>();
            ArrayList mainData;
            MainArr = (Dictionary<string, object>)_jsObj.Deserialize(content, (typeof(Dictionary<string, object>)));
            if (MainArr.ContainsKey("status"))
            {
                var objType = MainArr["response"].GetType();
                if (objType.Name.ToLower() == "string")
                {
                    dTable.Columns.Add("response");
                    dTable.Rows.Add(MainArr["response"]);
                }
                else if (objType.Name.ToLower() == "arraylist")
                {
                    mainData = new ArrayList();
                    mainData = (ArrayList)MainArr["response"];
                    foreach (Dictionary<string, object> data in mainData)
                    {
                        int count = data.Keys.Count;
                        if (count > 0)
                        {
                            List<string> keys = data.Keys.ToList();
                            List<object> values = data.Values.ToList();
                            object[] array = new object[values.Count];
                            if (dTable.Columns.Count == 0)
                            {
                                for (int i = 0; i < keys.Count; i++)
                                {
                                    dTable.Columns.Add(keys[i]);
                                }
                            }

                            for (int i = 0; i < values.Count; i++)
                            {
                                array[i] = values[i];
                            }
                            dTable.Rows.Add(array);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Status key does not contain in json format.");
            }
            return dTable;
        }
    }
}
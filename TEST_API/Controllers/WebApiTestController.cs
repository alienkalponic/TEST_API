using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Configuration;
using TEST_API.Models;
using TEST_API.Helper;
using TEST_API.App_Start;
using System.Collections;
using System.Data.SqlClient;


namespace TEST_API.Controllers
{
    public class WebApiTestController : ApiController
    {
        private dynamic response;
        private Dictionary<string, object> dictionaryData;
        private DataTable _dt;
        private ArrayList row;
        private string jsonstring;
        private UserManagement _UmObj;

        [HttpPost]
        public HttpResponseMessage Addnewuserdata(HttpRequestMessage postdata)
        {
            string postjson = postdata.Content.ReadAsStringAsync().Result.ToString();
            try 
            {
                _dt = new DataTable();
                _UmObj = new UserManagement();
                _dt = _UmObj.addnewUser(postjson);
                if (_dt.Rows.Count > 0)
                {
                    dictionaryData = new Dictionary<string, object>();
                    dictionaryData = Data.Deserialize(_dt.Rows[0]["JSON_VALUE"].ToString(), typeof(Dictionary<string, object>));
                }
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                dictionaryData.Add("status", response);
                dictionaryData.Add("response", ex.Message);
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                jsonstring = Data.ObjectToJsonString(dictionaryData);
            }
            response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            return response;

        }
        [Authorize]
        [HttpGet]
        public HttpResponseMessage Get_All_Data()
        {
            try
            {
                _dt = new DataTable();
                _UmObj = new UserManagement();
                _dt = _UmObj.get_all_data();
                if (_dt.Rows.Count > 0)
                {
                    dictionaryData = new Dictionary<string, object>();
                    dictionaryData = Data.Deserialize(_dt.Rows[0]["JSON_VALUE"].ToString(), typeof(Dictionary<string, object>));
                }
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex) 
            {
                dictionaryData.Add("status", response);
                dictionaryData.Add("response", ex.Message);
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                jsonstring = Data.ObjectToJsonString(dictionaryData);
            }
            response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            return response;
        }
        [Authorize]
        [HttpGet]
        public HttpResponseMessage Get_user_details(string id=null) 
        {
            try
            {
                _dt = new DataTable();
                _UmObj = new UserManagement();
                _dt = _UmObj.get_user_data(id);
                if (_dt.Rows.Count > 0)
                {
                    dictionaryData = new Dictionary<string, object>();
                    dictionaryData = Data.Deserialize(_dt.Rows[0]["JSON_VALUE"].ToString(), typeof(Dictionary<string, object>));
                }
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                dictionaryData.Add("status", response);
                dictionaryData.Add("response", ex.Message);
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                jsonstring = Data.ObjectToJsonString(dictionaryData);
            }
            response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            return response;
            
        }
        [Authorize]
        [HttpPost]
        public HttpResponseMessage Update_user_details(HttpRequestMessage postdata)
        {
            string postjson = postdata.Content.ReadAsStringAsync().Result.ToString();
            try
            {
                _dt = new DataTable();
                _UmObj = new UserManagement();
                _dt = _UmObj.update_user_details(postjson);
                if (_dt.Rows.Count > 0)
                {
                    dictionaryData = new Dictionary<string, object>();
                    dictionaryData = Data.Deserialize(_dt.Rows[0]["JSON_VALUE"].ToString(), typeof(Dictionary<string, object>));
                }
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                dictionaryData.Add("status", response);
                dictionaryData.Add("response", ex.Message);
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                jsonstring = Data.ObjectToJsonString(dictionaryData);
            }
            response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            return response;
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage Add_Employee_Data(HttpRequestMessage postdata)
        {
            string postjson = postdata.Content.ReadAsStringAsync().Result.ToString();
            try
            {
                _dt = new DataTable();
                _UmObj = new UserManagement();
                _dt = _UmObj.addEmploye(postjson);
                if (_dt.Rows.Count > 0)
                {
                    dictionaryData = new Dictionary<string, object>();
                    dictionaryData = Data.Deserialize(_dt.Rows[0]["JSON_VALUE"].ToString(), typeof(Dictionary<string, object>));
                }
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                dictionaryData.Add("status", response);
                dictionaryData.Add("response", ex.Message);
                response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
            finally
            {
                jsonstring = Data.ObjectToJsonString(dictionaryData);
            }
            response.Content = new StringContent(jsonstring, Encoding.UTF8, "application/json");
            return response;
        }
    }
}

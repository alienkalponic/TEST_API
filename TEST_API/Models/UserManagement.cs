using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseManagementClient;
using System.Linq;
using System.Web;


namespace TEST_API.Models
{
    public class UserManagement
    {
        private DataTable _dtObj;
        private static DatabaseManagement _dbObj = new DatabaseManagement("DB");
        private SqlParameter[] _paramObj;
        public DataTable addnewUser(string postjson)
        {
            _dtObj = new DataTable();
            _paramObj = new SqlParameter[]
            {
                new SqlParameter("@OPERATION_ID",1) {SqlDbType = SqlDbType.Int, Direction =ParameterDirection.Input },
                new SqlParameter("@JSON",postjson) { SqlDbType = SqlDbType.NVarChar , Direction =ParameterDirection.Input },
            };
            _dtObj = _dbObj.Select("SP_TEST", _paramObj);
            return _dtObj;
        }
        public DataTable get_all_data()
        {
            _dtObj = new DataTable();
            _paramObj = new SqlParameter[]
                {
                    new SqlParameter("@OPERATION_ID",2){SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Input},
                    new SqlParameter("@JSON","") { SqlDbType = SqlDbType.NVarChar , Direction =ParameterDirection.Input },
                };
            _dtObj = _dbObj.Select("SP_TEST", _paramObj);
            return _dtObj;
        }
        public DataTable get_user_data(string id=null)
        {
            _dtObj = new DataTable();
            _paramObj = new SqlParameter[]
                {
                    new SqlParameter("@OPERATION_ID",3){SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Input},
                    new SqlParameter("@JSON","") { SqlDbType = SqlDbType.NVarChar , Direction =ParameterDirection.Input },
                    new SqlParameter("@ID",id) { SqlDbType = SqlDbType.Int , Direction =ParameterDirection.Input },
                };
            _dtObj = _dbObj.Select("SP_TEST", _paramObj);
            return _dtObj;
        }
        public DataTable update_user_details(string postjson)
        {
            _dtObj = new DataTable();
            _paramObj = new SqlParameter[]
            {
                new SqlParameter("@OPERATION_ID",4){ SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Input},
                new SqlParameter("@JSON",postjson) { SqlDbType = SqlDbType.NVarChar , Direction =ParameterDirection.Input },
            };
            _dtObj = _dbObj.Select("SP_TEST", _paramObj);
            return _dtObj;
            
        }
        public DataTable addEmploye(string postjson)
        {
            _dtObj = new DataTable();
            _paramObj = new SqlParameter[]
                {
                    new SqlParameter("@OPERATION_ID",1){ SqlDbType=SqlDbType.Int,Direction=ParameterDirection.Input},
                    new SqlParameter("@JSON",postjson) { SqlDbType = SqlDbType.NVarChar , Direction =ParameterDirection.Input },
                };
            _dtObj = _dbObj.Select("SP_TEST_NO2", _paramObj);
            return _dtObj;
        }
    }
}
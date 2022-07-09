using geecomAPI.data;
using geecomAPI.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace geecomAPI.dbUtilites.questionnior
{
    public class responseDA
    {
        public static string SaveQuestionniorResponse(farmerQuestionResponse farmerQuestionResponse)
        {
            List<MySqlParameter> lstParam = new List<MySqlParameter>();
            lstParam.Add(new MySqlParameter("@orgID", (object)farmerQuestionResponse.responseHeaderModel.orgID ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@farmerID", (object)farmerQuestionResponse.responseHeaderModel.farmerID ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@questionSetID", (object)farmerQuestionResponse.responseHeaderModel.questionSetID ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@location", (object)farmerQuestionResponse.responseHeaderModel.location ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@addUser", (object)farmerQuestionResponse.responseHeaderModel.addUser ?? DBNull.Value));
            
            MySqlParameter outParam = new MySqlParameter("@outResponseHeaderID", MySqlDbType.Int32);
            outParam.Direction = ParameterDirection.Output;
            lstParam.Add(outParam);

            dbHelper.ExecuteNonQuery(constantProps.dbconn, "USPAddResponse", lstParam.ToArray());

            string id = DBNull.Value == outParam.Value ? null : outParam.Value.ToString();
            if (id != null && Convert.ToInt32(id) > 0)
            {
                return id;
            }
            return "";
        }
    }
}

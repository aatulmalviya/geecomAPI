
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using geecomAPI.data;
using MySql.Data.MySqlClient;

namespace geecomAPI.dbUtilites.questionnior
{
    public class questionniorDA
    {

        public static DataSet GetQuestionnior(int orgID, int questionSetID, string userID)
        {
            DataSet ds = null;
            List<MySql.Data.MySqlClient.MySqlParameter> lstParam = new List<MySql.Data.MySqlClient.MySqlParameter>();
            lstParam.Add(new MySqlParameter("@orgID", (object)orgID ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@questionSetID", (object)questionSetID ?? DBNull.Value));
            lstParam.Add(new MySqlParameter("@userID", (object)userID ?? DBNull.Value));

            // string conStr = Configuration.Instance.AppSettings.FundingShieldConnectionString;

            ds = dbHelper.GetDatasetFromSP(constantProps.dbconn, "USPLoadQuestionnaire", lstParam.ToArray());
            return ds;



        }


    }
}

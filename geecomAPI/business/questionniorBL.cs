
using geecomAPI.businessInterface;
using geecomAPI.dbUtilites.questionnior;
using geecomAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace geecomAPI.business
{
    public class questionniorBL : Iquestionnaire
    {
        public questionniorResponseModel GetQuestionnior(int orgID, int questionSetID, string userID)
        {
            questionniorResponseModel _questionniorResponseModel = null;

            DataSet ds = questionniorDA.GetQuestionnior(orgID, questionSetID, userID);

            DataTable dtquestions = ds.Tables["dtquestions"];
            DataTable dtoption = ds.Tables["dtoption"];
            DataTable dtvalidation = ds.Tables["dtvalidation"];


            List<questionMasterDetailModel> lstquestionMasterDetailModel = null;
            List<questionOptionModel> lstquestionOptionModel = null;
            List<defaultQuestionOptionModel> listdefauttOptions = null;
            List<validationModel> lstvalidationModel = null;




            if (dtquestions != null && dtquestions.Rows.Count > 0)
            {
                foreach (DataRow dr in dtquestions.Rows)
                {
                    DataRow rw = dr;
                    questionMasterDetailModel qmdtm = Activator.CreateInstance<questionMasterDetailModel>();
                    foreach (DataColumn cl in dtquestions.Columns)
                    {
                        PropertyInfo pi = typeof(questionMasterDetailModel).GetProperty(cl.ColumnName);

                        if (pi != null && rw[cl] != DBNull.Value)
                        {
                            var propType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                            pi.SetValue(qmdtm, Convert.ChangeType(rw[cl], propType), new object[0]);
                        }
                    }

                    lstquestionMasterDetailModel.Add(qmdtm);
                }

            }






            _questionniorResponseModel._listquestionMasterDetailModel = lstquestionMasterDetailModel;
            //_questionniorResponseModel._listquestionOption = lstquestionOptionModel;
            //_questionniorResponseModel._listdefauttOptions = listdefauttOptions;
            //_questionniorResponseModel._listvalidationModel = lstvalidationModel;



            return _questionniorResponseModel;



            throw new System.NotImplementedException();
        }
    }
}

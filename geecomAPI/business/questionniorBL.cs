
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
        public formBuilderResponseModel GetQuestionnior(int orgID, int questionSetID, string userID)
        {
            questionniorResponseModel _questionniorResponseModel = null;
            formBuilderResponseModel _formBuilderResponseModel = null;

            DataSet ds = questionniorDA.GetQuestionnior(orgID, questionSetID, userID);
            DataTable dtQuestions = ds.Tables[0];//dtquestions
            DataTable dtOption = ds.Tables[1];//dtoption
            DataTable dtDefaultOption = ds.Tables[2];//dtDefaultOption
            DataTable dtValidation = ds.Tables[3];//dtValidation


            if (dtQuestions != null && dtQuestions.Rows.Count > 0)
            {
                List<questionMasterDetailModel> lstquestionMasterDetailModel = new List<questionMasterDetailModel>();
                List<formBuilderModel> lstformBuilderModel = new List<formBuilderModel>();

                foreach (DataRow row in dtQuestions.Rows)
                {
                    formBuilderModel fbm = new formBuilderModel();

                    fbm.name = Convert.ToString(row["questionMasterKey"]);
                    fbm.label = Convert.ToString(row["questionText"]);
                    fbm.value = "";
                    fbm.type = Convert.ToString(row["dataType"]);



                    questionMasterDetailModel qmdm = new questionMasterDetailModel();

                    qmdm.questionMasterKey = Convert.ToInt32(row["questionMasterKey"]);
                    qmdm.orgID = Convert.ToInt32(row["orgID"]);
                    qmdm.orgName = Convert.ToString(row["orgName"]);
                    qmdm.orgDescription = Convert.ToString(row["orgDescription"]);

                    qmdm.questionSetID = Convert.ToInt32(row["questionSetID"]);
                    qmdm.setName = Convert.ToString(row["setName"]);

                    qmdm.questionID = Convert.ToInt32(row["questionID"]);
                    qmdm.questionText = Convert.ToString(row["questionText"]);
                    qmdm.isReadOnly = Convert.ToBoolean(row["isReadOnly"]);
                    qmdm.isVisible = Convert.ToBoolean(row["isVisible"]);

                    qmdm.dataTypeID = Convert.ToInt32(row["dataTypeID"]);
                    qmdm.dataType = Convert.ToString(row["dataType"]);

                    qmdm.questionOrder = Convert.ToInt32(row["questionOrder"]);

                    qmdm.isActive = Convert.ToBoolean(row["isActive"]);
                    qmdm.addTime = Convert.ToDateTime(row["addTime"]);
                    qmdm.addUser = Convert.ToString(row["addUser"]);
                    //qmdm.updateTime = Convert.ToDateTime(row["updateTime"]);
                    qmdm.updateUser = Convert.ToString(row["updateUser"]);


                    qmdm.questionCategoryID = Convert.ToInt32(row["questionCategoryID"]);
                    qmdm.questionCategoryName = Convert.ToString(row["questionCategoryName"]);
                    qmdm.questionCategoryDesc = Convert.ToString(row["questionCategoryDesc"]);

                    List<questionOptionModel> lstquestionOptionModel = new List<questionOptionModel>();
                    List<fromaBuilderOptionModel> lstfromaBuilderOptionModel = new List<fromaBuilderOptionModel>();

                    var dtOptionresult = dtOption.AsEnumerable().
                        Where(myRow => myRow.Field<int>("questionMasterKey") == qmdm.questionMasterKey);

                    foreach (var item in dtOptionresult)
                    {
                        questionOptionModel qom = new questionOptionModel();
                        qom.optionValueID = item.Field<int>("optionValueID");
                        qom.questionMasterKey = item.Field<int>("questionMasterKey");
                        qom.optionsValue = item.Field<string>("optionsValue");

                        lstquestionOptionModel.Add(qom);


                        fromaBuilderOptionModel fbom = new fromaBuilderOptionModel();
                        fbom.value = item.Field<int>("optionValueID");
                        fbom.displayValue = item.Field<string>("optionsValue");

                        lstfromaBuilderOptionModel.Add(fbom);

                    }


                    List<defaultQuestionOptionModel> listdefauttOptions = new List<defaultQuestionOptionModel>();

                    var dtDefaultOptionresult = dtDefaultOption.AsEnumerable().
                       Where(myRow => myRow.Field<int>("questionMasterKey") == qmdm.questionMasterKey);

                    foreach (var item in dtDefaultOptionresult)
                    {

                        defaultQuestionOptionModel dqom = new defaultQuestionOptionModel();

                        dqom.defaultOptionID = item.Field<int>("defaultOptionID");
                        dqom.questionMasterKey = item.Field<int>("questionMasterKey");
                        dqom.optionGroupID = item.Field<int>("optionGroupID");
                        dqom.dataTypeID = item.Field<int>("dataTypeID");
                        dqom.dataType = item.Field<string>("dataType");
                        dqom.defaultOptionsValue = item.Field<string>("defaultOptionsValue");

                        listdefauttOptions.Add(dqom);

                        fromaBuilderOptionModel fbom = new fromaBuilderOptionModel();
                        fbom.value = item.Field<int>("defaultOptionID");
                        fbom.displayValue = item.Field<string>("defaultOptionsValue");

                        lstfromaBuilderOptionModel.Add(fbom);

                    }



                    var dtValidationResult = dtValidation.AsEnumerable().
                       Where(myRow => myRow.Field<int>("questionMasterKey") == qmdm.questionMasterKey);

                    List<validationModel> listvalidationModel = new List<validationModel>();

                    foreach (var item in dtValidationResult)
                    {
                        validationModel vm = new validationModel();

                        vm.questionValID = item.Field<int>("questionValID");
                        vm.questionMasterKey = item.Field<int>("questionMasterKey");
                        vm.questionID = item.Field<int>("questionID");
                        vm.validationvalue = item.Field<string>("validationvalue");

                        listvalidationModel.Add(vm);
                    }

                    if (lstquestionOptionModel.Count > 0)
                    {
                        qmdm.listquestionOption = lstquestionOptionModel;
                        fbm.options = lstfromaBuilderOptionModel;
                    }

                    if (listdefauttOptions.Count > 0)
                    {
                        qmdm.defauttOptionslist = listdefauttOptions;
                        fbm.options = lstfromaBuilderOptionModel;

                    }

                    if (listvalidationModel.Count > 0)
                    {
                        qmdm.listvalidationModel = listvalidationModel;
                    }

                    lstquestionMasterDetailModel.Add(qmdm);
                    lstformBuilderModel.Add(fbm);
                }

                _questionniorResponseModel = new questionniorResponseModel();
                _questionniorResponseModel._listquestionMasterDetailModel = lstquestionMasterDetailModel;

                _formBuilderResponseModel = new formBuilderResponseModel();
                _formBuilderResponseModel.controls = lstformBuilderModel;


            }
            //return _questionniorResponseModel;
            return _formBuilderResponseModel;

            throw new System.NotImplementedException();
        }
    }
}

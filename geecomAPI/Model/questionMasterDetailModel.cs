using System;
using System.Collections.Generic;

namespace geecomAPI.Model
{
    public class questionMasterDetailModel
    {
        public int questionMasterKey { get; set; }
        public int orgID { get; set; }
        public string orgName { get; set; }
        public string orgDescription { get; set; }

        public int questionSetID { get; set; }
        public string setName { get; set; }

        public int questionID { get; set; }
        public string questionText { get; set; }
        public bool isReadOnly { get; set; }
        public bool isVisible { get; set; }

        public int dataTypeID { get; set; }
        public string dataType { get; set; }

        public int questionOrder { get; set; }

        public bool isActive { get; set; }
        public DateTime addTime { get; set; }
        public string addUser { get; set; }
        public DateTime updateTime { get; set; }
        public string updateUser { get; set; }


        public int questionCategoryID { get; set; }
        public string questionCategoryName { get; set; }
        public string questionCategoryDesc { get; set; }
        
        public List<questionOptionModel> listquestionOption { get; set; }
        public List<defaultQuestionOptionModel> defauttOptionslist { get; set; }
        public List<validationModel> listvalidationModel { get; set; }


    }


    public class organizationModel
    {
        public int orgID { get; set; }
        public string orgName { get; set; }
        public string orgDescription { get; set; }
    }

    public class formBuilderModel
    {
        public string name { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public List<fromaBuilderOptionModel> options { get; set; }
        public List<formBuilderValidationModel> validators { get; set; }



    }


}

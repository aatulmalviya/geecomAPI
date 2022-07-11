using System.Collections.Generic;

namespace geecomAPI.Model
{
    public class questionniorResponseModel
    {
        public List<questionMasterDetailModel> _listquestionMasterDetailModel { get; set; }
        
        //public List<questionOptionModel> _listquestionOption { get; set; }
        //public List<defaultQuestionOptionModel> _listdefauttOptions { get; set; }
        //public List<validationModel> _listvalidationModel { get; set; }

    }


    public class formBuilderResponseModel
    {
        public List<formBuilderModel> controls { get; set; }

        //public List<questionOptionModel> _listquestionOption { get; set; }
        //public List<defaultQuestionOptionModel> _listdefauttOptions { get; set; }
        //public List<validationModel> _listvalidationModel { get; set; }

    }

}

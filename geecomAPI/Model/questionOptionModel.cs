using System.Collections.Generic;

namespace geecomAPI.Model
{
    public class questionOptionModel
    {

        public int optionValueID { get; set; }
        public int questionMasterKey { get; set; }
        public int? defaultOptionDataTypeID { get; set; }
        public string optionsValue { get; set; }
        //public List<defaultQuestionOptionModel> defauttOptionslist { get; set; }
    }

    public class defaultQuestionOptionModel
    {
        public int defaultOptionID { get; set; }
        public int questionMasterKey { get; set; }
        public int optionGroupID { get; set; }
        public int dataTypeID { get; set; }
        public string dataType { get; set; }
        public string defaultOptionsValue { get; set; }

    }


    public class fromaBuilderOptionModel
    {
        public int value { get; set; }
        public string displayValue { get; set; }

    }
}

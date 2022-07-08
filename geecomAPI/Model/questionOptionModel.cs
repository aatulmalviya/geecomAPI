using System.Collections.Generic;

namespace geecomAPI.Model
{
    public class questionOptionModel
    {
        public int questionMasterKey { get; set; }
        public int? defaultOptionID { get; set; }
        public string optionsValue { get; set; }
        public List<defaultQuestionOptionModel> defauttOptionslist { get; set; }
    }

    public class defaultQuestionOptionModel
    {
        public int questionMasterKey { get; set; }
        public int optionSetID { get; set; }
        public int dataTypeID { get; set; }
        public string dataType { get; set; }
        public int defaultOptionsValue { get; set; }

    }

}

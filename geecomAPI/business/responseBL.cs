using geecomAPI.businessInterface;
using geecomAPI.dbUtilites.questionnior;
using geecomAPI.Model;

namespace geecomAPI.business
{
    public class responseBL : Iresponse
    {
        public bool SaveQuestionniorResponse(farmerQuestionResponse farmerQuestionResponse)
        {
            string responseHeadrID = responseDA.SaveQuestionniorResponse(farmerQuestionResponse);
            if (!string.IsNullOrEmpty(responseHeadrID))
            {
                return true;
            }

            return false;
        }
    }
}

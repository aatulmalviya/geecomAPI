using geecomAPI.Model;

namespace geecomAPI.businessInterface
{
    public interface Iquestionnaire
    {
        //public questionniorResponseModel GetQuestionnior(int orgID, int questionSetID, string userID);
        public formBuilderResponseModel GetQuestionnior(int orgID, int questionSetID, string userID);
        
    }
}

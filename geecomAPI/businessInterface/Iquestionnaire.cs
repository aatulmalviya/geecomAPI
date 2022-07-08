using geecomAPI.Model;

namespace geecomAPI.businessInterface
{
    public interface Iquestionnaire
    {
        public questionMasterDetailModel GetQuestionnior(int orgID, int questionSetID, string userID);
    }
}

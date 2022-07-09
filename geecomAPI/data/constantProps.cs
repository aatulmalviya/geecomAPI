namespace geecomAPI.data
{
    public class constantProps
    {
        public static string dbconn;
       
        public const string bulkInsert = @"INSERT INTO `geecomsurvey`.`farmer_response_detail`
                                (`responseHeaderID`,`questionID`,`response`,`isActive`,`addUser`,`addTime`) values ";

    }
}

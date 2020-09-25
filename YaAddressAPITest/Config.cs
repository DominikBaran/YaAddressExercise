namespace YaAddressAPITest.helper
{
    public class Config
    {

        public string getAddressUrl()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["APIUrl"];
        }
    }
}

using System;
using System.IO;
using System.Xml.Serialization;
using YaAddressAPITest.model;

namespace YaAddressAPITest.helper
{
    public class BaselineMethods
    {
        protected string Address1ValidValue = "506 Fourth Avenue Unit 1";
        protected string Address2ValidValue = "Asbury Prk NJ";

        protected string GetContentType(string headerFormat)
        {
            string header;
            switch (headerFormat.ToLower().Trim())
            {
                case "json":
                    header = "application/json";
                    break;
                case "xml":
                    header = "application/xml";
                    break;
                case "text":
                    header = "text/html";
                    break;
                default:
                    throw new Exception(string.Format("Not supported accept header: {0}", headerFormat));
            }
            return header;
        }

        protected Address TranslateResponseToObject(string content, string responseFormat)
        {
            Address returnedAddress;

            switch (responseFormat.ToLower().Trim())
            {
                case "json":
                case "text":
                    returnedAddress = Newtonsoft.Json.JsonConvert.DeserializeObject<Address>(content);
                    break;
                case "xml":
                    var serializer = new XmlSerializer(typeof(Address));

                    using (TextReader reader = new StringReader(content))
                    {
                        returnedAddress = (Address)serializer.Deserialize(reader);
                    }
                    break;
                default:
                    throw new Exception(string.Format("Not supported response format: {0}", responseFormat));
            }
            return returnedAddress;
        }
    }
}
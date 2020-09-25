using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;
using YaAddressAPITest.model;
using YaAddressAPITest.helper;

namespace YaAddressAPITest.steps
{
    [Binding]
    public sealed class GET_YaAddressSteps : BaselineMethods
    {
        private readonly ScenarioContext _scenarioContext;
        private const string apiUrl = "https://www.yaddress.net/api/Address";

        public GET_YaAddressSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("accepted header is set to (.*)")]
        public void GivenTheFirstNumberIs(string headerFormat)
        {
            string header = GetContentType(headerFormat);
            _scenarioContext.Set(header, "AcceptHeader");
            _scenarioContext.Set(headerFormat, "ResponseFormat");
        }

        [Given("parameters of request are valid")]
        public void prepareValidRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", Address1ValidValue));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", Address2ValidValue));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("no address setup")]
        public void prepareEmptyAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", string.Empty));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", string.Empty));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("address data is invalid")]
        public void prepareInvalidAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", "test1"));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", "test2"));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("only 1st line od address is setup")]
        public void prepareOnlyFirstAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", Address1ValidValue));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", string.Empty));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("only 2nd line od address is setup")]
        public void prepareOnlySecondAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", string.Empty));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", Address2ValidValue));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("1st value contains full address")]
        public void prepareFirstValueWithFullAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", Address1ValidValue + Address2ValidValue));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", string.Empty));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [Given("2nd value contains full address")]
        public void prepareSecondValueWithFullAddressRequest()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("AddressLine1", string.Empty));
            parameters.Add(new KeyValuePair<string, string>("AddressLine2", Address1ValidValue + Address2ValidValue));
            _scenarioContext.Set(parameters, "urlParameters");
        }

        [When("the request is send")]
        public void sendValidRequest()
        {
            RestClient client = new RestClient(apiUrl);
            RestRequest request = new RestRequest();

            var parameters = _scenarioContext.Get<List<KeyValuePair<string, string>>>("urlParameters");
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            request.AddHeader("Accept", _scenarioContext.Get<string>("AcceptHeader"));
            request.Method = Method.GET;

            var response = client.Execute(request);
            _scenarioContext.Set(response, "Response");
        }

        [Then("the response is valid")]
        public void checkValidResponse()
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            TestDataHelper.CompareResponseDataForWholeAddress(returnedAddress);
        }

        [Then("the response only for addres2 value is valid")]
        public void checkValidResponseForAddress2()
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            TestDataHelper.CompareResponseDataForAddress2Address(returnedAddress);
        }

        [Then("the error code is '(.*)' and error message is '(.*)'")]
        public void validateErrorMessage(int errorCode, string errorMessage)
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            Assert.AreEqual(errorCode, returnedAddress.ErrorCode, "Problem with error code for the response.");
            Assert.AreEqual(errorMessage, returnedAddress.ErrorMessage, "Problem with error message for the response.");
        }

        [Then("the address is not returned")]
        public void validateAddressForNegativeTestCases()
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            Assert.IsTrue(string.IsNullOrEmpty(returnedAddress.AddressLine1), string.Format("AddresLine1 has value: {0} when expected to be empty.", returnedAddress.AddressLine1));
            Assert.IsTrue(string.IsNullOrEmpty(returnedAddress.AddressLine2), string.Format("AddresLine2 has value: {0} when expected to be empty.", returnedAddress.AddressLine2));
        }

        [Then("only address1 field is returned")]
        public void validateAddressForNegativeTestCasesAddres1()
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            Assert.AreEqual(TestDataHelper.GetAddres1Value(), returnedAddress.AddressLine1, "Problem with Addres1 value.");
            Assert.IsTrue(string.IsNullOrEmpty(returnedAddress.AddressLine2), string.Format("AddresLine2 has value: {0} when expected to be empty.", returnedAddress.AddressLine2));
        }

        [Then("only address2 field is returned")]
        public void validateAddressForNegativeTestCasesAddres2()
        {
            string responseFormat = _scenarioContext.Get<string>("ResponseFormat");
            var response = _scenarioContext.Get<IRestResponse>("Response");
            Address returnedAddress = TranslateResponseToObject(response.Content, responseFormat);
            Assert.IsTrue(string.IsNullOrEmpty(returnedAddress.AddressLine1), string.Format("AddresLine1 has value: {0} when expected to be empty.", returnedAddress.AddressLine1));
            Assert.AreEqual(TestDataHelper.GetAddres2Value(), returnedAddress.AddressLine2, "Problem with Addres2 value.");
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftAssert;
using System.Globalization;
using YaAddressAPITest.model;

namespace YaAddressAPITest.helper
{
    public class TestDataHelper
    {
        private static Address CreateValidTestDataObject()
        {
            Address address = new Address
            {
                ErrorCode = 0,
                ErrorMessage = string.Empty,
                AddressLine1 = "506 4TH AVE APT 1",
                AddressLine2 = "ASBURY PARK, NJ 07712-6086",
                Number = 506,
                PreDir = string.Empty,
                Street = "4TH",
                Suffix = "AVE",
                PostDir = string.Empty,
                Sec = "APT",
                SecNumber = 1,
                City = "ASBURY PARK",
                State = "NJ",
                Zip = "07712",
                Zip4 = "6086",
                County = "MONMOUTH",
                StateFP = 34,
                CountyFP = "025",
                CensusTract = 8070.03,
                CensusBlock = 1015,
                Latitude = 40.223571,
                Longitude = -74.005973,
                GeoPrecision = 5,
                TimeZoneOffset = -5,
                DstObserved = "True"
            };
            return address;
        }

        private static Address CreateValidTestDataObjectForAddress2Only()
        {
            Address address = new Address
            {
                ErrorCode = 0,
                ErrorMessage = string.Empty,
                AddressLine1 = string.Empty,
                AddressLine2 = "Asbury Prk NJ",
                Number = null,
                PreDir = string.Empty,
                Street = string.Empty,
                Suffix = string.Empty,
                PostDir = string.Empty,
                Sec = string.Empty,
                SecNumber = null,
                City = "ASBURY PARK",
                State = "NJ",
                Zip = string.Empty,
                Zip4 = string.Empty,
                County = "MONMOUTH",
                StateFP = 34,
                CountyFP = "025",
                CensusTract = null,
                CensusBlock = null,
                Latitude = 40.234547,
                Longitude = -74.029485,
                GeoPrecision = 2,
                TimeZoneOffset = -5,
                DstObserved = "True"
            };
            return address;
        }

        public static void CompareResponseDataForWholeAddress(Address responsedAddress)
        {
            Address address = CreateValidTestDataObject();
            AssertAll.Succeed(
                () => Assert.AreEqual(address.ErrorCode, responsedAddress.ErrorCode),
                () => Assert.AreEqual(address.ErrorMessage, responsedAddress.ErrorMessage),
                () => Assert.AreEqual(address.AddressLine1, responsedAddress.AddressLine1),
                () => Assert.AreEqual(address.AddressLine2, responsedAddress.AddressLine2),
                () => Assert.AreEqual(address.Number, responsedAddress.Number),
                () => Assert.AreEqual(address.PreDir, responsedAddress.PreDir),
                () => Assert.AreEqual(address.Street, responsedAddress.Street),
                () => Assert.AreEqual(address.Suffix, responsedAddress.Suffix),
                () => Assert.AreEqual(address.PostDir, responsedAddress.PostDir),
                () => Assert.AreEqual(address.Sec, responsedAddress.Sec),
                () => Assert.AreEqual(address.City, responsedAddress.City),
                () => Assert.AreEqual(address.State, responsedAddress.State),
                () => Assert.AreEqual(address.Zip, responsedAddress.Zip),
                () => Assert.AreEqual(address.Zip4, responsedAddress.Zip4),
                () => Assert.AreEqual(address.County, responsedAddress.County),
                () => Assert.AreEqual(address.StateFP, responsedAddress.StateFP),
                () => Assert.AreEqual(address.CountyFP, responsedAddress.CountyFP),
                () => Assert.AreEqual(address.CensusTract, responsedAddress.CensusTract),
                () => Assert.AreEqual(address.CensusBlock, responsedAddress.CensusBlock),
                () => Assert.AreEqual(address.Latitude, responsedAddress.Latitude),
                () => Assert.AreEqual(address.Longitude, responsedAddress.Longitude),
                () => Assert.AreEqual(address.GeoPrecision, responsedAddress.GeoPrecision),
                () => Assert.AreEqual(address.TimeZoneOffset, responsedAddress.TimeZoneOffset),
                () => Assert.AreEqual(address.DstObserved, responsedAddress.DstObserved, true, CultureInfo.CurrentCulture)
                );
        }

        public static void CompareResponseDataForAddress2Address(Address responsedAddress)
        {
            Address address = CreateValidTestDataObjectForAddress2Only();
            AssertAll.Succeed(
                () => Assert.AreEqual(address.ErrorCode, responsedAddress.ErrorCode),
                () => Assert.AreEqual(address.ErrorMessage, responsedAddress.ErrorMessage),
                () => Assert.AreEqual(address.AddressLine1, responsedAddress.AddressLine1),
                () => Assert.AreEqual(address.AddressLine2.ToUpper(), responsedAddress.AddressLine2.ToUpper()),
                () => Assert.AreEqual(address.Number, responsedAddress.Number),
                () => Assert.AreEqual(address.PreDir, responsedAddress.PreDir),
                () => Assert.AreEqual(address.Street, responsedAddress.Street),
                () => Assert.AreEqual(address.Suffix, responsedAddress.Suffix),
                () => Assert.AreEqual(address.PostDir, responsedAddress.PostDir),
                () => Assert.AreEqual(address.Sec, responsedAddress.Sec),
                () => Assert.AreEqual(address.City, responsedAddress.City),
                () => Assert.AreEqual(address.State, responsedAddress.State),
                () => Assert.AreEqual(address.Zip, responsedAddress.Zip),
                () => Assert.AreEqual(address.Zip4, responsedAddress.Zip4),
                () => Assert.AreEqual(address.County, responsedAddress.County),
                () => Assert.AreEqual(address.StateFP, responsedAddress.StateFP),
                () => Assert.AreEqual(address.CountyFP, responsedAddress.CountyFP),
                () => Assert.AreEqual(address.CensusTract, responsedAddress.CensusTract),
                () => Assert.AreEqual(address.CensusBlock, responsedAddress.CensusBlock),
                () => Assert.AreEqual(address.Latitude, responsedAddress.Latitude),
                () => Assert.AreEqual(address.Longitude, responsedAddress.Longitude),
                () => Assert.AreEqual(address.GeoPrecision, responsedAddress.GeoPrecision),
                () => Assert.AreEqual(address.TimeZoneOffset, responsedAddress.TimeZoneOffset),
                () => Assert.AreEqual(address.DstObserved, responsedAddress.DstObserved, true, CultureInfo.CurrentCulture)
                );
        }

        public static string GetAddres1Value()
        {
            Address address = CreateValidTestDataObject();
            return address.AddressLine1;
        }

        public static string GetAddres2Value()
        {
            Address address = CreateValidTestDataObject();
            return address.AddressLine2;
        }

    }
}
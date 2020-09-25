Feature: GET_YaAddress
	This is a group of the test cases for the example API endpoint using for the simple GET api validation
	The story contains both positive and negative scenarios
	url: api/Address
	method: GET
	format: JSON and XML

@positive
Scenario: Request to collect single address data in JSON format for valid parameters
	Given accepted header is set to JSON
	And parameters of request are valid
	When the request is send
	Then the response is valid

@positive
Scenario: Request to collect single address data in XML format for valid parameters
	Given accepted header is set to XML
	And parameters of request are valid
	When the request is send
	Then the response is valid

@positive
Scenario: Request to validate error message for valid Address2 parameter and empty Address1 parameter response
	Given accepted header is set to JSON
	And only 2nd line od address is setup
	When the request is send
	Then the response only for addres2 value is valid

@negative
Scenario: Request to validate error message for empty address response
	Given accepted header is set to JSON
	And no address setup
	When the request is send
	Then the error code is '2' and error message is 'Invalid address: invalid City-State-Zip line'
	And the address is not returned

@negative
Scenario: Request to validate error message for valid Address1 parameter and empty Address2 parameter response
	Given accepted header is set to JSON
	And only 1st line od address is setup
	When the request is send
	Then the error code is '2' and error message is 'Invalid address: no Zip or City-State given'
	And only address1 field is returned

@negative
Scenario: Request to validate error message for invalid Addres1 and Addres2 values response
	Given accepted header is set to JSON
	And address data is invalid
	When the request is send
	Then the error code is '2' and error message is 'Invalid address: no Zip or City-State given'

@negative	
Scenario: Request to validate error message for Address1 contains whole address response
	Given accepted header is set to JSON
	And 1st value contains full address
	When the request is send
	Then the error code is '2' and error message is 'Invalid address: invalid City-State-Zip line'

@negative
Scenario: Request to validate error message for Address2 contains whole address response
	Given accepted header is set to JSON
	And 2nd value contains full address
	When the request is send
	Then the error code is '4' and error message is 'City not found in state'

@negative
Scenario: Request to collect single address data in TEXT format for valid parameters
	Given accepted header is set to TEXT
	And parameters of request are valid
	When the request is send
	Then the response is valid
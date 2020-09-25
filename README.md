# YaAddressExercise

The project is an example project that shows how to use RestSharp to validate the Restfull API server - using JSON and XML accepted formats.
The solution contains both positive and negative test cases to validate how the service react for different user requests.

Steps to run:
1. checkout project from the GIT repository (master branch)
2. open .sln file in the VisualStudio - to create a solution VS2019 has been used
3. build the solution - all the dependencies from the packages.config file should be uploaded from the NuGet server
4. run the tests in the test explorer
5. [optional] having specFlow installed with the VS (and ReSharper) could be very helpful regarding the navigation between .feature files and code-behind - but this is not a mandatory step.

Test coverage:
1. Positive test cases for both JSON and XML formats.
1.1. Observation - I tried also with 'text/html' Accepted header. I expected that the service responds with an error code or error message - however, the service just behaves like for the normal JSON format request.
2. Negative test cases for: empty address values (Address1 and Address2), Empty Address1 value (valid Address2 value), Empty Address2 value (valid Address1 value), invalid values for the address (both Address1 and Address2).
3. The last two test cases are failing (red status) intentionally. The service responded in an unexpected way: the address returned for these test cases has a different format than the address returned for the positive test cases. That is why these test cases are currently failing.

The time expected for that exercise ~3h. There are multiple additional test cases that could be cover by the test automation solution, but I selected the most important test cases checking the main functionality of the service and most common user flows.

Technologies:
C#, specFlow (BDD), nUnit, RestSharp (API testing library), SoftAssert (to make data validation easier and cleaner), Newton.JSON, XMLSerializer (to translate responces to the objects), few native C#/.NET libs to support simple actions

#-----------------------------------------------------------------------------------------------
#<project file="S3.feature" type="feature file">
#<description>Contains specflow features related to S3 QA Project</description>
#</project>
#-----------------------------------------------------------------------------------------------
Feature: S3 Web Application
	Testing S3 web Application

@UITest
Scenario Outline: Validating UI
	Given the S3 <URL> is launched in <browser> browser
	And The page is completely loaded
	When I validate the title of home page
	Then the title should contain <title>
	Then Exit the Application
@source:../TestData/TestData.xlsx:UI
Examples: 
|scenario|URL|browser|title|

@APITest
Scenario Outline: Validating API
	Given the <apiURL> service is up and running
	When the client gets all projects for a given <apiURL>
	Then a <statusCode> StatusCode should be returned
	Then a <version> Version should be returned
@source:../TestData/TestData.xlsx:API
Examples: 
|scenario|apiURL|statusCode|version|responseCode|

@APITestFailure
Scenario Outline: Validating API failure scenario
	Given the <apiURL> service is up and running
	When the client gets all projects for a given <apiURL>
	Then a <reasonPhrase> ReasonPhrase should be returned
@source:../TestData/TestData.xlsx:API
Examples: 
|scenario|apiURL|statusCode|version|reasonPhrase|
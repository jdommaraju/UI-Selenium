Feature: Login
	

@smoke testing
Scenario: Login to Azure Devops
	Given I have Azure Url
	And I have entered the username and password
	When I click on Next
	Then I am able to login to Azure

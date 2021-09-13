Feature: Login
	In order to maintain the complete hospital records 
	As a portal user
	I want to access the openemr dashboard


Scenario: Valid Credential 
	Given I have browser with open emr page
	When I enter username as 'accountant'
	And I enter password as 'accountant'
	And I select language as 'English (Indian)'
	And I click on login 
	Then I should get access to the portal with title as 'OpenEMR'

Scenario: Invalid Credential
	Given I have browser with open emr page
	When I enter username as 'john'
	And I enter password as 'john123'
	And I select language as 'English (Indian)'
	And I click on login 
	Then I should get error message as 'Invalid username or password'

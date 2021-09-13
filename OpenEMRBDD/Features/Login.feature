Feature: Login
	In order to maintain the complete hospital records 
	As a portal user
	I want to access the openemr dashboard


Scenario: Valid Credential 
	Given I have browser with open emr page
	When I enter username as "admin"
	And I enter password as "pass"
	And I select language as "English (Indian)"
	And I click on login 
	Then I should get access to the portal with title as "OpenEMR"

Feature: Login
	In order to maintain the complete hospital records 
	As a portal user
	I want to access the openemr dashboard

Background: 
	Given I have browser with open emr page

Scenario: Invalid Credential
	When I enter username as 'john'
	And I enter password as 'john123'
	And I select language as 'English (Indian)'
	And I click on login 
	Then I should get error message as 'Invalid username or password12'

Scenario Outline: Valid Credential
	When I enter username as '<username>'
	And I enter password as '<password>'
	And I select language as '<language>'
	And I click on login 
	Then I should get access to the portal with title as 'OpenEMR'
	Examples: 
	| username   | password   | language         |
	| admin      | pass       | English (Indian) |
	| physician  | physician  | Dutch            |
	| accountant | accountant | English (Indian) |


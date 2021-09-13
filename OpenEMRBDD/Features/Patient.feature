Feature: Patient
	


Scenario: Add Patient
	Given I have browser with open emr page
	When I enter username as 'john'
	And I enter password as 'john123'
	And I select language as 'English (Indian)'
	And I click on login 
	And I click on Patient/client 
	And I click on Patients
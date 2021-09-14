Feature: Patient
	In order to maintain the patient records 
	as a administrator
	I should have access to modify the patient detail

Scenario: Add Patient
	Given I have browser with open emr page
	#When I enter username as 'admin'
	#And I enter password as 'pass'
	#And I select language as 'English (Indian)'
	#And I click on login
	When I mousehover on Patient/client
	And I click on Patients
	And I click on add new patient
	And I fill the form
		| firstname | lastname | dob        | gender |
		| John      | wick     | 02-02-2021 | Male   |
	And I click on create new patient
	And I click on confirm create patient
	And I store and handle the alert
	And I close the pop when available
	Then I should validate the alert message shown as 'Tobacco'
	And I should get the added patient details as 'Medical Record Dashboard John Wick'
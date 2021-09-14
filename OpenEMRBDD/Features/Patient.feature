Feature: Patient
	In order to maintain the patient records 
	as a administrator
	I should have access to modify the patient detail

@sample
Scenario: SampleTest
	Given I started the test
	When I fill the detail
		| firstname | lastname | dob        | gender |
		| John      | wick     | 2021-09-14 | Male   |
		| Mark      | wick     | 2021-09-18 | Female |
	And I conntect all cities
		| cities |
		| hyd    |
		| ban    |
		| chn    |
	Then I should get


@ignore
Scenario Outline: Add Patient
	Given I have browser with open emr page
	When I enter username as 'admin'
	And I enter password as 'pass'
	And I select language as 'English (Indian)'
	And I click on login
	When I mousehover on Patient/client
	And I click on Patients
	And I click on add new patient
	And I fill the form
		| firstname   | lastname   | dob   | gender   |
		| <firstname> | <lastname> | <dob> | <gender> |
	And I click on create new patient
	And I click on confirm create patient
	And I store and handle the alert
	And I close the pop when available
	Then I should validate the alert message shown as '<expectedAlert>'
	And I should get the added patient details as '<expectedvalue>'

	Examples:
		| firstname | lastname | dob        | gender | expectedAlert | expectedvalue                        |
		| John      | wick     | 2021-09-14 | Male   | Tobacco       | Medical Record Dashboard - John Wick |
		| Mark      | wick     | 2021-09-14 | Male   | Tobacco       | Medical Record Dashboard - Mark Wick |
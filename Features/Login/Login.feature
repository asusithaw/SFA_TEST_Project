Feature: Testing Login Functionality 

When adding the correct userName and password, A user able to Login into the SFA System. 

@Functional_Testing
Scenario: User adds correct Password and UserName for Login (Best Case)
	Given I navigate to Login Info page
	And I enter the following login details
	 | UserName | Password |
	 | evision  | 123      |
	And I click the Login button
	Then Successfully Logged into the system

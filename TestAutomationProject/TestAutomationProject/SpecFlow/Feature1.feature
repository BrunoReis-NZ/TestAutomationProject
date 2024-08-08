Feature: Feature1

As a TurnUp portal admin user
I want to create, edit and delete records
So that I can manage the records efficiently

@tag1
Scenario: Create new record with valid data
	Given I login to the TurnUp portal successfully
	When I navigate to the record page
	And I create a new record with valid data
	Then The record should be created successfully

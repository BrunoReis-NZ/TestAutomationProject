Feature: CreateEditAndDeleteFeature

As a TurnUp portal admin user
I want to create, edit and delete records
So that I can manage the records efficiently

@tag1
Scenario: Create new record with valid data
	Given I login to the TurnUp portal successfully
	When I navigate to the record page
	And I create a new record with valid data
	Then The record should be created successfully

Scenario Outline: Edit a record with valid data
	Given I login to the TurnUp portal successfully
	When I navigate to the record page
	And I update the'<code>', the '<description>' and the '<price>' on an existing record
	Then The record should have the updated '<code>', the '<description>' and the '<price>' on an existing record

	Examples:
	| code				| description				| price		|
	| testEditedCode1	| testEditedDescription1	| $200.00	|
	| testEditedCode2	| testEditedDescription2	| $300.00	|
	| testEditedCode3	| testEditedDescription3	| $400.00	|

Scenario: Delete a record
	Given I login to the TurnUp portal successfully
	When I navigate to the record page
	And I delete an existing record
	Then The record should be deleted successfully
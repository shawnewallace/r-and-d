Feature: Addition

In order to know my total grocery bill
As a shopper
I want to add numbers

	Scenario:  Add two numbers
		Given I have cleared the calculator
		When I enter 2
		And I add 2
		Then the result should be 4

	Scenario: Add two more numbers
		Given I have cleared the calculator
		When I enter 999
		And I add 1
		Then the result should be 1000

	Scenario: Add three numbers
		Given I have cleared the calculator
		When I enter 50
		And I add 25
		And I add -10
		Then the result should be 65
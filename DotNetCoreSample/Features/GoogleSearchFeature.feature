Feature: GoogleSearchFeature
	To search for a text in Google

@mytag
Scenario: Google search
	Given I have opened Chrome application
	And I have navigated to google web page
	When I enter text "Google"
	And click google search button
	Then I am navigated to search result screen

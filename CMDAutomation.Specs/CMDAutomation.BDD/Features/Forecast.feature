Feature: Forecast
	In order to project my companies/projects data
	As a Forecast user
	I want to be shown with the right data

@Forecast
Scenario: Validate development type for the selected measurement type 1
	Given I navigate to application
	  And navigate to 'Forecast' module
	  And expand all the filters
	When Data Set is 'Historical and Forecast' and Measurement type is 'Value'
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| All             |
		| New and Addition|
		| Renovation      |
	When select 'Sq.Ft.' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| New and Addition|
	 And The following Development Types should be disabled
	    | DevelopmentType |
		| All             |
		| Renovation      |
	When select 'Projects' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType     |
		| All                 |
		| New                 |
		| Addition            |
		| Alteration          |
		| Addition/Alteration |

@Forecast
Scenario: Validate development type for the selected measurement type 3
	Given I navigate to application
	  And navigate to 'Forecast' module
	  And expand all the filters
	When Data Set is 'Historical and Forecast' and Measurement type is 'Value'
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| All             |
		| New and Addition|
		| Renovation      |
	When select 'Sq.Ft.' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| New and Addition|
	 And The following Development Types should be disabled
	    | DevelopmentType |
		| All             |
		| Renovation      |
	When select 'Projects' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType     |
		| All                 |
		| New                 |
		| Addition            |
		| Alteration          |
		| Addition/Alteration |

@Forecast
Scenario: Validate development type for the selected measurement type 2
	Given I navigate to application
	  And navigate to 'Forecast' module
	  And expand all the filters
	When Data Set is 'Historical and Forecast' and Measurement type is 'Value'
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| All             |
		| New and Addition|
		| Renovation      |
	When select 'Sq.Ft.' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType |
		| New and Addition|
	 And The following Development Types should be disabled
	    | DevelopmentType |
		| All             |
		| Renovation      |
	When select 'Projects' measurement type
	Then the following Development Types should be displayed and enabled
		| DevelopmentType     |
		| All                 |
		| New                 |
		| Addition            |
		| Alteration          |
		| Addition/Alteration |
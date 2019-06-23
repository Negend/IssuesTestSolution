Feature: Issues
	Managing issues with an authorised client


Scenario: An authenticated client can create an issue
	Given authenticated client is set for a create issue request
	When I send a post request with the following request body
	| key | value |
	| hi  | ho    |
	Then success response status should be 201
	And  response body 


Scenario: An authenticated client can edit an issue
	Given authenticated client is set for an edit issue request
	When I send a patch request with the following request body
	| key | value |
	| hi  | ho    |
	Then success response status should be 200
	And  response body 



Scenario: An authenticated client can list issues for a repo
	Given authenticated client is set for a retrieve repo issues request
	When I send the get request
	Then success response status should be 200
	And  response body 


Feature: Issues
	Managing issues with an authorised client


Scenario: An authenticated client can create an issue
	Given client is authenticated 
	And following endpoint is set to 
	When I send a post request with the following request body
	| key | value |
	| hi  | ho    |
	Then response status should be 200 ok
	And  response body 


Scenario: An authenticated client can edit an issue
	Given client is authenticated 
	And following endpoint is set to 
	When I send a put request with the following request body
	| key | value |
	| hi  | ho    |
	Then response status should be 200 ok
	And  response body 



Scenario: An authenticated client can list issues for a repo
	Given client is authenticated 
	And following endpoint is set to 
	When I send the get request
	Then response status should be 200 ok
	And  response body 


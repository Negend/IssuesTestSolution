# IssuesTestSolution

## Tools
* language C#
* Visual Studio 2017 
* Specflow,Specflow Runner 
* RestSharp
* Github

## Installation

### Github Access

Locate the code snippet below and fill in with details of a personal account App.config in solution
```  <appSettings>
    <add key="BaseUrl" value="https://api.github.com"/>
    <add key="GitToken" value="eb7037d6fea488870ab95ce58e4a6e011bb002c0" />
    <add key="GithubRepo" value="IssuesTestSolution"/>
    <add key="GitUser" value="Negend"/>
  </appSettings> 
 ```
Along with a personal account  personal stated as **GitUser** a repository is required for this setup. The name of which should be entered as the value for **GitRepo**.
The **GitToken** is the personal token for the account which can be generated from github website in 'Developer Settings' the token must at least be scoped to repository access.

### Loading solution

For users using visual studio 17 
* Update app.config as described above
* install specflow extention to visual studios
* build solution
* open test explorer and click Run All to discover and run the tests

## Test Flow
 Due to dependencies test must be run in order for the first time or the initial issue should exist with title 'Hello'.
 * Scenario 1 creates a new issue
 * Scenario 2 edits the first issue ever created
 * Scenario 3  lists the issues in the current Repo verifies the order and the Title of the first issue
 * each test verifies response status code and response content

## Improvements to be made
* A bit more testing on the headers and body of the response of all requests made. 
* Allow flexible optional parameters in the json body input by the IssueDetails.cs model
* investigate the certificate issue for a better fix
* have token and any other personal information set as an environment variable. so security data is not shared in project during work
* create a given step for the edit scenario that ensures an issue already exists(the last to be created) so that the same issue is not being updated
* by default the list of paramaters is in correct order. in future this will be passed as an aption paramater for the test
* remove test resulsts and .vs from repository
#### For more information or in the event that the solution fails to load, run or files are unable to clone. [Click here](https://drive.google.com/file/d/11iY5OUBoUv0mC-OpSLLM0OXfCyGS4veZ/view?usp=sharing "Video Presentation") for a brief demo on the Test Framework


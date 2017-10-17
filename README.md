# CodeChallenge API
-----------------------

Useage:
GET:
url: http://localhost:60560/api/Followers/{GitId}

GET:
url: http://localhost:60560/api/Repository/{GitId}

POST:
url: http://localhost:60560/api/Stargazer/{GitId}
Body: 
[
	{
	"Repository": "{repositoryNameGoesHere}"
	}
]

using System.Collections.Generic;
using CodeChallenge.Models;
using CodeChallenge.Services;
using CodeChallenge.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Stargazer")]
    public class StargazerController : Controller
    {
        [HttpPost("{gitId}")]
        public IEnumerable<StargazerModel> GetFollowers(string gitId, [FromBody] IEnumerable<RepositoryNameModel> repository)
        {
            var starGazers = new StargazerService(gitId, repository);

            return starGazers.PresentstarGazersByGitIdAndRepository();
        }
    }
}
using System.Collections.Generic;
using CodeChallenge.Services;
using CodeChallenge.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Repository")]
    public class RepositoryController : Controller
    {
        [HttpGet("{gitId}")]
        public IEnumerable<RepositoryModel> GetFollowers(string gitId)
        {
            var repositories = new RepositoryService(gitId);

            return repositories.PresentRepositoriesByGitId();
        }
    }
}
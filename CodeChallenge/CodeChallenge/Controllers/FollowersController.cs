using System.Collections.Generic;
using CodeChallenge.Services;
using CodeChallenge.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Controllers
{
    [Produces("application/json")]
    [Route("api/Followers")]
    public class FollowersController : Controller
    {
        [HttpGet("{gitId}")]
        public IEnumerable<FollowerModel> GetFollowers(string gitId)
        {
            var followers = new FollowersService(gitId);

            return followers.PresentFollowersByGitId();
        }
    }
}
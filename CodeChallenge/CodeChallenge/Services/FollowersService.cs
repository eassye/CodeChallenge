using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Services.Models;

namespace CodeChallenge.Services
{
    public class FollowersService
    {
        private readonly CodeChallengeClient client;
        private readonly string gitId;

        public FollowersService(string gitId)
        {
            this.gitId = gitId;
            client = new CodeChallengeClient();
        }

        public IEnumerable<FollowerModel> PresentFollowersByGitId()
        {
            return FilterFollowersToOnlyContainFiveFollowers();
        }

        private IEnumerable<FollowerModel> FilterFollowersToOnlyContainFiveFollowers()
        {
            return client.GetFollowersForGitId(gitId).Take(5);
        }
    }
}

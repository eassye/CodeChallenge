using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Services.Models;

namespace CodeChallenge.Services
{
    public class RepositoryService
    {
        private readonly CodeChallengeClient client;
        private readonly string gitId;

        public RepositoryService(string gitId)
        {
            this.gitId = gitId;
            client = new CodeChallengeClient();
        }

        public IEnumerable<RepositoryModel> PresentRepositoriesByGitId()
        {
            return FilterRepositoriesToOnlyContainThreeRepositories();
        }

        private IEnumerable<RepositoryModel> FilterRepositoriesToOnlyContainThreeRepositories()
        {
            return client.GetRepositoriesByGitId(gitId).Take(3);
        }
    }
}

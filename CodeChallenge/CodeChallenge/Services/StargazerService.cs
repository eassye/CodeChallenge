using System;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;
using CodeChallenge.Services.Models;

namespace CodeChallenge.Services
{
    public class StargazerService
    {
        private readonly CodeChallengeClient client;
        private readonly string gitId;
        private readonly IEnumerable<RepositoryNameModel> repository;

        public StargazerService(string gitId, IEnumerable<RepositoryNameModel> repository)
        {
            this.gitId = gitId;
            this.repository = repository;
            client = new CodeChallengeClient();
        }

        public IEnumerable<StargazerModel> PresentstarGazersByGitIdAndRepository()
        {
            return AddFilteredStargazerResultsToFinalListByRepository();
        }

        private IEnumerable<StargazerModel> AddFilteredStargazerResultsToFinalListByRepository()
        {
            var starGazers = new List<StargazerModel>();

            foreach (var repo in repository)
            {
                starGazers.AddRange(FilterStargazersToOnlyContainThreeStargazersPerRepository(repo.Repository));
            }

            return starGazers;
        }

        private IEnumerable<StargazerModel> FilterStargazersToOnlyContainThreeStargazersPerRepository(string repository)
        {
            return client.GetStargazersForGitIdAndRepository(gitId, repository).Take(3);
        }
    }
}

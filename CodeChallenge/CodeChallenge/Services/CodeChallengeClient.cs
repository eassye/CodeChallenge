using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CodeChallenge.Services.Models;

namespace CodeChallenge.Services
{
    public class CodeChallengeClient
    {
        private readonly HttpClient httpClient;

        public CodeChallengeClient()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "eassye");
        }

        public IEnumerable<FollowerModel> GetFollowersForGitId(string gitId)
        {
            try
            {
                var result = httpClient.GetAsync(new Uri($"https://api.github.com/users/{gitId}/followers")).Result;

                return result.Content.ReadAsAsync<List<FollowerModel>>().Result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }          
        }

        public IEnumerable<StargazerModel> GetStargazersForGitIdAndRepository(string gitId, string repository)
        {
            try
            {
                var result = httpClient.GetAsync(new Uri($"https://api.github.com/repos/{gitId}/{repository}/stargazers")).Result;

                return result.Content.ReadAsAsync<List<StargazerModel>>().Result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public IEnumerable<RepositoryModel> GetRepositoriesByGitId(string gitId)
        {
            try
            {
                var result = httpClient.GetAsync(new Uri($"https://api.github.com/users/{gitId}/repos")).Result;

                return result.Content.ReadAsAsync<List<RepositoryModel>>().Result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using application.brain.Declaration;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;

namespace application.brain.Defination
{
    public class ExternalResources : IExternalResources
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public SearchListResponse SearchYoutube(string searchQuery)
        {
            return SearchVedio(searchQuery);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        private SearchListResponse SearchVedio(string searchQuery)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCy_HSZf6UFJnHT8yXOjfEQqTmRt2Y8SXU",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchQuery; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();        
            searchListResponse.Items= searchListResponse.Items.Where(x => x.Id.Kind == "youtube#video").ToList();
            return searchListResponse;
        }
    }
}

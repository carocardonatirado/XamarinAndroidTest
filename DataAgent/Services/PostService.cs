using Contracts.Interfaces;
using Entities.Business;
using Entities.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Resources;

namespace DataAgent.Services
{
    public class PostService : BaseApiService, IPostService
    {
        public PostService(IDeviceManager deviceManager)
          : base(deviceManager)
        {
        }

        public async Task<PostsResponse> GetPosts()
        {
            PostsResponse postsResponse = new PostsResponse();
            string endpoint = Configurations.PostsEndPoint;
            var response = await HttpClientBaseService.GetAsync(endpoint);

            if (response.Content == null)
            {
                return (PostsResponse)Convert.ChangeType(response, typeof(PostsResponse));
            }
            else
            {
                string data = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(data))
                {
                    return new PostsResponse
                    {
                    };
                }

                var result = JsonConvert.DeserializeObject<IList<Post>>(data);
                postsResponse.Posts = result;
                return postsResponse;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Resources;

namespace TestPeople.Logic.Repositories.Remote.Base
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

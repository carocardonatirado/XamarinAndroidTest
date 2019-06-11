using Contracts.Interfaces;
using Entities.Business;
using Entities.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PostModel
    {
        private IPostService _postService { get; set; }

        public PostModel(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<PostsResponse> GetPosts(int UserId)
        {
            var response = await _postService.GetPosts();

            if (response != null && response.Posts != null && response.Posts.Any())
            {
                response.Posts = response.Posts.Where(x => x.UserId == UserId).ToList();
            }

            return response;
        }
    }
}

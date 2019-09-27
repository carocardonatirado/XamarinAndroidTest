using System.Linq;
using System.Threading.Tasks;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Managers
{
    public class PostManager
    {
        private IPostService _postService { get; set; }

        public PostManager(IPostService postService)
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

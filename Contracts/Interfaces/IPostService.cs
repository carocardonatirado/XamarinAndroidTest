using Entities.Response;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IPostService
    {
        Task<PostsResponse> GetPosts();
    }
}

using System.Threading.Tasks;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Contracts
{
    public interface IPostService
    {
        Task<PostsResponse> GetPosts();
    }
}

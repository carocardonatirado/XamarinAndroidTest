using Contracts.Interfaces;
using Entities.Business;
using Entities.Response;
using Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestPeople.Test
{
    public class PostModelTest
    {
        protected Mock<IPostService> postService;
        protected Mock<IHttpClientService> HttpClientService;
        protected PostModel model;

        public PostModelTest()
        {
            postService = new Mock<IPostService>();
            HttpClientService = new Mock<IHttpClientService>();
            model = new PostModel(postService.Object);
        }


        [Fact]
        public async Task GetPostsFromTheServiceSuccessful()
        {
            var posts = new List<Post>
            {
                new Post { Title = "any", Body= "any any any", UserId = 1, Id = "1" }
            };

            int UserId = 1;

            var response = new PostsResponse()
            {
                Posts = posts
            };

            postService.Setup(_ => _.GetPosts()).ReturnsAsync(response);

            // Action
            var actual = await model.GetPosts(UserId);

            // Assert
            Assert.True(response.Posts.Any());
        }

        [Fact]
        public async Task GetPostsUserDoesNotHavePosts()
        {
            var posts = new List<Post>
            {
                new Post { Title = "any", Body= "any any any", UserId = 1, Id = "1" }
            };

            int UserId = 2;

            var response = new PostsResponse()
            {
                Posts = posts
            };

            postService.Setup(_ => _.GetPosts()).ReturnsAsync(response);

            // Action
            var actual = await model.GetPosts(UserId);

            // Assert
            Assert.True(!response.Posts.Any());
        }
    }
}

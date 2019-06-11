using Entities.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Response
{
    public class PostsResponse
    {
        public IList<Post> Posts { get; set; }
    }
}

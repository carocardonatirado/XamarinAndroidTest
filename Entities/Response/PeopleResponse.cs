using Entities.Business;
using System.Collections.Generic;

namespace Entities.Response
{
    public class PeopleResponse
    {
        public IList<Person> People { get; set; }
    }
}

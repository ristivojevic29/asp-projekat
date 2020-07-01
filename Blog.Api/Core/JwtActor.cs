using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; } 

        public string Identity { get; set; }

        public IEnumerable<int> AllowedUseCases => new List<int> { 5, 8, 9, 16, 17, 18, 20 };
       // public IEnumerable<int> AllowedUseCases { get; set; }
    }
}

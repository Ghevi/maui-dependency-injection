using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Services
{
    public class MyService
    {
        public MyService() { }

        public Task<IEnumerable<String>> GetNames() => Task.FromResult(new[]
        {
            "Andrew",
            "Mark",
            "Sara"
        }
        .AsEnumerable());
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public interface IWebTest
    {
        JObject GetAllMovies();

        string GetDirector();
    }
}

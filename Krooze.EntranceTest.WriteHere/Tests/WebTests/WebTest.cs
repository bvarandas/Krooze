using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Linq;


namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        

        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object
            var responseString = this.GetApi("https://swapi.co/api/films/");

            JObject retorno = JObject.Parse(responseString);

            return retorno;
        }

        private string GetApi(string Url)
        {
            WebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //JObject retorno = JObject.Parse(responseString);

            return responseString;
        }
        
        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return
            var responseString = this.GetApi("https://swapi.co/api/films/");

            JObject objJson = JObject.Parse(responseString);
            var filter = from c in objJson["results"].Children()["director"].Values<string>()
                         group c by c into g
                         orderby g.Count() descending
                         select new { diretor = g.Key, Count = g.Count() };
            //retorno = objJson["results"]

            return filter.FirstOrDefault().diretor;
        }
    }
}


namespace CatFacts.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Http;

    [Route("api/catfact")]
    public class CatFactsController : ApiController
    {
        public IHttpActionResult Post()
        {
            //C:\github\better-cat-facts\catfactsdata
            var fact = "Cats are actually very tech saavy.";

            var catFacts = File.ReadAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt");

            var catFactsList = catFacts.ToList();

            catFactsList.Add(fact);
            
            File.WriteAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt", catFactsList);

            return Ok("hello");
        }

        public IHttpActionResult Get()
        {
            

            return Ok();
        }
    }
}
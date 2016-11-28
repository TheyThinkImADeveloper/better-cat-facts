
namespace CatFacts.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/catfact")]
    public class CatFactsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post([FromBody] string catFactToSave)
        {
            //C:\github\better-cat-facts\catfactsdata

            var catFacts = File.ReadAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt");

            var catFactsList = catFacts.ToList();

            catFactsList.Add(catFactToSave);
            
            File.WriteAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt", catFactsList);

            return Ok();
        }

        [Route("{catFactNumber}")]
        public IHttpActionResult Get(int catFactNumber)
        {


            return Ok();
        }

        [Route("{catFactNumber}"), HttpDelete]
        public IHttpActionResult Delete(int catFactNumber)
        {

            return null;
        }
    }
}
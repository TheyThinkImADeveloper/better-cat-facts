
namespace CatFacts.Controllers
{
    using System;
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

        [Route("{indexOfDeletedCatFact}"), HttpDelete]
        public IHttpActionResult Delete(int indexOfDeletedCatFact)
        {
            var catFacts = File.ReadAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt");

            //catFacts.ToList().RemoveAt(indexOfDeletedCatFact);

            var catFactsList = catFacts.ToList();

            catFactsList.RemoveAt(indexOfDeletedCatFact);

            File.WriteAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt", catFactsList);
            
            return Ok();
        }
    }
}
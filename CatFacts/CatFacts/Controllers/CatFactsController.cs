
namespace CatFacts.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/catfact")]
    public class CatFactsController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post([FromBody] string catFactToSave)
        {
            var catFacts = ReadCatFactsFile();

            catFacts.Add(catFactToSave);
            
            File.WriteAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt", catFacts);

            return Ok();
        }

        [Route("{catFactNumber}")]
        public IHttpActionResult Get(int catFactNumber)
        {
            var catFacts = this.ReadCatFactsFile();

            return Ok(catFacts[catFactNumber]);
        }

        [Route("{indexOfDeletedCatFact}"), HttpDelete]
        public IHttpActionResult Delete(int indexOfDeletedCatFact)
        {
            var catFacts = ReadCatFactsFile();

            catFacts.RemoveAt(indexOfDeletedCatFact);

            File.WriteAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt", catFacts);
            
            return Ok();
        }

        private List<string> ReadCatFactsFile()
        {
            var catFacts = File.ReadAllLines(@"C:\github\better-cat-facts\catfactsdata\catfacts.txt");
            return catFacts.ToList();
        }
    }
}
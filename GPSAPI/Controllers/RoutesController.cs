using System.Linq;
using System.Web.Http;
using static GPSAPI.Models.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GPSAPI.Controllers
{
    public class RoutesController : ApiController
    {

        /// <summary>
        /// Megadja az összes uthoz tartozó összes bejegyzést
        /// </summary>
        /// <returns>Json</returns>
        [HttpGet]
        public string Get()
        {
            using (Models.Models.ModelContainer _model = new ModelContainer())
            {
               string retval= JsonConvert.SerializeObject(_model.Routes.ToList(), Formatting.None, new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
               });
               return retval;
            }

        }

        //route id(ugy értelmeztem a feladatot hogy az egyes utvonalhoz tartozó összes lépés gps koordinátái kellenek)
        /// <summary>
        /// Megadja aza dott utvonalhoz tatozó összes gps pontot
        /// </summary>
        /// <param name="id">Útvonal azonosító</param>
        /// <returns>Json</returns>
        [HttpGet]
        public string Get(int id)
        {
            using (ModelContainer _model = new ModelContainer())
            {
                string retval = JsonConvert.SerializeObject(_model.Routes.Where(z=>z.RouteId==id).ToList(), Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });
                return retval;
            }
        }

        /// <summary>
        /// Elmenti a kapott gps bejegyzést
        /// </summary>
        /// <param name="value">Json object</param>
        [HttpPost]
        public void POST([FromBody]JObject value)
        {
            using (ModelContainer _model = new ModelContainer())
            {
                Routes newGps = value.ToObject<Routes>();
                _model.Routes.Add(newGps);
                _model.SaveChanges();
            }
        }

    }
}

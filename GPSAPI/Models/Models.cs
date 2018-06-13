using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GPSAPI.Models
{
    public class Models
    {
        public class Routes
        {
            public int Id { get; set; }         
            public int RouteId { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }

        public class ModelContainer: DbContext
        {
            public ModelContainer() : base("name=ModelContainer")
            {

            }
            public DbSet<Routes> Routes { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMA_site_app.Models {
    public class Fighter {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string From { get; set; }
        public string FightsOutOf { get; set; }
        public int? Age { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HeightCm { get; set; }
        public string WeightKg { get; set; }
        public string Reach { get; set; }
        public string LegReach { get; set; }
        public string Record { get; set; }
        public string Summary { get; set; }
        public string ImageInList { get; set; }
        public string ImageMainProfile { get; set; }

        public ICollection<Perfomanse> Perfomanses { get; set; }
    }
}

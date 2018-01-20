using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MMA_site_app.Models {
    public class Perfomanse {

        public int PerfomanseID { get; set; }

        public string EnemyName { get; set; }
        public string EnemyLink { get; set; }
        public string Result { get; set; }
        public string Tournament { get; set; }
        public string Date { get; set; }
        public string Method { get; set; }
        public int? Round { get; set; }
        public string Time { get; set; }
        public string Video { get; set; }

        public int FighterID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMA_site_app.Models {
    public class TitleHolder {
        public int TitleHolderID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Record { get; set; }
        public string WeightCategory { get; set; }
        public int Order { get; set; }
        public string ProfileLink { get; set; }
        public string ImageTitle { get; set; }

    }
}

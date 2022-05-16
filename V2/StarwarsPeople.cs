using System;
using System.Collections.Generic;
using System.Text;

namespace V2
{

    public class Starwars
    {

        public string message { get; set; }
        public int total_records { get; set; }
        public int total_pages { get; set; }
        public string next { get; set; }

        public List<people> results { get; set; }


    }
    public class people
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string url { get; set; }


    }
}

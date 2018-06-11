using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPI_winform
{
    public class Rootobject
    {
        public Note[] notes { get; set; }
    }

    public class Note
    {
        public int noteid { get; set; }
        public string message { get; set; }
    }

}

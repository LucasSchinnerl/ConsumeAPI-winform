using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumeAPI_winform
{
        
    public class Note
    {
        [JsonProperty ("noteid")]
        public int Id { get; set; }
        [JsonProperty ("message")]
        public string Message { get; set; }
    }

}

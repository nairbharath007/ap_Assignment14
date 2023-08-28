using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserializeFromFiles.Model
{
    [Serializable] // Required for Binary Serialization
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

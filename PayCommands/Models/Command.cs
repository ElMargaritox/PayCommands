using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayCommands.Models
{
    public class Command
    {
        [XmlAttribute("Name")]
        public string Name;
        [XmlAttribute("Cost")]
        public decimal Cost;
    }
}

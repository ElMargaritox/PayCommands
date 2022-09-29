using PayCommands.Models;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PayCommands
{
    public class Config : IRocketPluginConfiguration
    {

        public bool UseEconomy;
        [XmlArray("Commands")]
        public List<Command> Commands { get; set; }
        public void LoadDefaults()
        {
            UseEconomy = true;
            Commands = new List<Command>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsPokemon
    {

        private string name;
        private string url;
        private string foto = "";

        public string Name
        {
            get { return name; }
            set { name = value;}
        }
        public string Url 
        {
            get { return url; }
            set { url = value; foto = ""; }
        }

        public string Foto 
        {
            get { return url; }

        }

        public ClsPokemon()
        {
            
        }

        public ClsPokemon(int dex, string name, string url)
        { 
            this.Name = name;
            this.Url = url;

        }
    }
}

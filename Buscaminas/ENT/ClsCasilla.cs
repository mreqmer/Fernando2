using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsCasilla
    {

        private bool esRevelado = false;
        private bool esBomba = false;
        private string img;

        public bool EsRevelado 
        {
            get 
            {
                return esRevelado; 
            } 
            set 
            { 
                esRevelado = value; 
            } 
        }
        public bool EsBomba 
        {
            get
            {
                return esBomba; 
            }
            set 
            {
                esBomba = value; 
            } 
        }

        string Img
        {
            get 
            { 
                return img;
            }
            set
            {
                img = value; 
            } 
        }

        public ClsCasilla()
        {

        }

        //public ClsCasilla()
        //{

        //}

    }
}

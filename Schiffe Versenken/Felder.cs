using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schiffe_Versenken
{
    public class Felder
    {
        bool is_own {  get; set; }
        public bool clicked {  get; set; }
        public bool is_ship {  get; set; }
        public Felder(bool is_own) 
        { 
            this.is_own = is_own;
            clicked = false;
            is_ship = false;
        }
    }
}

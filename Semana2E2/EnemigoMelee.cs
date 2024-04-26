using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2E2
{
    internal class EnemigoMelee : Padre
    {
      public EnemigoMelee(int vida, int daño) : base(vida,daño)
       {
            nombre = "EnemigoMelee"; 
       }
    }
}

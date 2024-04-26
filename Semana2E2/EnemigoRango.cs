using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Semana2E2
{
    internal class EnemigoRango : Padre
    {
        int municion;

        public EnemigoRango(int vida, int daño, int municion) : base(vida, daño)
        {
            this.municion = municion;
            nombre = "EnemigoRango";
        }

        public override int dañoQueInflinge()
        {
           if(municion > 0) 
           {
                municion -= 1;
                return base.dañoQueInflinge(); //base accede a la función padre y toma su comportamiento
           }
            else 
           {
                Console.WriteLine("No queda munición");
                return 0;
           }

           
        }
    }


}

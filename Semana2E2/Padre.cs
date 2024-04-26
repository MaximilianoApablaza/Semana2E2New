using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2E2
{
    internal class Padre
    {
        
        public int vida;
        public int daño;
        public string nombre;
        public Padre(int vida, int daño) 
        {
            this.vida = vida;
            this.daño = daño;
        }



        public virtual void recibirDaño(int daño)
        {
            vida -= daño;
        }

        public virtual int dañoQueInflinge()
        {
            return daño;
        }

        public virtual bool seEncuentraConVida() 
        { 
            if(vida > 0) 
            {
                
                return true;
            }
            else 
            {
                
                return false;
            }
       
        }
    }
}

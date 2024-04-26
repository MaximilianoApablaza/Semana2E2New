using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2E2
{
    internal class Jugador : Padre
    {
        public Jugador(int vida, int daño) : base(vida, daño) { }
        public void creacionDeljugador() 
        {
            Console.WriteLine("Inserte su vida inicial");
            vida = asignarValor();
            Console.WriteLine($"Su vida : {vida}");
            Console.WriteLine("Inserte su daño inicial");
            daño = asignarValor();
            Console.WriteLine($"Su daño : {daño}");
        }

        private int asignarValor()
        {
            while(true) 
            {
                string respuesta = Console.ReadLine();
                if (int.TryParse(respuesta, out int valorConvertido))
                {     
                    if (valorConvertido <= 100 && valorConvertido > 0)
                    {
                        return valorConvertido;
                    }
                    Console.WriteLine("El valor asignado no esta entre 1 y 100");
                    continue;
                }
                Console.WriteLine("Ingrese un número entero por favor");
            }
            
        }
    }
}



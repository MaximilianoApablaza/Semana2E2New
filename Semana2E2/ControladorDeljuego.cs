using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2E2
{
    internal class ControladorDeljuego
    {
        bool turnoDelJugador = true;
        int turnoActualDelEnemigo;
        bool victoria;
        Jugador jugador;
        List<Padre> Enemigos = new List<Padre>();

        public void iniciarJuego() 
        {
            EnemigoMelee Enemigo = new EnemigoMelee(10,8);
            EnemigoRango Enemigo2 = new EnemigoRango(12,10, 3);
            Enemigos.Add(Enemigo);
            Enemigos.Add(Enemigo2);

            jugador = new Jugador(0, 0);
            jugador.creacionDeljugador();

            while (!juegoTerminado()) 
            {
                if (turnoDelJugador)
                {
                    int contadorDeVivos = 1;
                    List<Padre> enemigosVivos = new List<Padre>();

                    Console.WriteLine("Es tu turno, selecciona un enemigo");
                    for (int i = 0; i < Enemigos.Count; i++)
                    {
                        if (!Enemigos[i].seEncuentraConVida()) //Comprueba si no está vivo, y si no, procede a la siguiente iteración
                        {
                            continue;
                        }
                        Console.WriteLine($"{contadorDeVivos}) {Enemigos[i].nombre}");// )> Enlista el texto, enumera, se ve bonito 
                        enemigosVivos.Add(Enemigos[i]);
                        contadorDeVivos++;
                    }
                    string respuesta = Console.ReadLine();
                    int respuestaNumero = int.Parse(respuesta) - 1;
                    enemigosVivos[respuestaNumero].recibirDaño(jugador.dañoQueInflinge());

                    if(enemigosVivos[respuestaNumero].seEncuentraConVida())
                    {
                        Console.WriteLine($"La vida restante de {enemigosVivos[respuestaNumero].nombre} es {enemigosVivos[respuestaNumero].vida}");
                    }
                    else
                    {
                        Console.WriteLine($"{enemigosVivos[respuestaNumero].nombre} está muerto");
                    }
                }
                else
                {
                    if (juegoTerminado()) { continue; }
                    while (!Enemigos[turnoActualDelEnemigo].seEncuentraConVida()) { cambiarTurnoDeEnemigo(); }
                    Console.WriteLine($"Es turno de {Enemigos[turnoActualDelEnemigo].nombre}");
                    jugador.recibirDaño(Enemigos[turnoActualDelEnemigo].dañoQueInflinge());
                    Console.WriteLine($"{Enemigos[turnoActualDelEnemigo].nombre} ataca!");

                    if(jugador.seEncuentraConVida())
                    {
                        Console.WriteLine($"La vida restante del jugador es {jugador.vida}");
                    }
                    else
                    {
                        Console.WriteLine($"El jugador ha muerto!");
                    }
                    cambiarTurnoDeEnemigo();
                }
                
                turnoDelJugador = !turnoDelJugador;
            }

            if (victoria) { Console.WriteLine("Ganaste!!!!"); }
            else { Console.WriteLine("Perdiste!!!! te espera un phonk"); }

            Console.ReadKey();

             // esto invierte la respuesta anterior haciendo que la condicion no se cicle

            /*if (turnoActualDelEnemigo == 0)
            {
                Enemigo.dañoQueInflinge();
            }
            else
            {
                Enemigo2.dañoQueInflinge();             Malas praxis, evitar abusar de los ifs si hay muchos enemigos o casos
            }*/

            
        }

        public void cambiarTurnoDeEnemigo()
        {
            turnoActualDelEnemigo ++;
            if(turnoActualDelEnemigo >= Enemigos.Count)
            {
                turnoActualDelEnemigo = 0; //esto resetea el contador (lleva la cuenta), cuando se llega al limite de la lista, vuelve a recorrerla
            }
        }

        private bool juegoTerminado()
        {
            if (!jugador.seEncuentraConVida()) // ! significa falso, en este caso si da falso, continua, y true, termina
            {
                victoria = false;
                return true;
            }

            int contador = 0;
            for (int i = 0; i < Enemigos.Count; i++)// count es una funcion unicamente para listas, nada mas 
            {
               if (!Enemigos[i].seEncuentraConVida()) // ¿Este enemigo esta muerto? 
                {  
                    contador++;
                }
            }
            if (contador >= Enemigos.Count)
            {
                victoria = true;
                return true;
            }
            return false;
        }
    }

}

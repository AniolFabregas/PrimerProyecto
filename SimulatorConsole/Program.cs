using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    public class Program
    {
        static FlightPlanList lista = new FlightPlanList();
        static void Main(string[] args)
        {
            ProbarFase1();                                                        // primer de tot fem les proves de la Fase 1 i les ensenyem per pantalla
            Console.WriteLine("Pulsa ENTER para continuar con el simulador...");  // avisem que cal apretar enter
            Console.ReadLine();                                                   // ens esperem fins que l'usuari apreti enter
            try
            {
                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                string identificador = Console.ReadLine(); ;

                Console.WriteLine("Escribe la velocidad");
                double velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                string linea = Console.ReadLine();
                string[] trozos = linea.Split(' ');
                double ix = Convert.ToDouble(trozos[0]);
                double iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                double fx = Convert.ToDouble(trozos[0]);
                double fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_a = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);


                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                identificador = Console.ReadLine(); ;

                Console.WriteLine("Escribe la velocidad");
                velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_b = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);

                lista.AddFlightPlan(plan_a);
                lista.AddFlightPlan(plan_b);


                int i = 0;
                int ciclos = 20;
                int tiempoCiclo = 10;
                double distanciaSeguridad = 10;

                while (i < ciclos)
                {
                    lista.Mover(tiempoCiclo);

                    lista.EscribeConsola();
                    if (plan_a.Conflicto(plan_b, distanciaSeguridad))
                        Console.WriteLine("Conflicto");
                    i = i + 1;
                }


                Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("Error de formato");
                Console.ReadLine();
            }
        }

        //PROVES DE LA FASE 1 
        // Si tot surt [OK] es que la Fase 1 funciona. Si surt algun [ERROR], algo no rula.
        static void ProbarFase1()
        {
            Console.WriteLine("=========== PRUEBAS FASE 1 ===========");


            FlightPlan a = new FlightPlan("A", 0, 0, 300, 400, 600);

    
            FlightPlan b = new FlightPlan("B", 0, 400, 300, 0, 600);

  
            Comprobar("GetId devuelve A", a.GetId() == "A");
            Comprobar("GetVelocidad devuelve 600", a.GetVelocidad() == 600);
            Comprobar("Posicion inicial = (0,0)", MismaPosicion(a.GetInitialPosition(), 0, 0));
            Comprobar("Posicion actual al empezar = (0,0)", MismaPosicion(a.GetCurrentPosition(), 0, 0));
            Comprobar("Posicion final = (300,400)", MismaPosicion(a.GetFinalPosition(), 300, 400));

          Comprobar("Distance entre A y B al empezar = 400", Math.Abs(a.Distance(b) - 400) < 0.001);

  
            a.Move(10);
            Comprobar("Despues de Move(10) A esta en (60,80)", MismaPosicion(a.GetCurrentPosition(), 60, 80));
            Comprobar("HasArrived es false a medio camino", a.HasArrived() == false);

 
            for (int i = 0; i < 10; i++)
            {
                a.Move(10);
            }
            Comprobar("Despues de muchos Move A esta justo en (300,400)", MismaPosicion(a.GetCurrentPosition(), 300, 400));
            Comprobar("HasArrived es true al llegar", a.HasArrived() == true);

            a.Restart();
            Comprobar("Despues de Restart A vuelve a (0,0)", MismaPosicion(a.GetCurrentPosition(), 0, 0));
            Comprobar("HasArrived es false despues de Restart", a.HasArrived() == false);

            a.SetVelocidad(300);
            Comprobar("SetVelocidad cambia la velocidad a 300", a.GetVelocidad() == 300);
            a.SetId("A2");
            Comprobar("SetId cambia el id a A2", a.GetId() == "A2");
            a.SetCurrentPosition(new Position(150, 200));
            Comprobar("SetCurrentPosition pone A en (150,200)", MismaPosicion(a.GetCurrentPosition(), 150, 200));

            Comprobar("Distance con A en (150,200) = 250", Math.Abs(a.Distance(b) - 250) < 0.001);
            a.SetFinalPosition(new Position(150, 200));
            Comprobar("Si el destino es donde ya esta, HasArrived es true", a.HasArrived() == true);
            a.SetInitialPosition(new Position(10, 20));
            a.Restart();
            Comprobar("SetInitialPosition + Restart lleva A a (10,20)", MismaPosicion(a.GetCurrentPosition(), 10, 20));

            //un avio que surt ja del desti. Ha de dir que ha arribat i el Move no ha de petar 
            FlightPlan c = new FlightPlan("C", 50, 50, 50, 50, 100);
            Comprobar("Un avion con inicio = destino ya ha llegado", c.HasArrived() == true);
            c.Move(10);
            Comprobar("Move no hace nada si ya ha llegado (sigue en (50,50))", MismaPosicion(c.GetCurrentPosition(), 50, 50));

            Console.WriteLine("======================================");
        }

        static void Comprobar(string queProbamos, bool resultado)
        {
            if (resultado)                                      
                Console.WriteLine("[OK]    " + queProbamos);    
            else                                                
                Console.WriteLine("[ERROR] " + queProbamos);    
        }

        
        static bool MismaPosicion(Position p, double x, double y)
        {
            bool mismaX = Math.Abs(p.GetX() - x) < 0.001;   
            bool mismaY = Math.Abs(p.GetY() - y) < 0.001;   
            return mismaX && mismaY;                        //nomes es la mateixa posicio si coincideixen les dues
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightPlanList lista = new FlightPlanList();

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
                
                //=========================================================================
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

                // Loop simulation (Loops + loop time)
                int i = 0;
                int loops = 20;
                double safetyDistance = 10;

                while (i < loops)
                {
                    lista.Move(loops);

                    lista.EscribeConsola();

                    if (plan_a.ConflictDetection(plan_b, safetyDistance))
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~ Alert conflict!!! ~~~~~~~~~~~~~~~~~~~~");
                    i++;
                }

                Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("**** Format error ****");
            }

           
        }
    }
}



// Tasks

// Deal with incorrect format inputs -> "Try / Catch"
// Loop simulation (Loops + loop time) -> while(...)
// Write real data with only two significant decimals -> In FlightPlan.cs ({}:F'num')

// Write a method that states whether the flight has arrived to its destionation or not
// Modify "MoverVuelo" so the flight doesn't go further from destination
// Write a method that detects when there's a conflict of security distance among two flights

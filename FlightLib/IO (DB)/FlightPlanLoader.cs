using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanLoader
    {
        //Se cargan los planes de vuelo a partir de un archivo.
        public static FlightPlanList LoadFromFile(string filePath)
        {
            FlightPlanList flightList = new FlightPlanList();
            int lineNumber = 0;

            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lineNumber++;

                        if (string.IsNullOrWhiteSpace(line)) continue;

                        string[] parts = line.Trim().Split(',');

                        if (parts.Length != 8)
                        {
                            Console.WriteLine($"[Línea {lineNumber}] Formato incorrecto: se esperan 8 campos de entrada, pero hay {parts.Length}.");
                            continue;
                        }

                        try
                        {
                            string airlineName = parts[0].Trim();
                            string id = parts[1].Trim();
                            int flightNumericalId = int.Parse(parts[2].Trim());

                            // Usar CultureInfo.InvariantCulture para evitar errores con comas decimales
                            double originX = double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture);
                            double originY = double.Parse(parts[4].Trim(), CultureInfo.InvariantCulture);
                            double finalX = double.Parse(parts[5].Trim(), CultureInfo.InvariantCulture);
                            double finalY = double.Parse(parts[6].Trim(), CultureInfo.InvariantCulture);
                            double velocidad = double.Parse(parts[7].Trim(), CultureInfo.InvariantCulture);

                            FlightPlan flight = new FlightPlan(airlineName, id, originX, originY, finalX, finalY, velocidad);
                            flightList.AddFlightPlan(flight);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($"[Línea {lineNumber}] Error de formato: {fe.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Línea {lineNumber}] Error inesperado: {ex.Message}");
                        }
                    }
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Error al acceder al archivo: {ioEx.Message}");
            }

            return flightList;
        }
    }
}

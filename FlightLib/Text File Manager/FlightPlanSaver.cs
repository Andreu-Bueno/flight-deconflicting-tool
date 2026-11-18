using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlightLib
{
    //Pasamos todos los datos cruciales de la simulación a un fichero de texto para ser capaces de retomarla en cualquier momento.
    public class FlightPlanSaver
    {
        public void SaveToFile(string filePath, FlightPlanList flightList, double safetyDistance, int looptime)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(filePath))
                {
                    string firstLine = string.Format(CultureInfo.InvariantCulture, "{0}|{1}", safetyDistance, looptime);
                    w.WriteLine(firstLine);

                    for (int i = 0; i < flightList.GetNumber(); i++)
                    {
                        FlightPlan flight = flightList.GetFlightPlan(i);

                        string line = string.Format(CultureInfo.InvariantCulture,
                                                    "{0}|{1}|{2}|{3}|{4}|{5}|{6}",
                                                    flight.GetAirlineName(),
                                                    flight.GetId(),
                                                    flight.GetCurrentPosition().GetX(),
                                                    flight.GetCurrentPosition().GetY(),
                                                    flight.GetFinalPosition().GetX(),
                                                    flight.GetFinalPosition().GetY(),
                                                    flight.GetVelocidad());

                        w.WriteLine(line);
                    }
                }
                Console.WriteLine("✅ Lista de vuelos guardada correctamente en el archivo.");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"❌ Error al guardar el archivo: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
            }
        }
    }
}

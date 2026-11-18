using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {

        List<FlightPlan> flightsList = new List<FlightPlan>();

        public int GetNumber()
        //Obtain the number of flight plans on the list flightList
        {
            return flightsList.Count;
        }

        public int AddFlightPlan(FlightPlan p)
        //Adds a flight plan to the list if possible, else shows an error message
        {
            try
            {
                flightsList.Add(p);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al añadir vuelo: {ex.Message}");
                return -1;
            }
        }

        public FlightPlan GetFlightPlan(int index)
        //returns the flight plan from the list which occupies the position that is given as the index
        {
            if (index < 0 || index >= flightsList.Count)
                return null;
            return flightsList[index];
        }

        public FlightPlan GetFlightPlanWthId(string flightId)
        //returns the flight plans from the list with an specific id given as a parameter
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                if (flightsList[i].GetId() == flightId)
                {
                    return flightsList[i];
                }
            }
            return null;
        }

        public bool FlightHasDiversion(int flightIndex)
        {
            FlightPlan flight = flightsList[flightIndex];
            return flight != null && flight.GetDiversionPoint() != null;
        }


        public void ResetDiversionPoints()
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                flightsList[i].SetDiversionPoint(null);
            }
        }

        public void ClearList()
        //Empties the list of flights to add new ones
        {
            this.flightsList.Clear();
            Console.WriteLine("The list is void now.");
        }

        public void Move(double time)
        //changes the current position of each flight with an input time
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                flightsList[i].Move(time);
            }
        }

        public void EscribeConsola()
        //uses the method "EscribeConsola" in FlightPlan to write the parameters of each flight on console
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                flightsList[i].EscribeConsola();
            }
        }

        public void UpdateFlight(FlightPlan updatedFlight)
        // Replaces the flight in the list with the one provided, if their IDs match
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                if (flightsList[i].GetId() == updatedFlight.GetId())
                {
                    Console.WriteLine($"Actualizando vuelo {updatedFlight.GetId()} en la lista...");
                    Console.WriteLine($"Antes: Velocidad={flightsList[i].GetVelocidad()}");

                    flightsList[i] = updatedFlight;
                    Console.WriteLine($"Después: Velocidad={flightsList[i].GetVelocidad()}");
                    return;
                }
            }
        }


        // Sorting algorithms

        public void SortById()
        {
            flightsList.Sort((a, b) => a.GetFlightNumericId().CompareTo(b.GetFlightNumericId()));
        }

        // Ordenar por nombre de aerolínea
        public void SortListByAirline()
        // Sort the flights by the airline name
        {
            flightsList.Sort((a, b) => string.Compare(a.GetAirlineName(), b.GetAirlineName()));
        }
        //Se obtienen todos los vuelos de una aerolínea.
        public (FlightPlanList, bool) GetFlightsOfAirline(string airlineName)
        {
            FlightPlanList list = new FlightPlanList();

            foreach (FlightPlan flight in this.flightsList)
            {
                if (flight.GetAirlineName() == airlineName)
                {
                    list.AddFlightPlan(flight.CopyFlightplan());
                }
            }

            if (list.GetNumber() == 0)
            {
                return (list, false);
            }
            else
            {
                return (list, true);
            }
        }

        // Reinicia todos los vuelos a su origen
        public void RestartAllFlights()
        // Resets all flights to their origin
        {
            foreach (var flight in flightsList)
            {
                flight.Restart();
            }
        }

        public FlightPlanList CopyFlightPlanList()
        // Returns a copy of the flight plan list, duplicating each flight plan
        {
            FlightPlanList copy = new FlightPlanList();

            foreach (var flight in this.flightsList)
            {
                copy.AddFlightPlan(flight.CopyFlightplan());
            }
            return copy;
        }
        // Las siguientes funciones se han encapsulado en esta clase para optimizar el código

        //Calcula la distancia mínima a la que se encontrarán dos vuelos que se encuentran en la posición i y j.
        public (double, double, double, double) ComputeMinDistance(int i, int j)
        {
            double YF1 = this.GetFlightPlan(i).GetFinalPosition().GetY();
            double XF1 = this.GetFlightPlan(i).GetFinalPosition().GetX();
            double Y01 = this.GetFlightPlan(i).GetOrigin().GetY();
            double X01 = this.GetFlightPlan(i).GetOrigin().GetX();
            double YF2 = this.GetFlightPlan(j).GetFinalPosition().GetY();
            double XF2 = this.GetFlightPlan(j).GetFinalPosition().GetX();
            double Y02 = this.GetFlightPlan(j).GetOrigin().GetY();
            double X02 = this.GetFlightPlan(j).GetOrigin().GetX();

            // Corrección: Usar Atan2 para evitar problemas de cuadrantes y división por cero
            double angle1 = Math.Atan2(YF1 - Y01, XF1 - X01);
            double angle2 = Math.Atan2(YF2 - Y02, XF2 - X02);

            double VX1 = this.GetFlightPlan(i).GetVelocidad() * Math.Cos(angle1);
            double VY1 = this.GetFlightPlan(i).GetVelocidad() * Math.Sin(angle1);
            double VX2 = this.GetFlightPlan(j).GetVelocidad() * Math.Cos(angle2);
            double VY2 = this.GetFlightPlan(j).GetVelocidad() * Math.Sin(angle2);

            double deltaVX = VX2 - VX1;
            double deltaVY = VY2 - VY1;
            double deltaX = X02 - X01;
            double deltaY = Y02 - Y01;

            double numerador = -(deltaVX * deltaX + deltaVY * deltaY);
            double denominador = (deltaVX * deltaVX + deltaVY * deltaVY);

            double tmin = numerador / denominador;

            if (Math.Abs(denominador) < 1e-10)
            {
                // Distancia actual es la mínima
                return (numerador, denominador, tmin, Math.Sqrt(deltaX * deltaX + deltaY * deltaY));
            }

            double dmin = Math.Sqrt(Math.Pow(deltaVX * tmin + deltaX, 2) + Math.Pow(deltaVY * tmin + deltaY, 2));

            return (numerador, denominador, tmin, dmin);
        }
        //Se comprueba si hay conflicto entre dos aviones mediante el método anterior y comparando el resultado con una distancia de seguridad.
        public ConflictDetectionResult DetectConflictsBetween(int i, int j, double safetyDistance)
        {
            var flight1 = GetFlightPlan(i);
            var flight2 = GetFlightPlan(j);

            var (numerador, denominador, tmin, dmin) = ComputeMinDistance(i, j);

            bool isConflict = dmin <= safetyDistance * 2;
            bool sameVelocity = Math.Abs(denominador) < 1e-10;

            return new ConflictDetectionResult
            {
                IsConflict = isConflict,
                SameVelocity = sameVelocity,
                MinDistance = dmin,
                TimeToConflict = tmin
            };
        }
        //Se repite la función las veces necesarias (bucle) para detectar todos los posibles contrarios.
        public List<int> DetectAllConflicts(double safetyDistance)
        {
            List<int> conflictingFlights = new List<int>();

            for (int i = 0; i < GetNumber(); i++)
            {
                for (int j = i + 1; j < GetNumber(); j++)
                {
                    var result = DetectConflictsBetween(i, j, safetyDistance);
                    if (result.IsConflict)
                    {
                        if (!conflictingFlights.Contains(i)) conflictingFlights.Add(i);
                        if (!conflictingFlights.Contains(j)) conflictingFlights.Add(j);
                    }
                }
            }

            return conflictingFlights;
        }
        //Detecta y solventa los conflictos
        public ConflictResult DetectAndHandleConflicts(double safetyDistance)
        {
            List<int> conflictingFlights = new List<int>();
            FlightPlanList conflictsList = new FlightPlanList();
            bool conflictDetected = false;

            for (int i = 0; i < this.GetNumber(); i++)
            {
                for (int j = i + 1; j < this.GetNumber(); j++)
                {
                    if (this.GetFlightPlan(i).ConflictDetection(this.GetFlightPlan(j), safetyDistance))
                    {
                        if (!conflictingFlights.Contains(i)) conflictingFlights.Add(i);
                        if (!conflictingFlights.Contains(j)) conflictingFlights.Add(j);
                        conflictDetected = true;
                    }
                }
            }

            foreach (int index in conflictingFlights)
            {
                conflictsList.AddFlightPlan(this.GetFlightPlan(index));
            }

            return new ConflictResult
            {
                ConflictingFlightIndices = conflictingFlights,
                ConflictsList = conflictsList,
                AnyConflict = conflictDetected
            };
        }

        public int GetIndexById(string flightId)
        {
            for (int i = 0; i < flightsList.Count; i++)
            {
                if (flightsList[i].GetId() == flightId)
                {
                    return i;
                }
            }
            return -1; // No encontrado
        }
    }
    //Se encapsulan los resultados del conflicto
    public struct ConflictDetectionResult
    {
        public bool IsConflict { get; set; }
        public bool SameVelocity { get; set; }
        public double MinDistance { get; set; }
        public double TimeToConflict { get; set; }
    }

    public class ConflictResult
    {
        public List<int> ConflictingFlightIndices { get; set; }
        public FlightPlanList ConflictsList { get; set; }
        public bool AnyConflict { get; set; }
    }
}

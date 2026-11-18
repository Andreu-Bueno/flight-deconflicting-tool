using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib.Utils
{
    public class ConflictResolver
    {
        //Todos los métodos usados en esta clase se realizan dentro de esta misma para optimizar al máximo el código
        //y poder usar estos métodos directamente en los forms para tener la menor cantidad de líneas de código.
        private FlightPlanList flights;
        private FlightPlanList resolvedFlights;
        private double safetyDistance;
        private List<double> originalVelocities;
        private List<Tuple<int, int>> unresolvedConflicts = new List<Tuple<int, int>>();
        //Constructor
        public ConflictResolver(FlightPlanList flights, FlightPlanList deconflictedflights, double safetyDistance)
        {
            this.flights = flights;
            this.resolvedFlights = deconflictedflights;
            this.safetyDistance = safetyDistance;
            StoreOriginalVelocities();
        }

        private void StoreOriginalVelocities()
        {
            originalVelocities = new List<double>();
            for (int i = 0; i < flights.GetNumber(); i++)
            {
                originalVelocities.Add(flights.GetFlightPlan(i).GetVelocidad());
            }
        }
        //Resuelve todos los conflictos a la vez.
        public void ResolveAllConflicts()
        {
            int maxIterations = 500;
            int iteration = 0;
            bool conflictsRemaining;

            do
            {
                conflictsRemaining = false;
                iteration++;

                // Detectar todos los conflictos actuales
                List<Tuple<int, int>> conflictPairs = DetectAllConflicts();

                if (conflictPairs.Count == 0)
                    break; // No hay más conflictos

                // Ordenar conflictos por prioridad (aquí por tiempo hasta conflicto)
                conflictPairs = OrderConflictsByPriority(conflictPairs);

                foreach (var pair in conflictPairs)
                {
                    // Saltar conflictos ya marcados como no resolubles
                    if (unresolvedConflicts.Contains(pair))
                        continue;

                    ResolutionResult result = TryResolveConflict(pair.Item1, pair.Item2);

                    if (result == ResolutionResult.PartialSuccess || result == ResolutionResult.Success)
                    {
                        // Después de resolver, volver a verificar todos los conflictos
                        conflictsRemaining = true;
                        break;
                    }
                    else if (result == ResolutionResult.Unresolvable)
                    {
                        // Marcar estos vuelos como no resolubles
                        unresolvedConflicts.Add(pair);
                        conflictsRemaining = true; // Seguir intentando con otros conflictos
                    }
                }

            } while (conflictsRemaining && iteration < maxIterations);
        }
        //Detecta todos los posibles conflictos
        private List<Tuple<int, int>> DetectAllConflicts()
        {
            List<Tuple<int, int>> conflicts = new List<Tuple<int, int>>();

            for (int i = 0; i < this.resolvedFlights.GetNumber(); i++)
            {
                for (int j = i + 1; j < resolvedFlights.GetNumber(); j++)
                {
                    // Saltar pares ya marcados como no resolubles
                    if (unresolvedConflicts.Contains(new Tuple<int, int>(i, j)))
                        continue;

                    if (CheckConflict(resolvedFlights.GetFlightPlan(i), resolvedFlights.GetFlightPlan(j)))
                    {
                        conflicts.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return conflicts;
        }
        //Detecta si hay conflicto entre dos planes de vuelo, útil para confirmar que los cambios de velocidad aplicados son útiles.
        private bool CheckConflict(FlightPlan flight1, FlightPlan flight2)
        {
            double V1 = flight1.GetVelocidad();
            double V2 = flight2.GetVelocidad();

            double YF1 = flight1.GetFinalPosition().GetY();
            double XF1 = flight1.GetFinalPosition().GetX();
            double Y01 = flight1.GetOrigin().GetY();
            double X01 = flight1.GetOrigin().GetX();
            double YF2 = flight2.GetFinalPosition().GetY();
            double XF2 = flight2.GetFinalPosition().GetX();
            double Y02 = flight2.GetOrigin().GetY();
            double X02 = flight2.GetOrigin().GetX();

            double angle1 = Math.Atan2(YF1 - Y01, XF1 - X01);
            double angle2 = Math.Atan2(YF2 - Y02, XF2 - X02);

            double VX1 = V1 * Math.Cos(angle1);
            double VY1 = V1 * Math.Sin(angle1);
            double VX2 = V2 * Math.Cos(angle2);
            double VY2 = V2 * Math.Sin(angle2);

            double deltaVX = VX2 - VX1;
            double deltaVY = VY2 - VY1;
            double deltaX = X02 - X01;
            double deltaY = Y02 - Y01;

            double numerador = -(deltaVX * deltaX + deltaVY * deltaY);
            double denominador = (deltaVX * deltaVX + deltaVY * deltaVY);

            if (denominador == 0)
            {
                // Vuelos con misma velocidad y dirección
                double currentDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                return currentDistance < safetyDistance * 2;
            }

            double tmin = numerador / denominador;
            if (tmin < 0) tmin = 0;

            double dmin = Math.Sqrt(Math.Pow(deltaVX * tmin + deltaX, 2) + Math.Pow(deltaVY * tmin + deltaY, 2));

            return dmin < safetyDistance * 2;
        }


        private List<Tuple<int, int>> OrderConflictsByPriority(List<Tuple<int, int>> conflicts)
        {
            // Ordenar por tiempo hasta el conflicto (los que ocurran primero tienen prioridad)
            return conflicts.OrderBy(pair =>
            {
                var flight1 = resolvedFlights.GetFlightPlan(pair.Item1);
                var flight2 = resolvedFlights.GetFlightPlan(pair.Item2);
                return CalculateTimeToConflict(flight1, flight2);
            }).ToList();
        }

        //Calcula el tiempo que queda hasta la colisión.
        private double CalculateTimeToConflict(FlightPlan flight1, FlightPlan flight2)
        {
            double V1 = flight1.GetVelocidad();
            double V2 = flight2.GetVelocidad();

            double YF1 = flight1.GetFinalPosition().GetY();
            double XF1 = flight1.GetFinalPosition().GetX();
            double Y01 = flight1.GetOrigin().GetY();
            double X01 = flight1.GetOrigin().GetX();
            double YF2 = flight2.GetFinalPosition().GetY();
            double XF2 = flight2.GetFinalPosition().GetX();
            double Y02 = flight2.GetOrigin().GetY();
            double X02 = flight2.GetOrigin().GetX();

            double angle1 = Math.Atan2(YF1 - Y01, XF1 - X01);
            double angle2 = Math.Atan2(YF2 - Y02, XF2 - X02);

            double VX1 = V1 * Math.Cos(angle1);
            double VY1 = V1 * Math.Sin(angle1);
            double VX2 = V2 * Math.Cos(angle2);
            double VY2 = V2 * Math.Sin(angle2);

            double deltaVX = VX2 - VX1;
            double deltaVY = VY2 - VY1;
            double deltaX = X02 - X01;
            double deltaY = Y02 - Y01;

            double numerador = -(deltaVX * deltaX + deltaVY * deltaY);
            double denominador = (deltaVX * deltaVX + deltaVY * deltaVY);

            if (denominador == 0)
            {
                // Vuelos con misma velocidad y dirección
                double currentDistance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                return currentDistance < safetyDistance * 2 ? 0 : double.MaxValue;
            }

            double tmin = numerador / denominador;
            return tmin < 0 ? double.MaxValue : tmin;
        }


        //Intenta resolver el conflicto mediante cambios de velocidad.
        private ResolutionResult TryResolveConflict(int i, int j)
        {
            FlightPlan flight1 = resolvedFlights.GetFlightPlan(i);
            FlightPlan flight2 = resolvedFlights.GetFlightPlan(j);

            double originalV1 = flight1.GetVelocidad();
            double originalV2 = flight2.GetVelocidad();

            // Intentar diferentes estrategias de resolución
            var strategies = new List<Func<FlightPlan, FlightPlan, ResolutionResult>>()
            {
                ResolveByReducingFirstFlightSpeed,
                ResolveByIncreasingFirstFlightSpeed,
                ResolveByReducingSecondFlightSpeed,
                ResolveByIncreasingSecondFlightSpeed,
                ResolveByCombinedAdjustment
            };

            ResolutionResult bestResult = ResolutionResult.Unresolvable;
            double bestV1 = originalV1;
            double bestV2 = originalV2;
            int newConflictsCount = int.MaxValue;

            foreach (var strategy in strategies)
            {
                // Restaurar velocidades originales antes de probar cada estrategia
                flight1.SetVelocidad(originalV1);
                flight2.SetVelocidad(originalV2);

                var result = strategy(flight1, flight2);

                if (result != ResolutionResult.Unresolvable)
                {
                    // Verificar cuántos nuevos conflictos crea este ajuste
                    int currentNewConflicts = CountNewConflictsAfterResolution(i, j);

                    // Si es mejor que lo que teníamos antes, guardamos esta solución
                    if (currentNewConflicts < newConflictsCount)
                    {
                        newConflictsCount = currentNewConflicts;
                        bestResult = currentNewConflicts == 0 ? ResolutionResult.Success : ResolutionResult.PartialSuccess;
                        bestV1 = flight1.GetVelocidad();
                        bestV2 = flight2.GetVelocidad();
                    }
                }
            }

            // Aplicar la mejor solución encontrada
            flight1.SetVelocidad(bestV1);
            flight2.SetVelocidad(bestV2);

            return bestResult;
        }
        //Busca si hay conflictos después de la resolución
        private int CountNewConflictsAfterResolution(int resolvedI, int resolvedJ)
        {
            int count = 0;

            // Verificar si los vuelos ajustados entran en conflicto con otros
            for (int k = 0; k < resolvedFlights.GetNumber(); k++)
            {
                if (k != resolvedI && k != resolvedJ)
                {
                    if (CheckConflict(resolvedFlights.GetFlightPlan(resolvedI),
                                    resolvedFlights.GetFlightPlan(k)))
                    {
                        count++;
                    }
                    if (CheckConflict(resolvedFlights.GetFlightPlan(resolvedJ),
                                    resolvedFlights.GetFlightPlan(k)))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        //Resuelve el conflicto reduciendo la velocidad del primer vuelo
        private ResolutionResult ResolveByReducingFirstFlightSpeed(FlightPlan flight1, FlightPlan flight2)
        {
            double originalV1 = flight1.GetVelocidad();
            double minV1 = originalV1 * 0.5;
            double step = (originalV1 - minV1) / 10.0;

            for (double v1 = originalV1; v1 >= minV1; v1 -= step)
            {
                flight1.SetVelocidad(v1);
                if (!CheckConflict(flight1, flight2))
                {
                    return ResolutionResult.Success;
                }
            }
            return ResolutionResult.Unresolvable;
        }
        //Resuelve el conflicto mediante un incremento en la velocidad del primer vuelo.
        private ResolutionResult ResolveByIncreasingFirstFlightSpeed(FlightPlan flight1, FlightPlan flight2)
        {
            double originalV1 = flight1.GetVelocidad();
            double maxV1 = originalV1 * 2.0;
            double step = (maxV1 - originalV1) / 10.0;

            for (double v1 = originalV1; v1 <= maxV1; v1 += step)
            {
                flight1.SetVelocidad(v1);
                if (!CheckConflict(flight1, flight2))
                {
                    return ResolutionResult.Success;
                }
            }
            return ResolutionResult.Unresolvable;
        }
        //Resuelve el conflicto reduciendo la velocidad del segundo vuelo
        private ResolutionResult ResolveByReducingSecondFlightSpeed(FlightPlan flight1, FlightPlan flight2)
        {
            double originalV2 = flight2.GetVelocidad();
            double minV2 = originalV2 * 0.5;
            double step = (originalV2 - minV2) / 10.0;

            for (double v2 = originalV2; v2 >= minV2; v2 -= step)
            {
                flight2.SetVelocidad(v2);
                if (!CheckConflict(flight1, flight2))
                {
                    return ResolutionResult.Success;
                }
            }
            return ResolutionResult.Unresolvable;
        }
        //Resuelve el conflicto mediante un incremento en la velocidad del segundo vuelo.
        private ResolutionResult ResolveByIncreasingSecondFlightSpeed(FlightPlan flight1, FlightPlan flight2)
        {
            double originalV2 = flight2.GetVelocidad();
            double maxV2 = originalV2 * 2.0;
            double step = (maxV2 - originalV2) / 10.0;

            for (double v2 = originalV2; v2 <= maxV2; v2 += step)
            {
                flight2.SetVelocidad(v2);
                if (!CheckConflict(flight1, flight2))
                {
                    return ResolutionResult.Success;
                }
            }
            return ResolutionResult.Unresolvable;
        }
        //Resuelve mediante un ajuste en todos los vuelos.
        private ResolutionResult ResolveByCombinedAdjustment(FlightPlan flight1, FlightPlan flight2)
        {
            double originalV1 = flight1.GetVelocidad();
            double originalV2 = flight2.GetVelocidad();

            // Intentar combinaciones de ajustes
            for (int i = 0; i <= 10; i++)
            {
                double v1 = originalV1 * (0.5 + (i * 0.05)); // Varía entre 50% y 100% de V1
                for (int j = 0; j <= 10; j++)
                {
                    double v2 = originalV2 * (0.5 + (j * 0.05)); // Varía entre 50% y 100% de V2

                    flight1.SetVelocidad(v1);
                    flight2.SetVelocidad(v2);

                    if (!CheckConflict(flight1, flight2))
                    {
                        return ResolutionResult.Success;
                    }
                }
            }

            return ResolutionResult.Unresolvable;
        }

        private enum ResolutionResult
        {
            Success,        // Conflicto resuelto sin nuevos conflictos
            PartialSuccess, // Conflicto resuelto pero creó otros conflictos
            Unresolvable    // No se pudo resolver el conflicto
        }
    }
}

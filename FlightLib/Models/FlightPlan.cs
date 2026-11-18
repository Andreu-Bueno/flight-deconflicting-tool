using FlightLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos
        string airlineName; // Nombre del operador
        string id; // identificador
        int flightNumericId; // ID númerico
        Position origin; // Posición inicial
        Position currentPosition; // posicion actual
        Position diversionPoint = null;
        List<Segment> trajectory = null;
        Position finalPosition; // posicion final
        double velocidad;

        // Constructores
        public FlightPlan(string airline, string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.airlineName = airline;
            this.id = id;
            //this.flightNumericId = flightNumericId;
            this.origin = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;

            this.trajectory = new List<Segment>();
        }

        // Metodos

        //  --------------------------------------------------Setters y Getters----------------------------------------------------------
        public void SetAirlineName(string airlineName)
        //setter del atributo airlineName (nombre operador)
        { this.airlineName = airlineName; }
        public void SetId(string id)
        //setter del atributo id (identificador)
        { this.id = id; }
        public void SetFlightNumericId(int flightNumericId)
        //setter del atributo flightNumericId (id númerico del vuelo)
        { this.flightNumericId = flightNumericId; }
        public void SetOrigin(Position origin)
        //setter del atributo origin Position
        { this.origin = origin; }
        public void SetCurrentPosition(Position currentPosition)
        //setter del atributo current Position
        { this.currentPosition = currentPosition; }
        public void SetDiversionPoint(Position diversionPoint)
        //setter del atributo diversion Position
        { this.diversionPoint = diversionPoint; }
        public void AddSegmentsWhenDiversion(Position to)
        //setter del atributo trajectory. Añade los waypoints del vuelo cuando se le asigna un desvio.
        {
            this.trajectory.Add(new Segment(this.currentPosition, to));
            this.trajectory.Add(new Segment(to, this.finalPosition));
        }
        public void SetFinalPosition(Position finalPostion)
        //setter del atributo final Position
        { this.finalPosition = finalPostion; }
        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public string GetAirlineName()
        //getter del atributo airlineName (nombre operador)
        { return this.airlineName; }
        public double GetVelocidad()
        //getter del atributo velocidad
        { return velocidad; }
        public string GetId()
        //getter del atributo id (identificador)
        { return id; }
        public int GetFlightNumericId()
        //getter del atributop flightNumericId (identificador numerico)
        { return this.flightNumericId; }
        public Position GetOrigin()
        //getter del atributo origin
        { return origin; }
        public Position GetCurrentPosition()
        //getter del atributo current Position
        { return currentPosition; }
        public Position GetDiversionPoint()
        //getter del atributo diversion Position
        { return this.diversionPoint; }
        public List<Segment> GetPredictedTrajectories()
        //getter del atributo trajectory. Devuelve la lista de la posición de los giros en la trayectoria
        { return this.trajectory; }
        public Position GetFinalPosition()
        //getter del atributo final Position
        { return finalPosition; }

        //  --------------------------------------------------Setters y Getters----------------------------------------------------------

        /// <summary>
        ///  Devuelve la distancia entre dos planes de vuelo teniendo en cuenta sus posiciones actuales
        /// </summary>
        /// <param name="plan"></param>
        /// <returns> A the distance between two flights </returns>
        public double Distance(FlightPlan plan)
        {
            double distanceFlightPlan = this.currentPosition.Distancia(plan.currentPosition);
            return distanceFlightPlan;
        }

        public void ClearPredictedTrajectories()
        //limpia el atributo trajectory para poder añadir la siguiente desviación
        {
            this.trajectory.Clear();
        }


        /// <summary>
        /// Changes the current position of an object flight with an input time. If time is high each step
        /// of movement will be large.
        /// </summary>
        /// <param name="time"></param>
        public void Move(double time)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = time * this.velocidad / 60;
            const double tolerance = 1e-6;

            Position objective;

            if (this.diversionPoint != null && !currentPosition.Equals(diversionPoint))
            {
                objective = this.diversionPoint;
            }
            else
            {
                objective = this.finalPosition;
            }


            //Calculamos las distancias en x e y
            double dx = (objective.GetX() - currentPosition.GetX());
            double dy = (objective.GetY() - currentPosition.GetY());
            double hipotenusa = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));


            if (hipotenusa < tolerance)
            {
                // Ya llegamos al objetivo
                currentPosition = objective;

                if (diversionPoint != null && objective.GetX() == diversionPoint.GetX() && objective.GetY() == diversionPoint.GetY())
                {
                    Console.WriteLine($"({this.currentPosition.GetX()}, {this.currentPosition.GetY()})");
                    diversionPoint = null;
                }

                // Si el objetivo era el punto de desviación, después se moverá al destino final en la próxima llamada
                return;
            }

            double coseno = (objective.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (objective.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            // Modify "MoverVuelo" so the flight doesn't go further from destination
            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
            {
                currentPosition = objective;

                if (diversionPoint != null && objective.GetX() == diversionPoint.GetX() && objective.GetY() == diversionPoint.GetY())
                {
                    Console.WriteLine($"({this.currentPosition.GetX()}, {this.currentPosition.GetY()})");
                    diversionPoint = null;
                }
            }
        }



        // Write a method that states whether the flight has arrived to its destionation or not
        public bool HasArrived()
        {
            bool result = false;
            if (currentPosition.Equals(finalPosition))
                result = true;
            return result;
        }

        //Restarts the position of each plane at the beginning of the simulation

        public void Restart()
        {
            this.currentPosition = this.origin;
        }


        /// <summary>
        /// ---Says if there is a conflict between two flights 
        /// (i.e., the distance among them is smaller than x2 safety distance)---
        /// </summary>
        /// <param name="flight"></param>
        /// <param name="SafetyDistance"></param>
        /// <returns>Returns true if the distance is smaller than x2 safety distance, false otherwise.</returns>
        public bool ConflictDetection(FlightPlan b, double SafetyDistance)
        {
            bool conflict = false;

            if (this.currentPosition.Distancia(b.currentPosition) < SafetyDistance * 2)
                conflict = true;

            return conflict;
        }


        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Aerolínea: {0}", airlineName);
            Console.WriteLine("Identificador: {0}", id);
            Console.WriteLine("ID numérico: {0}", flightNumericId);

            // Write reala data with only two significant decimals
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            if (this.HasArrived())
                Console.WriteLine("The flight is in the destination");
            else
                Console.WriteLine("The flight is not in the destination");

            Console.WriteLine("******************************");
        }


        /// <summary>
        /// Updates the current flight plan with data from another flight plan.
        /// </summary>
        /// <param name="any">The flight plan from which to copy the data.</param>
        public void UpdateFrom(FlightPlan any)
        {
            this.SetOrigin(any.GetOrigin());
            this.SetCurrentPosition(any.GetCurrentPosition());
            this.SetFinalPosition(any.GetFinalPosition());
            this.SetVelocidad(any.GetVelocidad());
        }

        /// <summary>
        /// Creates a copy of the current flight plan instance.
        /// </summary>
        /// <returns>A new <see cref="FlightPlan"/> object with the same data.</returns>
        public FlightPlan CopyFlightplan()
        {

            FlightPlan copy = new FlightPlan(this.airlineName, this.id, this.currentPosition.GetX(), this.currentPosition.GetY(),
                                             this.finalPosition.GetX(), this.finalPosition.GetY(), this.velocidad);

            if (this.diversionPoint != null)
            {
                copy.SetDiversionPoint(this.diversionPoint.CopyPosition());
            }

            return copy;
        }
    }
}

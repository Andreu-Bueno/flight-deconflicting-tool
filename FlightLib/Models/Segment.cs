using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib.Models
{
    public class Segment
    {
        //Atributos
        public Position start { get; private set; }
        public Position end { get; private set; }
        //Constructor
        public Segment(Position start, Position end)
        {
            this.start = start;
            this.end = end;
        }
        //Getters de los atributos
        public Position GetStart()
        {
            return this.start;
        }

        public Position GetEnd()
        {
            return this.end;
        }
        //Calcula la longitud del segmento con los dos puntos, el inicial y el final, aprovecha la función distancua de la clase position.
        public double Length()
        {
            return this.start.Distancia(this.end);
        }
        //Comprueba si un punto esta dentro de un segmento.
        public bool Contains(Position p, double tolerance = 1e-6)
        {
            double totalDist = this.Length();
            double dist1 = start.Distancia(p);
            double dist2 = p.Distancia(end);

            return Math.Abs((dist1 + dist2) - totalDist) < tolerance;
        }

        //Retorna un boleano en función de si el avión ha pasado ya por un cierto punto o no.
        public bool HasPassed(Position current)
        {
            double dx = this.end.GetX() - this.start.GetX();
            double dy = this.end.GetY() - this.start.GetY();
            double lenth2 = dx * dx + dy * dy;

            if (lenth2 == 0) return false;

            double px = current.GetX() - this.start.GetX();
            double py = current.GetY() - this.start.GetY();

            double dot = (px * px + py * py) / lenth2;

            return dot > 1.0;
        }
        //Obtiene el vector de dirección del aeronave teniendo en cuenta que no se vuelva a cambiar el rumbo.
        public Position GetDirectionVector()
        {
            return new Position(this.end.GetX() - this.start.GetX(), this.end.GetY() - this.end.GetY());
        }

    }
}

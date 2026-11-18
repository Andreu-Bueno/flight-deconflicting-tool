using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Globalization;
using System.Threading;
using System.Reflection.Emit;

namespace FlightLib
{
    public class FlightsHistoricList
    {
        private Stack<FlightPlanList> positions = new Stack<FlightPlanList>();

        private Stack<FlightPlanList> undoneStack = new Stack<FlightPlanList>();

        public int GetNumber()
        //Obtain the number of elements in the 'position' Stack
        {
            return positions.Count;
        }

        public int AddFlightsList(FlightPlanList list)
        // Adds a copy of the flight list to the history stack and clears the redo stack
        {
            try
            {
                positions.Push(list.CopyFlightPlanList());
                undoneStack.Clear();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar las posiciones: {ex.Message}");
                return -1;
            }
        }

        // Methood to go backwards in simulation
        public FlightPlanList GetCurrentPosition()
        // Obtains the current position of the flight, peeking the Stack of positions
        {
            if (positions.Count > 0)
                return positions.Peek(); // Solo mira, no elimina
            return null;
        }

        public FlightPlanList BackwardsPosition()
        //Moves the flights to the previous position by popping the position Stack
        {
            if (positions.Count <= 1) // No podemos retroceder más allá del primer elemento
                return null;

            FlightPlanList current = positions.Pop();
            undoneStack.Push(current); // Guardar en el stack de "deshechos"

            return positions.Peek(); // Devolver la posición anterior (sin eliminarla)
        }

        public List<FlightPlanList> GetAllHistory()
        //Method that returns a list of the positions in a chronological order
        {
            return new List<FlightPlanList>(positions.Reverse()); // Convertir a lista en orden cronológico
        }
    }
}

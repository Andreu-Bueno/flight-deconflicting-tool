using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib.Text_File_Manager
{
    public class TextFileManager
    {
        //Leemos el fichero txt creado en FlightPlanSaver para retomar nuestra simulación justo dónde la habíamos dejado anteriormente.
        public (FlightPlanList, List<(string, string)>, double, int) ReadFile(string fichero)
        //Reads flight plan data from a text file given as a parameter and returns a list of flight plans.
        {
            FlightPlanList planes = new FlightPlanList();
            List<(string, string)> errorsList = new List<(string, string)>();
            double safetyDistance = 0;
            int loopTime = 0;
            int index = 0; // Determinar qué línea tiene errores


            try
            {
                using (StreamReader r = new StreamReader(fichero))
                {
                    string firstLine = r.ReadLine();
                    string[] trozos1 = firstLine.Split('|');
                    if (trozos1.Length == 2)
                    {
                        safetyDistance = Convert.ToDouble(trozos1[0]);
                        loopTime = Convert.ToInt32(trozos1[1]);
                    }
                    else
                    {
                        errorsList.Add(("Line 1", "Error: Missing data. No safety distance nor loop time are defined."));
                    }

                    string linea;
                    while ((linea = r.ReadLine()) != null)
                    {
                        index++;

                        if (string.IsNullOrEmpty(linea) || string.IsNullOrWhiteSpace(linea))
                            continue;


                        string[] trozos2 = linea.Trim().Split('|');

                        try
                        {

                            // Validar que hay suficientes elementos
                            if (trozos2.Length < 7)
                            {
                                errorsList.Add(("Line " + Convert.ToString(index), "Missing data (there were expected 7 arguments)"));
                                continue;
                            }


                            double cpx = DataValidation.ValidateNum<double>(trozos2[2], 0, 1000, "coordenada X de la entrada al sector");
                            double cpy = DataValidation.ValidateNum<double>(trozos2[3], 0, 1000, "coordenada Y de la entrada al sector");
                            double fpx = DataValidation.ValidateNum<double>(trozos2[4], -100, 1000, "coordenada X salida del sector");
                            double fpy = DataValidation.ValidateNum<double>(trozos2[5], -100, 1000, "coordenada Y salida del sector");
                            double speed = DataValidation.ValidateNum<double>(trozos2[6], 15, 150, "velocidad");

                            FlightPlan plan = new FlightPlan(trozos2[0], trozos2[1],cpx, cpy, fpx, fpy, speed);
                            planes.AddFlightPlan(plan);
                        }
                        catch (FormatException ex)
                        {
                            errorsList.Add(("Line " + Convert.ToString(index), $"Format error: {ex.Message} | Some data is incorrect"));
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            errorsList.Add(("Line " + Convert.ToString(index), $"Value out of range: {ex.Message} | There is some data missing."));
                        }
                        catch (Exception ex)
                        {
                            errorsList.Add(("Line " + Convert.ToString(index), $"Unexpected error: {ex.Message}"));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                errorsList.Add(("Code error 0:", "File not found"));
            }
            catch (IndexOutOfRangeException ex)
            {
                errorsList.Add(("Code error 0:", $"Error reading file: {ex.Message}"));
            }
            return (planes, errorsList, safetyDistance, loopTime);
        }
    }
}

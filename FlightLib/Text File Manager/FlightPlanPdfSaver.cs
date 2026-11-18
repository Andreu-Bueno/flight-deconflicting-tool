using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.util;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharpFont = iTextSharp.text.Font;
using PdfImage = iTextSharp.text.Image;
using DrawingImage = System.Drawing.Image;
using System.Diagnostics.Contracts;
using FlightLib.IO;
using System.Data;





namespace FlightLib.Text_File_Manager
{
    public class FlightPlanPdfSaver
    {
        //Guarda en un pdf los datos de una simulación, similar a FlightPlanSaver que trabaja con un txt pero con unos acabados
        //mejor conseguidos y una estética más profesional.
        public void SaveToPdf(string filePath, FlightPlanList flightList, double safetyDistance, int loopTime)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Fuentes compatibles con iTextSharp
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);

                    // Título
                    doc.Add(new Paragraph("Flight Simulation Summary", titleFont));
                    doc.Add(new Paragraph(" "));

                    doc.Add(new Paragraph($"Generation date: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", normalFont));
                    doc.Add(new Paragraph(" "));

                    // Datos generales
                    doc.Add(new Paragraph($"Safety Distance: {safetyDistance.ToString(CultureInfo.InvariantCulture)}", normalFont));
                    doc.Add(new Paragraph($"Simulation step (loopTime): {loopTime}", normalFont));
                    doc.Add(new Paragraph($"Total flights: {flightList.GetNumber()}", normalFont));
                    doc.Add(new Paragraph(" "));

                    // Tabla con 8 columnas
                    PdfPTable table = new PdfPTable(8);
                    table.WidthPercentage = 100;

                    table.AddCell("Logo");
                    table.AddCell("Airline");
                    table.AddCell("ID");
                    table.AddCell("X Origin");
                    table.AddCell("Y Origin");
                    table.AddCell("X Final");
                    table.AddCell("Y Final");
                    table.AddCell("Velocity");


                    for (int i = 0; i < flightList.GetNumber(); i++)
                    {
                        FlightPlan flight = flightList.GetFlightPlan(i);
                        string airlineName = flight.GetAirlineName();
                        string airlineKey = airlineName.Replace(" ", "_");

                        // Imagen desde Resources
                        PdfPCell imageCell;

                        try
                        {
                            iTextSharp.text.Image logo = null;
                            System.Drawing.Image resImg = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(airlineKey);

                            if (resImg != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    resImg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    logo = iTextSharp.text.Image.GetInstance(ms.ToArray());

                                    float maxWidth = 60f;
                                    float maxHeight = 40f;

                                    float width = logo.Width;
                                    float height = logo.Height;

                                    float ratioX = maxWidth / width;
                                    float ratioY = maxHeight / height;

                                    float ratio = Math.Min(ratioX, ratioY);

                                    logo.ScaleAbsolute(width * ratio, height * ratio);
                                }

                                imageCell = new PdfPCell(logo, false);
                            }
                            else
                            {
                                imageCell = new PdfPCell(new Phrase("No logo"));
                                Console.WriteLine($"⚠️ No se encontró el logo para: {airlineKey}");
                            }
                        }
                        catch (Exception ex)
                        {
                            imageCell = new PdfPCell(new Phrase("Error logo"));
                            Console.WriteLine($"❌ Error cargando logo para {airlineKey}: {ex.Message}");
                        }

                        imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        imageCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        imageCell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(imageCell);

                        // Nueva celda con el nombre de la aerolínea
                        PdfPCell airlineNameCell = new PdfPCell(new Phrase(airlineName, normalFont));
                        airlineNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        airlineNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        airlineNameCell.Border = PdfPCell.NO_BORDER;
                        table.AddCell(airlineNameCell);

                        // Resto de datos
                        table.AddCell(flight.GetId());
                        table.AddCell(flight.GetCurrentPosition().GetX().ToString(CultureInfo.InvariantCulture));
                        table.AddCell(flight.GetCurrentPosition().GetY().ToString(CultureInfo.InvariantCulture));
                        table.AddCell(flight.GetFinalPosition().GetX().ToString(CultureInfo.InvariantCulture));
                        table.AddCell(flight.GetFinalPosition().GetY().ToString(CultureInfo.InvariantCulture));
                        table.AddCell(flight.GetVelocidad().ToString(CultureInfo.InvariantCulture));
                    }

                    doc.Add(table);
                    doc.Close();
                }

                Console.WriteLine("✅ PDF creado correctamente.");
            }
            catch (DocumentException docEx)
            {
                Console.WriteLine($"❌ Error al generar el documento PDF: {docEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"❌ Error de archivo: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
            }
        }
    }
}
using AnalisisDGII.BL.Classes;
using AnalisisDGII.DL.Data;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.BL.RecaudacionEfectiva
{
    public class RecaudacionEfectivaService
    {
        public RecaudacionEfectivaData DL = new RecaudacionEfectivaData();
        public ConceptData conceptData = new ConceptData();
        public SubConceptData subConceptData = new SubConceptData();
        public void CargarCSV(string filepath)
        {
            try
            {
                using (StreamReader fileStream = new StreamReader(filepath))
                {
                    string headerline = fileStream.ReadLine();
                    string line;
                    int rowIndex = 1;
                    int Year;
                    decimal amount;
                    //Read every line until the row comes up null
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        var rowInserted = new CASHCOLLECTION();
                        var row = line.Split(';');
                        string errorMessage = $"row {rowIndex} has ";

                        rowInserted.ConceptID = conceptData.CreateIfNotExists(row[0].ToString());
                        rowInserted.SubConceptID = subConceptData.CreateIfNotExists(row[1].ToString());

                        var yearConversionPassed = int.TryParse(row[2].ToString(), out Year);
                        if (yearConversionPassed)
                        {
                            rowInserted.CollectionYear = Year;
                        }

                        var month = row[3].ToString();
                        switch (month.Trim())
                        {
                            case "Enero":
                                rowInserted.MonthID = (int)Months.Enero;
                                break;
                            case "Febrero":
                                rowInserted.MonthID = (int)Months.Febrero;
                                break;
                            case "Marzo":
                                rowInserted.MonthID = (int)Months.Marzo;
                                break;
                            case "Abril":
                                rowInserted.MonthID = (int)Months.Abril;
                                break;
                            case "Mayo":
                                rowInserted.MonthID = (int)Months.Mayo;
                                break;
                            case "Junio":
                                rowInserted.MonthID = (int)Months.Junio;
                                break;
                            case "Julio":
                                rowInserted.MonthID = (int)Months.Julio;
                                break;
                            case "Agosto":
                                rowInserted.MonthID = (int)Months.Mayo;
                                break;
                            case "Septiembre":
                                rowInserted.MonthID = (int)Months.Mayo;
                                break;
                            case "Octubre":
                                rowInserted.MonthID = (int)Months.Octubre;
                                break;
                            case "Noviembre":
                                rowInserted.MonthID = (int)Months.Noviembre;
                                break;
                            case "Diciembre":
                                rowInserted.MonthID = (int)Months.Diciembre;
                                break;
                            default:
                                break;
                        }

                        var amountConversionPassed = decimal.TryParse(row[4].ToString(), out amount);
                        if (yearConversionPassed)
                        {
                            rowInserted.AmountCollected = amount;
                        }
                        DL.Insert(rowInserted);
                    }
                }
            }
            catch
            {

            }
        }
    }
}

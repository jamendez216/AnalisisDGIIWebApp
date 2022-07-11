using AnalisisDGII.DL.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalisisDGII.EL.Database;

namespace AnalisisDGII.BL.ISR
{
    public class ISRService
    {
        public ISRData DataL = new ISRData();
        public void CargarCSV(string filepath)
        {
            //Load the file into StreamReader
            try
            {
                using (StreamReader fileStream = new StreamReader(filepath))
                {
                    string headerline = fileStream.ReadLine();
                    string line;
                    int rowIndex = 1;
                    //wipe out Database
                    DataL.ClearTable();
                    //Read every line until the row comes up null
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        var rowInserted = new EL.Database.ISR();
                        var row = line.Split(';');
                        string errorMessage = $"row {rowIndex} has ";
                        int fiscalYear;
                        decimal monthlyPayroll, monthlyRetention;

                        var fiscalYearConversionPassed = int.TryParse(row[0].ToString(), out fiscalYear);
                        if (fiscalYearConversionPassed)
                        {
                            rowInserted.FiscalYear = fiscalYear;
                        }

                        var monthlyPayrollConversionPassed = decimal.TryParse(row[1].ToString(), out monthlyPayroll);
                        if (monthlyPayrollConversionPassed)
                        {
                            rowInserted.MonthlyPayroll = monthlyPayroll;
                        }

                        var monthlyRetentionConversionPassed = decimal.TryParse(row[2].ToString(), out monthlyRetention);
                        if (monthlyRetentionConversionPassed)
                        {
                            rowInserted.MonthlyRetention = monthlyRetention;
                        }

                        DataL.Insert(rowInserted);
                    }
                }
            }
            catch
            {

            }
        }
    }
}

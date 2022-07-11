using AnalisisDGII.Data.DL;
using AnalisisDGII.DL.Data;
using AnalisisDGII.EL.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDGII.BL.ParqueVehicular
{
    public class ParqueVehicularService
    {
        public ParqueVehicularData DL = new ParqueVehicularData();
        public CarCompanyData companyData = new CarCompanyData();
        public CarClassData classData = new CarClassData();
        public CarTypeData typeData = new CarTypeData();
        public CarOriginData originData = new CarOriginData();
        
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
                    DL.ClearTable();
                    //Read every line until the row comes up null
                    while ((line = fileStream.ReadLine()) != null)
                    {
                        var rowInserted = new VEHICULARPARK();
                        var row = line.Split(';');
                        string errorMessage = $"row {rowIndex} has ";
                        int inscriptionYear, inscriptionMonth, entranceYear, fabricationYear, quantity, carClassID;

                        // validate every column's data type
                        #region DataValidation

                        //inscriptionYear
                        var inscriptionYearconversionPassed = int.TryParse(row[0].ToString(), out inscriptionYear);
                        if (inscriptionYearconversionPassed)
                        {
                            rowInserted.InscriptionYear = inscriptionYear;
                        }
                        else
                        {
                            errorMessage += "Invalid inscriptionYear. ";
                        }
                        //inscriptionMonth
                        var inscriptionMonthConversionPassed = int.TryParse(row[1].ToString(), out inscriptionMonth);
                        if (inscriptionMonthConversionPassed)
                        {
                            rowInserted.MonthID = inscriptionMonth;
                        }
                        else
                        {
                            errorMessage += "Invalid inscriptionMonth. ";
                        }
                        //entranceYear
                        var entranceYearConversionPassed = int.TryParse(row[2].ToString(), out entranceYear);
                        if (entranceYearConversionPassed)
                        {
                            rowInserted.EntranceYear = entranceYear;
                        }
                        else
                        {
                            errorMessage += "Invalid entranceYear. ";
                        }
                        //fabricationYear
                        var fabricationYearConversionPassed = int.TryParse(row[5].ToString(), out fabricationYear);
                        if (fabricationYearConversionPassed)
                        {
                            rowInserted.FabricationYear = fabricationYear;
                        }
                        else
                        {
                            errorMessage += "Invalid fabricationYear. ";
                        }
                        //quantity
                        var QTYConversionPassed = int.TryParse(row[8].ToString(), out quantity);
                        if (QTYConversionPassed)
                        {
                            rowInserted.Quantity = quantity;
                        }
                        else
                        {
                            errorMessage += "Invalid quantity. ";
                        }

                        var carType = row[4].ToString().Split('-');
                        var typeIDConversionPassed = int.TryParse(carType[0].ToString(), out carClassID);
                        #endregion

                        // Ensure every relational object exists in the DB
                        //If not, then proceed to insert it to make it scalable

                        #region RelationalObjectValidation
                        //cartype-4
                        if (typeIDConversionPassed)
                        {
                            rowInserted.CarTypeID = typeData.CreateIfNotExists(new CARTYPE() { CarTypeID = carClassID, CarTypeName = carType[1].ToString().Trim() });
                        }
                        //carClass-3
                        rowInserted.CarClassID = classData.CreateIfNotExists(row[3].Trim());
                        //carOrigin-6
                        rowInserted.CarOriginID = originData.CreateIfNotExists(row[6].Trim());
                        //carCompany-7
                        rowInserted.CarCompanyID = companyData.CreateIfNotExists(row[7].Trim());
                        #endregion
                        Console.Write(errorMessage);
                        // Insert the crap
                        DL.Insert(rowInserted);
                        rowIndex++;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}

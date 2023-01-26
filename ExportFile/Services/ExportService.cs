using ExportFile.Interfaces;
using ExportFile.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExportFile.Services
{
    public static class ExportService
    {
        #region CSV Export
        public static void ExportCSVData(object collection,string path)
        {
            if(collection is List<WorkPeople> workPeople)
            {
                var csv = new StringBuilder();
                string line = "First Name,Last Name,Email Address,Sales Person,Phone";
                foreach (var person in workPeople)
                {
                    csv.AppendLine(line);
                    line = string.Format("{0},{1},{2},{3},{4}", person.FirstName, person.LastName, person.EmailAddress, person.SalesPerson, person.Phone);
                    csv.AppendLine(line);
                }
                if (path.Split('.')[1] != "csv") path += ".csv";

                if (File.Exists(path))
                    File.AppendAllText(path, csv.ToString());
                else
                    File.WriteAllText(path, csv.ToString());
            }
            if(collection is List<Company> Company)
            {
                var csv = new StringBuilder();
                string line = "Name,Catch,Suffix,BsPhrase,Cadastro";
                foreach (var company in Company)
                {
                    csv.AppendLine(line);
                    line = string.Format("{0},{1},{2},{3},{4}", company.Name, company.Catch, company.Suffix, company.BsPhrase, company.Cadastro);
                    csv.AppendLine(line);
                }
                if (path.Split('.')[1] != "csv") path += ".csv";

                if (File.Exists(path))
                    File.AppendAllText(path, csv.ToString());
                else
                    File.WriteAllText(path, csv.ToString());
            }
            if(collection is List<Footballer> Footallers)
            {
                var csv = new StringBuilder();
                string line = "Name,Surname,Age,ExperienceYear,Salary";
                foreach (var footballer in Footallers)
                {
                    csv.AppendLine(line);
                    line = string.Format("{0},{1},{2},{3},{4}", footballer.Name, footballer.Surname, footballer.Age, footballer.ExperienceYear, footballer.Salary);
                    csv.AppendLine(line);
                }
                if (path.Split('.')[1] != "csv") path += ".csv";

                if (File.Exists(path))
                    File.AppendAllText(path, csv.ToString());
                else
                    File.WriteAllText(path, csv.ToString());
            }
            if(collection is List<Product> Products)
            {
                var csv = new StringBuilder();
                string line = "ID,Name,Category,Sub Category,Description,Price";
                foreach (var product in Products)
                {
                    csv.AppendLine(line);
                    line = string.Format("{0},{1},{2},{3},{4},{5}", product.ProductID, product.ProductName, product.ProductCategory, product.SubCategory, product.ProductDescription,product.ProductPrice);
                    csv.AppendLine(line);
                }
                if (!path.Contains(".csv")) path += ".csv";

                if (File.Exists(path))
                    File.AppendAllText(path, csv.ToString());
                else
                    File.WriteAllText(path, csv.ToString());
            }
            if(collection is List<Car> Cars)
            {
                var csv = new StringBuilder();
                string line = "Vendor,Model,Color,Year,Price";
                foreach (var car in Cars)
                {
                    csv.AppendLine(line);
                    line = string.Format("{0},{1},{2},{3},{4}", car.Vendor, car.Model, car.Color, car.Year, car.Price);
                    csv.AppendLine(line);
                }
                if (path.Split('.')[1] != "csv") path += ".csv";

                if (File.Exists(path))
                    File.AppendAllText(path, csv.ToString());
                else
                    File.WriteAllText(path, csv.ToString());
            }
        }
        #endregion
        #region TXT Export
        public static void ExportTXTData(object collection,string path)
        {
            if (!path.Contains(".txt")) path += ".txt";
            using (TextWriter writer = new StreamWriter(path))
            {
                if(collection is List<WorkPeople> workPeople)
                {
                    foreach (var person in workPeople)
                    {
                        writer.WriteLine("--------------");
                        writer.WriteLine($"First Name: {person.FirstName}");
                        writer.WriteLine($"Last Name: {person.LastName}");
                        writer.WriteLine($"Email Address: {person.EmailAddress}");
                        writer.WriteLine($"Sales Person: {person.SalesPerson}");
                        writer.WriteLine($"Phone: {person.Phone}");
                        writer.WriteLine("--------------");
                    }
                }
                if (collection is List<Company> Company)
                {
                    foreach (var company in Company)
                    {
                        writer.WriteLine("--------------");
                        writer.WriteLine($"Name: {company.Name}");
                        writer.WriteLine($"Cadastro: {company.Cadastro}");
                        writer.WriteLine($"Suffix: {company.Suffix}");
                        writer.WriteLine($"BsPhrase: {company.BsPhrase}");
                        writer.WriteLine($"Catch: {company.Catch}");
                        writer.WriteLine("--------------");
                    }
                }
                if (collection is List<Footballer> Footballers)
                {
                    foreach (var footballer in Footballers)
                    {
                        writer.WriteLine("--------------");
                        writer.WriteLine($"Name: {footballer.Name}");
                        writer.WriteLine($"Surname: {footballer.Surname}");
                        writer.WriteLine($"Age: {footballer.Age}");
                        writer.WriteLine($"Experience Year: {footballer.ExperienceYear}");
                        writer.WriteLine($"Salary: {footballer.Salary}");
                        writer.WriteLine("--------------");
                    }
                }
                if (collection is List<Product> Products)
                {
                    foreach (var product in Products)
                    {
                        writer.WriteLine("--------------");
                        writer.WriteLine($"ProductID: {product.ProductID}");
                        writer.WriteLine($"Product Name: {product.ProductName}");
                        writer.WriteLine($"Product Category: {product.ProductCategory}");
                        writer.WriteLine($"Sub Category: {product.SubCategory}");
                        writer.WriteLine($"Product Description: {product.ProductDescription}");
                        writer.WriteLine($"Product Price: {product.ProductPrice}");
                        writer.WriteLine("--------------");
                    }
                }
                if (collection is List<Car> Cars)
                {
                    foreach (var car in Cars)
                    {
                        writer.WriteLine("--------------");
                        writer.WriteLine($"Vendor: {car.Vendor}");
                        writer.WriteLine($"Model: {car.Model}");
                        writer.WriteLine($"Color: {car.Color}");
                        writer.WriteLine($"Year: {car.Year}");
                        writer.WriteLine($"Price: {car.Price}");
                        writer.WriteLine("--------------");
                    }
                }
            }
        }
        #endregion
    }
}

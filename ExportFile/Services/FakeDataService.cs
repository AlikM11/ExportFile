using Bogus;
using Bogus.Extensions.Brazil;
using Bogus.Extensions.Denmark;
using ExportFile.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExportFile.Services
{
    public static class FakeDataService
    {
        #region CarFake Data
        public static List<Car> GetCarsData()
        {
            var Car = new Faker<Car>()
                .RuleFor(o => o.Model, f => f.Vehicle.Model())
                .RuleFor(o => o.Vendor, f => f.Vehicle.Manufacturer())
                .RuleFor(o => o.Price, f => f.Vehicle.Random.Int(1000,100000))
                .RuleFor(o => o.Year, f => f.Vehicle.Random.Int(2000,2023))
                .RuleFor(o => o.Color, f => f.Commerce.Color());
            var Cars = Car.Generate(100);
            return Cars;
        }
        #endregion
        #region WorkerFake Data
        public static List<WorkPeople> GetWorkerPeopleData()
        {
            var workerfaker = new Faker<WorkPeople>()
                .RuleFor(o => o.Phone, f => f.Person.Phone)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.EmailAddress, (f, u) => f.Internet.Email(u.LastName))
                .RuleFor(o => o.SalesPerson, f=> f.Name.FullName()
                );

            var workers = workerfaker.Generate(100);
            return workers;
        }
        #endregion
        #region ProductFake Data
        public static List<Product> GetProductsData()
        {
            var Company = new Faker<Product>()
                .RuleFor(o => o.ProductID, f => f.Person.Cpr())
                .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
                .RuleFor(o => o.ProductPrice, f => f.Commerce.Random.Int(10,25000))
                .RuleFor(o => o.ProductCategory, f => f.Commerce.Categories(2)[0])
                .RuleFor(o => o.SubCategory, f => f.Commerce.Categories(2)[1])
                .RuleFor(o => o.ProductDescription, f => f.Commerce.ProductDescription());
            var Companies = Company.Generate(100);
            return Companies;
        }
        #endregion
        #region CompaniesFake Data
        public static List<Company> GetCompaniesData()
        {
            var Company = new Faker<Company>()
                .RuleFor(o => o.Catch, f => f.Company.CatchPhrase())
                .RuleFor(o => o.BsPhrase, f => f.Company.Bs())
                .RuleFor(o => o.Cadastro, f => f.Company.Cnpj())
                .RuleFor(o => o.Catch, f => f.Company.CatchPhrase())
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.Suffix, f => f.Company.CompanySuffix());
            var Companies = Company.Generate(100);
            return Companies;
        }
        #endregion
        #region FootallerFake Data
        public static List<Footballer> GetFootballersData()
        {
            var footballer = new Faker<Footballer>()
                .RuleFor(o => o.Name, f => f.Name.FirstName())
                .RuleFor(o => o.Surname, f => f.Name.LastName())
                .RuleFor(o => o.Age, f => f.Random.Int(18,40))
                .RuleFor(o => o.ExperienceYear, f => f.Random.Int(1,30))
                .RuleFor(o => o.Salary, f => f.Random.Int(100000, 10000000));
            var footballers = footballer.Generate(100);
            return footballers;
        }
        #endregion
    }
}

using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;



var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);
var productRepo = new DapperProductRepository(conn);
//productRepo.InsertProduct("newstuff", 25, 2);
var products = productRepo.GetAllProducts();

productRepo.DeleteProduct(945);

foreach (var product in products)
{
    Console.WriteLine(product.productId);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}

//departmentRepo.InsertDepartment("Johns new department");

//var departments = departmentRepo.GetAllDepartments();

//foreach(var department in departments)
//{
//    Console.WriteLine(department.DepartmentID);
//    Console.WriteLine(department.Name);
//    Console.WriteLine();
//    Console.WriteLine();
    
//}

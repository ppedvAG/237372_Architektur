
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data.Common;

Console.WriteLine("Hello Factory!");

string conStringSQL = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
string conStringSQLITE = @"Data Source=C:\DB\Northwind.sqlite";

DbProviderFactory factory = null;
string conString = "";

if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
{
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
    conString = conStringSQL;
}
else
{
    factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
    conString = conStringSQLITE;
}


DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

DbCommand cmd = con.CreateCommand();
cmd.CommandText = "SELECT COUNT(*) FROM EMPLOYEES";
var count = cmd.ExecuteScalar();

Console.WriteLine($"{count} Employees in DB");


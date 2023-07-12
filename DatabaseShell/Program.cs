using Npgsql;
using Dapper;
using System.ComponentModel.Design;
using ConsoleTables;
using System.Data;

namespace DatabaseShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string server;
            string database;
            string port;
            string Username;

            Console.Write("Server [localhost]: ");
            server = Console.ReadLine();
            Console.Write("Database [postgres]: ");
            database = Console.ReadLine();
            Console.Write("Port [5432]: ");
            port = Console.ReadLine();
            Console.Write("Username [postgres]: ");
            Username = Console.ReadLine();
            Console.Write("Password for user postgres: ");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(server))
            {
                server = "localhost";
            }
            if (string.IsNullOrEmpty(database))
            {
                database = "postgres";
            }
            if (string.IsNullOrEmpty(port))
            {
                port = "5432";
            }
            if (string.IsNullOrEmpty(Username))
            {
                Username = "postgres";
            }

            bool checker = true;

            try
            {
                string connectionString = $"Server={server};Port={port};User Id={Username};Password={password};Database={database};";

                var con = new NpgsqlConnection(connectionString);

                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("psql: error: connection to server at \"localhost\" (::1), port 5432 failed: fe_sendauth: no password supplied\r\nPress any key to continue . . .");
                checker = false;
            }
            while (checker)
            {
                Console.Write($"{database}=#: ");

                string sql = Console.ReadLine();

                if (sql == "cls")
                {
                    Console.Clear();
                    continue;

                }
                else if(sql == "exit")
                {
                    break;
                }
                

                try
                {
                    string connectionString = $"Server={server};Port={port};User Id={Username};Password={password};Database={database};";

                    var con = new NpgsqlConnection(connectionString);

                    con.Open();

                    var result = con.Query<object>(sql);

                    foreach (var i in result)
                    {
                        Console.WriteLine(i);
                    }

                    //var data = InitInfo();

                    //string[] columnNames = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

                    //DataRow[] rows = data.Select();

                    //var table = new ConsoleTable(columnNames);

                    //foreach (DataRow i in rows)
                    //{
                    //    table.AddRow(i.ItemArray);
                    //}

                    //table.Write(Format.Alternative);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
        }
        //public static DataTable InitInfo()
        //{
        //    var table = new DataTable();

        //    table.Columns.Add("id", typeof(object));
        //    table.Columns.Add("FirstName", typeof(object));
        //    table.Columns.Add("LastName", typeof(object));

        //    string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=1234;Database=dvdRental;";

        //    var con = new NpgsqlConnection(connectionString);

        //    con.Open();

        //    string sql = "select * from actor";

        //    var users = con.Query<object>(sql);

        //    foreach (object user in users)
        //    {
        //        var i = user.ToString().Split("=");

        //        //var m = i.ToString().Split(",");

        //        table.Rows.Add($"{i[1]}", $"{i[2]}",$"{i[3]}");
        //    }

        //    return table;

            //var cmd = new NpgsqlCommand();

            //using (var con = new NpgsqlConnection(connectionString))
            //{
            //    con.Open();
            //    cmd.Connection = con;
            //}

            //using (NpgsqlDataReader reader = cmd.ExecuteReader())
            //{

            //    object[] result = new object[] { };

            //    while (reader.Read())
            //    {
            //        //result.Append($"{reader[0]} {reader[1]} {reader[2]}");

            //        table.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            //    }

            //    return table;
            //}


        //}
    }
}



//using ConsoleTables;
//using System.Data;
//using System.Text;

//namespace MyLesson
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.OutputEncoding = Encoding.UTF8;

//            var data = InitEmployees();

//            string[] columnNames = data.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();

//            DataRow[] rows = data.Select();

//            var table = new ConsoleTable(columnNames);

//            foreach (DataRow i in rows)
//            {
//                table.AddRow(i.ItemArray);
//            }

//            //table.Write(Format.MarkDown);
//            table.Write(Format.Alternative);
//            //table.Write(Format.Minimal);
//            //table.Write(Format.Default);

//        }
//        static DataTable InitEmployees()
//        {
//            var table = new DataTable();

//            table.Columns.Add("id",typeof(int));
//            table.Columns.Add("name",typeof(string));
//            table.Columns.Add("address",typeof(string));
//            table.Columns.Add("Gender",typeof(string));

//            table.Rows.Add(1,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(2,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(3,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(4,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(5,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(6,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(7,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(8,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(9,"Sanjarbek","Toshkent","Male");
//            table.Rows.Add(10,"Sanjarbek","Toshkent","Male");

//            return table;
//        }
//    }
//}
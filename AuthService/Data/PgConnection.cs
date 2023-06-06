using Npgsql;

namespace AuthService
{
    internal class PostgresConnection
    {
        private static string connectionString = 
            "Server=localhost;" +
            "Database = postgres;" +
            "Username=postgres;" +
            "Port=5432;" +
            "Password=postgres;";
        public static NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        public PostgresConnection()
        {
            connection.Open();
        }
        public static void SelectAllFromTable(string tableName)
        {
            using (var cmd = new NpgsqlCommand($"SELECT*FROM w.{tableName}", connection))
            {
                var reader = cmd.ExecuteReader();

                // Долбоёб ничего не допилил
                switch (tableName)
                {
                    case "service":
                        Data.services.Clear();
                        while (reader.Read())
                        {
                            Data.services.Add(new Service() { 
                                ID = reader.GetInt32(0), 
                                Name = reader.GetString(1), 
                                Cost = reader.GetInt32(2) });
                        }
                        break;
                    case "order":
                        Data.orders.Clear();
                        while (reader.Read())
                        {
                            Data.orders.Add(new Order()
                            {
                                ID = reader.GetInt32(0),
                                OrderDate = reader.GetString(1),
                                Cost = reader.GetInt32(2),
                                EmployeeID = reader.GetInt32(3),
                                CarID = reader.GetInt32(4),
                                ServiceID = reader.GetInt32(5)
                            });
                        }
                        break;
                    case "car":
                        Data.cars.Clear();
                        while (reader.Read())
                        {
                            Data.cars.Add(new Car()
                            {
                                ID = reader.GetInt32(0),
                                Brand = reader.GetString(1),
                                Model = reader.GetString(2),
                                Color = reader.GetString(3),
                                RegNum = reader.GetInt32(4),
                                VinNum = reader.GetInt32(5),
                                ClientID = reader.GetInt32(6)
                            });
                        }
                        break;
                    case "employee":
                        Data.employees.Clear();
                        while (reader.Read())
                        {
                            Data.employees.Add(new Employee()
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SecondName = reader.GetString(2),
                                Phone = reader.GetInt32(3),
                                BirthDate = reader.GetString(4),
                                RecDate = reader.GetString(5),
                                PositionID = reader.GetInt32(6),
                            });
                        }
                        break;
                    case "position":
                        Data.positions.Clear();
                        while (reader.Read())
                        {
                            Data.positions.Add(new Position()
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Salary = reader.GetInt32(2)
                            });
                        }
                        break;
                    case "client":
                        Data.clients.Clear();
                        while (reader.Read())
                        {
                            Data.clients.Add(new Client()
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                SecondName = reader.GetString(2),
                                SurName = reader.GetString(3),
                                Phone = reader.GetInt32(4),
                            });
                        }
                        break;
                    default:
                        break;
                }
                reader.Close();
            }
        }
    }
}
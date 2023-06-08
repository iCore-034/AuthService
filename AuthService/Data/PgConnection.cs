using Npgsql;
using System;
using System.Linq;
using System.Windows.Controls;

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
        public static void UpdateRowTable(object item)
        {
            switch (Data.choosedTable)
            {
                case "Service":
                    Service ser = item as Service;
                    var c1 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET name = '{ser.Name}', cost = {ser.Cost} WHERE id = {ser.ID}", connection);
                    c1.ExecuteNonQuery();
                    break;
                case "Order":
                    Order or = item as Order;
                    var c2 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET ord_date = '{or.OrderDate}', cost = {or.Cost}, employee_id = {or.EmployeeID}, car_id = {or.CarID}, service_id = {or.ServiceID} " +
                        $"WHERE id = {or.ID}", connection);
                    c2.ExecuteNonQuery();
                    break;
                case "Car":
                    Car car = item as Car;
                    var c3 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET brand = '{car.Brand}', model = '{car.Model}', color = '{car.Color}', regnum = {car.RegNum}, vinnum = {car.VinNum}, client_id = {car.ClientID} " +
                        $"WHERE id = {car.ID}", connection);
                    c3.ExecuteNonQuery();
                    break;
                case "Employee":
                    Employee emp = item as Employee;
                    var c4 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET name = '{emp.Name}', secondname = '{emp.SecondName}', phone = {emp.Phone}, birthdate = '{emp.BirthDate}', recdate = '{emp.RecDate}', positionid = {emp.PositionID} " +
                        $"WHERE id = {emp.ID}", connection);
                    c4.ExecuteNonQuery();
                    break;
                case "Position":
                    Position po = item as Position;
                    var c5 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET name = '{po.Name}', salary = {po.Salary} " +
                        $"WHERE id = {po.ID}", connection);
                    c5.ExecuteNonQuery();
                    break;
                case "Client":
                    Client cl = item as Client;
                    var c6 = new NpgsqlCommand($"UPDATE w.{Data.choosedTable.ToLower()} " +
                        $"SET name = '{cl.Name}', secondname = '{cl.SecondName}', surname = '{cl.SurName}', phone = {cl.Phone} " +
                        $"WHERE id = {cl.ID}", connection);
                    c6.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }
        public static void AddToTable()
        {
            switch (Data.choosedTable)
            {
                case "Service":
                    Service serv = Data.services.Last();
                    var c1 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(name,cost) VALUES ('{serv.Name}','{serv.Cost}')", connection);
                    c1.ExecuteNonQuery();
                    break;
                case "Order":
                    Order ord = Data.orders.Last();
                    var c2 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(ord_date,cost,employee_id,car_id,service_id) " +
                        $"VALUES ('{ord.OrderDate}','{ord.Cost}','{ord.EmployeeID}','{ord.CarID}','{ord.ServiceID}')", connection);
                    c2.ExecuteNonQuery();
                    break;
                case "Car":
                    Car car = Data.cars.Last();
                    var c3 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(brand,model,color,regnum,vinnum,client_id) " +
                        $"VALUES ('{car.Brand}','{car.Model}','{car.Color}','{car.RegNum}','{car.VinNum}','{car.ClientID}')", connection);
                    c3.ExecuteNonQuery();
                    break;
                case "Employee":
                    Employee em = Data.employees.Last();
                    var c4 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(name,secondname,phone,birthdate,recdate,positionid) " +
                        $"VALUES ('{em.Name}','{em.SecondName}','{em.Phone}','{em.BirthDate}','{em.RecDate}','{em.PositionID}')", connection);
                    c4.ExecuteNonQuery();
                    break;
                case "Position":
                    Position pos = Data.positions.Last();
                    var c5 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(name,salary) " +
                        $"VALUES ('{pos.Name}','{pos.Salary}')", connection);
                    c5.ExecuteNonQuery();
                    break;
                case "Client":
                    Client cl = Data.clients.Last();
                    var c6 = new NpgsqlCommand($"INSERT INTO w.{Data.choosedTable.ToLower()} " +
                        $"(name,secondname,surname,phone) " +
                        $"VALUES ('{cl.Name}','{cl.SecondName}','{cl.SurName}','{cl.Phone}')", connection);
                    c6.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }
        public static void DeleteFromTable(object obj)
        {
            switch (Data.choosedTable)
            {
                case "Service":
                    Service ser = obj as Service;
                    Data.services.Remove(ser);
                    var c1 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {ser.ID}", connection);
                    c1.ExecuteNonQuery();
                    break;
                case "Order":
                    Order or = obj as Order;
                    Data.orders.Remove(or);
                    var c2 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {or.ID}", connection);
                    c2.ExecuteNonQuery();
                    break;
                case "Car":
                    Car car = obj as Car;
                    Data.cars.Remove(car);
                    var c3 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {car.ID}", connection);
                    c3.ExecuteNonQuery();
                    break;
                case "Employee":
                    Employee emp = obj as Employee;
                    Data.employees.Remove(emp);
                    var c4 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {emp.ID}", connection);
                    c4.ExecuteNonQuery();
                    break;
                case "Position":
                    Position po = obj as Position;
                    Data.positions.Remove(po);
                    var c5 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {po.ID}", connection);
                    c5.ExecuteNonQuery();
                    break;
                case "Client":
                    Client cl = obj as Client;
                    Data.clients.Remove(cl);
                    var c6 = new NpgsqlCommand($"DELETE FROM w.{Data.choosedTable.ToLower()} WHERE id = {cl.ID}", connection);
                    c6.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }
        public static void SelectAllFromTable(string tableName)
        {
            using (var cmd = new NpgsqlCommand($"SELECT*FROM w.{tableName}", connection))
            {
                var reader = cmd.ExecuteReader();
                switch (tableName)
                {
                    case "Service":
                        Data.services.Clear();
                        while (reader.Read())
                        {
                            Data.services.Add(new Service()
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Cost = reader.GetInt32(2)
                            });
                        }
                        break;
                    case "Order":
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
                    case "Car":
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
                    case "Employee":
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
                    case "Position":
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
                    case "Client":
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
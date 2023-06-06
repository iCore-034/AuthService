using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public class DataTable
    {
        public static List<string> serviceList = new List<string>() { "Service", "Id", "Name", "Cost" };
        public static List<string> carList = new List<string>() { "Car", "Id", "Brand", "Model", "Color", "RegNum", "VinNum", "ClientID" };
        public static List<string> orderList = new List<string>() { "Order", "Id", "Cost", "EmployeeID", "CarID", "ServiceID" };
        public static List<string> employeeList = new List<string>() { "Employee", "Id", "Name", "SecondName", "Phone", "BirthDate", "RecDate", "PositionID" };
        public static List<string> positonList = new List<string>() { "Position", "Id", "Name", "Salary" };
        public static List<string> clientList = new List<string>() { "Client", "Id", "Name", "SecondName", "Surname", "Phone" };

    }
    public interface IdExisting
    {
        public int ID { get; set; }
    }
    public interface NameIdExistiog : IdExisting
    {
        public string Name { get; set; }
    }
    public class Service : NameIdExistiog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    public class Client : NameIdExistiog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string SurName { get; set; }
        public int Phone { get; set; }
    }
    public class Position : NameIdExistiog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    public class Employee : NameIdExistiog
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Phone { get; set; }
        public string BirthDate { get; set; }
        public string RecDate { get; set; }
        public int PositionID { get; set; }
    }
    public class Order : IdExisting
    {
        public int ID { get; set; }
        public string OrderDate { get; set; }
        public int Cost { get; set; }
        public int EmployeeID { get; set; }
        public int CarID { get; set; }
        public int ServiceID { get; set; }
    }
    public class Car : IdExisting
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int RegNum { get; set; }
        public int VinNum { get; set; }
        public int ClientID { get; set; }
    }
}

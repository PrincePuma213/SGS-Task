namespace TestWpfApp.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }     
    }

    public class Workshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }

    public class Brigade
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int WorkshopId { get; set; }
        public int? BrigadeId { get; set; }
    }

    public class Shift
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BrigadeId { get; set; }
    }
}

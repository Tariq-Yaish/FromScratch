namespace FromScratch.Models
{
    public class Employee
    {
        public int Employee_ID { get; set; }

        public string? Employee_Name { get; set; }

        public int Employee_Age { get; set; }

        public int Comapny_Id { get; set; }

        public Company? Company { get; set; }
    }
}

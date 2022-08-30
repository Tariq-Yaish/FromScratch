namespace FromScratch.Models
{
    public class Company
    {
        public int Company_ID { get; set; }

        public string? Company_Name { get; set; }

        public string? Location { get; set; }

        public List<Employee>? emploees { get; set; }
    }
}

namespace AzureFunctionsProject.Models 
{
    public class UserRequest {
        public string Name { get; set; }
        public int? Age { get; set; }
        public bool IsActive { get; set; }
    }
}
namespace Main_Thread.DAL.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime HireDate { get; set; }
    public int Role { get; set; }
    public int BusinessId { get; set; }

}
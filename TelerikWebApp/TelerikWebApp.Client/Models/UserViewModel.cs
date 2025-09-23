namespace TelerikWebApp.Client.Models;

public class UserViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Department { get; set; } = "";
    public string Position { get; set; } = "";
    public decimal Salary { get; set; }
    public bool IsActive { get; set; }
    public string StatusText { get; set; } = "";

    public static UserViewModel FromUser(User user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Department = user.Department,
            Position = user.Position,
            Salary = user.Salary,
            IsActive = user.IsActive,
            StatusText = user.IsActive ? "Active" : "Inactive"
        };
    }
}
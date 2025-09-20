using TelerikWebApp.Client.Models;

namespace TelerikWebApp.Client.Services;

public class UserService
{
    private readonly List<User> _users;
    private readonly List<string> _departments = new()
    {
        "Engineering", "Marketing", "Sales", "Human Resources", "Finance",
        "Operations", "Customer Support", "Product Management", "Design", "Legal"
    };

    private readonly Dictionary<string, List<string>> _positionsByDepartment = new()
    {
        ["Engineering"] = new() { "Software Engineer", "Senior Software Engineer", "Tech Lead", "Engineering Manager", "Principal Engineer" },
        ["Marketing"] = new() { "Marketing Specialist", "Marketing Manager", "Content Creator", "SEO Specialist", "Marketing Director" },
        ["Sales"] = new() { "Sales Representative", "Account Manager", "Sales Manager", "Business Development", "Sales Director" },
        ["Human Resources"] = new() { "HR Specialist", "Recruiter", "HR Manager", "HR Business Partner", "HR Director" },
        ["Finance"] = new() { "Financial Analyst", "Accountant", "Finance Manager", "Controller", "CFO" },
        ["Operations"] = new() { "Operations Specialist", "Operations Manager", "Process Analyst", "Operations Director", "COO" },
        ["Customer Support"] = new() { "Support Specialist", "Support Manager", "Customer Success Manager", "Support Director", "Chief Customer Officer" },
        ["Product Management"] = new() { "Product Manager", "Senior Product Manager", "Product Owner", "VP of Product", "Chief Product Officer" },
        ["Design"] = new() { "UI Designer", "UX Designer", "Senior Designer", "Design Manager", "Creative Director" },
        ["Legal"] = new() { "Legal Counsel", "Senior Legal Counsel", "Legal Manager", "General Counsel", "Chief Legal Officer" }
    };

    public UserService()
    {
        _users = GenerateUsers(100);
    }

    public Task<List<User>> GetUsersAsync()
    {
        return Task.FromResult(_users);
    }

    public Task<List<string>> GetDepartmentsAsync()
    {
        return Task.FromResult(_departments);
    }

    public Task<List<string>> GetPositionsAsync(string? department = null)
    {
        if (string.IsNullOrEmpty(department))
        {
            var allPositions = _positionsByDepartment.Values.SelectMany(x => x).Distinct().ToList();
            return Task.FromResult(allPositions);
        }

        var positions = _positionsByDepartment.TryGetValue(department, out var deptPositions)
            ? deptPositions
            : new List<string>();

        return Task.FromResult(positions);
    }

    private List<User> GenerateUsers(int count)
    {
        var random = new Random(42); // Fixed seed for consistent data
        var firstNames = new[]
        {
            "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth",
            "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Christopher", "Karen",
            "Charles", "Nancy", "Daniel", "Lisa", "Matthew", "Betty", "Anthony", "Helen", "Mark", "Sandra",
            "Donald", "Donna", "Steven", "Carol", "Paul", "Ruth", "Andrew", "Sharon", "Joshua", "Michelle",
            "Kenneth", "Laura", "Kevin", "Sarah", "Brian", "Kimberly", "George", "Deborah", "Timothy", "Dorothy"
        };

        var lastNames = new[]
        {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
            "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"
        };

        var users = new List<User>();

        for (int i = 1; i <= count; i++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            var department = _departments[random.Next(_departments.Count)];
            var positions = _positionsByDepartment[department];
            var position = positions[random.Next(positions.Count)];

            var baseSalary = position switch
            {
                var p when p.Contains("Director") || p.Contains("VP") || p.Contains("Chief") => random.Next(120000, 250000),
                var p when p.Contains("Manager") || p.Contains("Lead") || p.Contains("Senior") || p.Contains("Principal") => random.Next(80000, 150000),
                _ => random.Next(45000, 95000)
            };

            users.Add(new User
            {
                Id = i,
                FirstName = firstName,
                LastName = lastName,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}@company.com",
                Department = department,
                Position = position,
                Salary = baseSalary + (random.Next(-5000, 10000)),
                IsActive = random.NextDouble() > 0.1 // 90% active
            });
        }

        return users;
    }
}
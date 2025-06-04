using System.ComponentModel.DataAnnotations;

namespace Model;

public class User
{
    [Required]
    [UserValidation]
    public string? UserName { get; set; }

    [Required]
    public string? Email { get; set; }


    public int? Id { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
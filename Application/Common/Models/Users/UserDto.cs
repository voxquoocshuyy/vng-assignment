using Domain.Enums;

namespace Application.Common.Models.Users;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public UserStatusEnum Status { get; set; }
    public DateTime LastUpdatePassword { get; set; }
}
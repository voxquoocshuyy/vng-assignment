using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Enums;
using Infrastructure.Services.MailServices;
using Quartz;

namespace Application.Features.Users;

public class UpdatePasswordStatusJob : IJob
{
    private readonly IUserRepository _userRepository;
    private readonly ISmtpEmailService _emailService;

    public UpdatePasswordStatusJob(IUserRepository userRepository, ISmtpEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var usersToUpdate = await _userRepository.GetUserToUpdatePasswordAsync();
        
        if (!usersToUpdate.Any()) return;

        foreach (var user in usersToUpdate)
        {
            user.Status = (int)UserStatusEnum.REQUIRE_CHANGE_PWD;
        }

        var listEmail = usersToUpdate.Select(u => u.Email).ToList();
        await _emailService.SendEmailAsync(new MailRequest
        {
            ToAddresses = listEmail,
            Subject = "Update Password",
            Body = "Please update your password"
        });
        _userRepository.UpdateListAsync(usersToUpdate);
        await _userRepository.SaveChangesAsync();
    }
}
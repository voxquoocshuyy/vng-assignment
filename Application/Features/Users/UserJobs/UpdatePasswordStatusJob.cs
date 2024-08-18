using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Services.MailServices;
using Quartz;

namespace Application.Features.Users;

public class UpdatePasswordStatusJob : IJob
{
    private readonly IUserRepository _userRepository;
    private readonly ISmtpEmailService _emailService;
    private readonly IMapper _mapper;

    public UpdatePasswordStatusJob(IUserRepository userRepository, ISmtpEmailService emailService, IMapper mapper)
    {
        _userRepository = userRepository;
        _emailService = emailService;
        _mapper = mapper;
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var userDtoToUpdate = await _userRepository.GetUserToUpdatePasswordAsync();
        
        if (!userDtoToUpdate.Any()) return;
        
        foreach (var user in userDtoToUpdate)
        {
            user.Status = UserStatusEnum.REQUIRE_CHANGE_PWD;
        }
        
        var listEmail = userDtoToUpdate.Select(u => u.Email).ToList();
        await _emailService.SendEmailAsync(new MailRequest
        {
            ToAddresses = listEmail,
            Subject = "Update Password",
            Body = "Please update your password"
        });
        var listUserUpdate = _mapper.Map<List<User>>(userDtoToUpdate);
        await _userRepository.UpdateListAsync(listUserUpdate);
        await _userRepository.SaveChangesAsync();
    }
}
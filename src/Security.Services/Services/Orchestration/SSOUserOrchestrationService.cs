﻿using Security.Objects.DTOs;
using Security.Objects.Entities;
using Security.Services.Services.Orchestration.Interfaces;
using Security.Services.Services.Processing.Interfaces;
using System.Security;

namespace Security.Services.Services.Orchestration
{
    public class SSOUserOrchestrationService : ISSOUserOrchestrationService
    {
        readonly ISSOUserProcessingService ssoUserProcessingService;
        readonly ITokenProcessingService tokenProcessingService;
        readonly ISessionProcessingService sessionService;

        public SSOUserOrchestrationService(
            ISSOUserProcessingService ssoUserProcessingService,
            ITokenProcessingService tokenProcessingService,
            ISessionProcessingService sessionService)
        {
            this.ssoUserProcessingService = ssoUserProcessingService;
            this.tokenProcessingService = tokenProcessingService;
            this.sessionService = sessionService;
        }

        public async ValueTask<SSOUser> Register(RegisterUser registerForm)
        {
            ValidateRegisterForm(registerForm);

            var mappedUser = MapToSSOUser(registerForm);

            var result = await ssoUserProcessingService.RegisterSSOUserAsync(mappedUser);
            await tokenProcessingService.GenerateConfirmationToken(result.Id);
            return result;
        }

        static void ValidateRegisterForm(RegisterUser registerForm)
        {
            if (!registerForm.Email.Contains('@'))
                throw new Exception("Invalid email provided");

            if (string.IsNullOrEmpty(registerForm.DisplayName))
                throw new Exception("Display name cannot be empty");

            if (string.IsNullOrEmpty(registerForm.Password))
                throw new Exception("Password cannot be empty");
        }

        private SSOUser MapToSSOUser(RegisterUser registerForm)
            => new SSOUser
            {
                Id = registerForm.Email.Split("@")[0],
                DisplayName = registerForm.DisplayName,
                PasswordHash = registerForm.Password,
                Email = registerForm.Email,
                PhoneNumber = registerForm.PhoneNumber
            };

        public async ValueTask ConfirmRegistration(string tokenId)
        {
            var token = tokenProcessingService.GetConfirmationToken(tokenId);

            if (token == null)
                throw new SecurityException("Access Denied!");

            var user = ssoUserProcessingService
                .GetAllSSOUsers(true)
                .FirstOrDefault(u => u.Id == token.UserName);

            if (user == null)
                throw new SecurityException("Access Denied!");

            user.EmailConfirmed = true;
            await ssoUserProcessingService.UpdateSSOUserAsync(user);
            await tokenProcessingService.DeleteTokenAsync(token.Id);
        }

        public async ValueTask ConfirmForgotPassword(string tokenId, string newPassword)
        {
            var token = tokenProcessingService.GetForgottenPasswordToken(tokenId);

            if (token == null)
                throw new SecurityException("Access Denied!");

            var user = ssoUserProcessingService
                .GetAllSSOUsers(true)
                .FirstOrDefault(u => u.Id == token.UserName);

            if (user == null)
                throw new SecurityException("Access Denied!");

            user.PasswordHash = newPassword;
            await ssoUserProcessingService.UpdateSSOUserAsync(user);
            await tokenProcessingService.DeleteTokenAsync(token.Id);
        }
    }
}
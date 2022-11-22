﻿using Security.Objects.Entities;
using Security.Services.Services.Orchestration.Interfaces;
using Security.Services.Services.Processing.Interfaces;
using System.Security;

namespace Security.Services.Services.Orchestration
{
    public class AuthenticationOrchestrationService : IAuthenticationOrchestrationService
    {
        private readonly ISSOUserProcessingService ssoUserProcessingService;
        private readonly ITokenProcessingService tokenProcessingService;
        private readonly ISessionProcessingService sessionProcessingService;

        public AuthenticationOrchestrationService(
            ISSOUserProcessingService ssoUserProcessingService,
            ITokenProcessingService tokenProcessingService,
            ISessionProcessingService sessionProcessingService)
        {
            this.ssoUserProcessingService = ssoUserProcessingService;
            this.tokenProcessingService = tokenProcessingService;
            this.sessionProcessingService = sessionProcessingService;
        }

        public async ValueTask<Token> GenerateConfirmationToken(string userId, int reasonCode)
            => await tokenProcessingService.GenerateConfirmationToken(userId, reasonCode);

        public async ValueTask<Token> LoginAsync(string username, string password)
        {
            var user = ssoUserProcessingService.FindByUserAndPassword(username, password);

            if (user == null)
                throw new SecurityException("Access Denied!");

            sessionProcessingService.SetUser(user);
            var token = await tokenProcessingService.AddTokenForUser(user.Id);
            sessionProcessingService.SetString("token", token.Id);
            return token;
        }

        public async ValueTask Logout(string tokenId = null)
        {
            tokenId ??= sessionProcessingService.GetString("token");
            sessionProcessingService.SetString("token", null);
            sessionProcessingService.SetUser(null);
            await tokenProcessingService.DeleteTokenAsync(tokenId);
        }
    }
}
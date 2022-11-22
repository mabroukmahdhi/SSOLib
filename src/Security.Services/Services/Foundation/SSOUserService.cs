using Security.Data.Brokers.Storage.Interfaces;
using Security.Objects.Entities;
using Security.Services.Services.Foundation.Interfaces;

namespace Security.Services.Foundation
{
    public class SSOUserService : ISSOUserService
    {
        readonly ISSOUserBroker ssoUserBroker;
        
        public SSOUserService(ISSOUserBroker storageBroker)
            => this.ssoUserBroker = storageBroker;

        public async ValueTask<SSOUser> AddSSOUserAsync(SSOUser item)
        {
            var userIdCount = ssoUserBroker.GetAllSSOUsers(true)
                .Count(sso => sso.Id == item.Id);

            if (userIdCount > 0)
                item.Id += userIdCount;

            return await ssoUserBroker.AddSSOUserAsync(item);
        }

        public async ValueTask DeleteSSOUserAsync(SSOUser item)
            => await ssoUserBroker.DeleteSSOUserAsync(item);

        public async ValueTask<SSOUser> UpdateSSOUserAsync(SSOUser item)
            => await ssoUserBroker.UpdateSSOUserAsync(item);

        public IQueryable<SSOUser> GetAllSSOUsers(bool ignoreFilters = false)
            => ssoUserBroker.GetAllSSOUsers(ignoreFilters);
    }
}
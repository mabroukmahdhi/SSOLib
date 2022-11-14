using Security.Objects.Entities;

namespace Security.Services.Services.Processing.Interfaces
{
    public interface ISSOUserProcessingService
    {
        ValueTask<SSOUser> RegisterSSOUserAsync(SSOUser item);
        ValueTask<SSOUser> UpdateSSOUserAsync(SSOUser item);
        ValueTask DeleteSSOUserAsync(SSOUser item);
        IQueryable<SSOUser> GetAllSSOUsers(bool ignoreFilters = false);
        SSOUser Login(string username, string password);
    }
}
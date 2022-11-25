using System.Linq;
using System.Threading.Tasks;
using Security.Objects.Entities;

namespace Security.Services.Services.Foundation.Interfaces
{
    public interface ISSOUserRoleService
    {
        IQueryable<SSOUserRole> GetAllSSOUserRoles();

        ValueTask<SSOUserRole> AddSSOUserRoleAsync(SSOUserRole item);
        ValueTask DeleteSSOUserRoleAsync(SSOUserRole item);
    }
}
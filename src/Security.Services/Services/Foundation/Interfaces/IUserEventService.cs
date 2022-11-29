﻿using Security.Objects.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Services.Services.Foundation.Interfaces
{
    public interface IUserEventService
    {
        ValueTask<UserEvent> AddUserEventAsync(UserEvent userEvent);
        ValueTask DeleteUserEventAsync(UserEvent userEvent);
        IQueryable<UserEvent> GetAllUserEvents();
        ValueTask<UserEvent> UpdateUserEventAsync(UserEvent userEvent);
    }
}

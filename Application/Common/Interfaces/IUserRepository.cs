﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace GestionAnnonce.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetUsersAsync(CancellationToken cancellationToken);
        Task<int> UpdateUserAsync(string requestUserId, ApplicationUser requestUser, CancellationToken cancellationToken);
        Task<int> DeleteUserAsync(string requestUserId, CancellationToken cancellationToken);
    }
}

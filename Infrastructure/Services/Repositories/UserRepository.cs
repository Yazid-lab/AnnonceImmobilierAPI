using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAdManagementContext _context;

        public UserRepository(IAdManagementContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}

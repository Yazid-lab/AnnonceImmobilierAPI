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

        public async Task<int> UpdateUserAsync(int requestUserId, User requestUser, CancellationToken cancellationToken)
        {
            if (await UserExists(requestUserId) == false)
            {
                return -1;
            }

            _context.Users.Update(requestUser);
            await _context.SaveChangesAsync(cancellationToken);
            return requestUserId;
        }

        public async Task<int> DeleteUserAsync(int requestUserId, CancellationToken cancellationToken)
        {
            if (await UserExists(requestUserId) == false)
            {
                return -1;
            }

            await _context.Users.Where(user => user.Id == requestUserId).ExecuteDeleteAsync(cancellationToken);
            return requestUserId;

        }

        private async Task<bool> UserExists(int userId)
        {
            var user = await _context.Users.AsNoTracking().Where(user => user.Id == userId).FirstOrDefaultAsync();
            return user != null;
        }
    }
}

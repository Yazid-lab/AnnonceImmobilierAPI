//using Domain.Entities;
//using GestionAnnonce.Application.Common.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Services.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly IAdManagementContext _context;

//        public UserRepository(IAdManagementContext context)
//        {
//            _context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken)
//        {
//            return await _context.Users.ToListAsync(cancellationToken);
//        }

//        public async Task<int> UpdateUserAsync(string requestUserId, User requestUser, CancellationToken cancellationToken)
//        {
//            if (await UserExists(requestUserId) == false)
//            {
//                return -1;
//            }

//            _context.Users.Update(requestUser);
//            await _context.SaveChangesAsync(cancellationToken);
//            return Convert.ToInt32(requestUserId);
//        }

//        public async Task<int> DeleteUserAsync(string requestUserId, CancellationToken cancellationToken)
//        {
//            if (await UserExists(requestUserId) == false)
//            {
//                return -1;
//            }

//            await _context.Users.Where(user => user.Id == requestUserId).ExecuteDeleteAsync(cancellationToken);
//            return Convert.ToInt32(requestUserId);

//        }

//        private async Task<bool> UserExists(string userId)
//        {
//            var user = await _context.Users.AsNoTracking().Where(user => user.Id == userId).FirstOrDefaultAsync();
//            return user != null;
//        }
//    }
//}

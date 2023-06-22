using Domain.Entities;
using GestionAnnonce.Application.Common.Interfaces;
using MediatR;

namespace GestionAnnonce.Application.Users.Commands.UpdateUser
{
    public record UpdateUserCommand(int userId,User user): IRequest<int>
    {
    }

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUserAsync(request.userId,request.user,cancellationToken);
        }
    }
}

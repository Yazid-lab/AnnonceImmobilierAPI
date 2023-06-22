using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using GestionAnnonce.Application.Common.Models;
using GestionAnnonce.Application.Users.Commands.DeleteUser;
using GestionAnnonce.Application.Users.Commands.UpdateUser;
using GestionAnnonce.Application.Users.Queries.GetUsers;
using MediatR;

namespace GestionAnnonce.Application.Common.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var userEntities = await _mediator.Send(new GetUsersQuery());
            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

        public async Task<int> UpdateUser(int userId, UpdateUserDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            return await _mediator.Send(new UpdateUserCommand(userId, userEntity));
        }

        public async Task<int> DeleteUser(int userId)
        {
            return await _mediator.Send(new DeleteUserCommand(userId));
        }
    }
}

using sale_webapi.Models;
using sale_webapi.BLL;
using Microsoft.EntityFrameworkCore;
using sale_webapi.DAL;
using sale_webapi.Models;
using server.Models;
using System.Drawing;
using sale_webapi.Models.DTO;
using Castle.Core.Resource;
using AutoMapper;
using Eco.ObjectImplementation;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace sale_webapi.DAL
{
    public class UserDal : IUserDal
    {
        private readonly OrdersContext _ordersContext;
        IMapper _mapper;
        public UserDal(OrdersContext ordersContext, IMapper mapper)
        {
            this._ordersContext = ordersContext ?? throw new ArgumentNullException(nameof(ordersContext));
            _mapper = mapper;
        }

        public async Task<bool> AddUserDal(userdto2 user)
        {
            bool res = await UserExists(user.UserName);
            if (res == false)
            {
                //            
                //var customersDTO = _mapper.Map<List<CustomerDTO>>(customers);
                User _user = _mapper.Map<User>(user);
                _user.role = EnumRoleUser.custumer;

                await _ordersContext.User.AddAsync(_user);
                await _ordersContext.SaveChangesAsync();

                //var a = await _ordersContext.User.ToListAsync();

                return true;
            }
            else { return false; }
        }
        public async Task<bool> UserExists(string username)
        {
            bool res = await _ordersContext.User.AnyAsync(x => x.UserName == username.ToLower());
            return res;
        }

        public async Task<User> AuthenticateDal(UserDto userLogin)
        {
            var currentUser = _ordersContext.User.FirstOrDefault(o => o.UserName.ToLower() ==
            userLogin.UserName.ToLower() && o.UserPassword.ToLower() == userLogin.UserPassword.ToLower());
            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}


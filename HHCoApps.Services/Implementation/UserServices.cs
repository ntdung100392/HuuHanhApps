using AutoMapper;
using HHCoApps.Core.EF;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using HHCoApps.Services.Repos;
using HHCoApps.Services.Repos.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Implementation
{
    public class UserServices : BaseServices, IUserServices
    {
        private IRepository<Users> userRepository;
        public UserServices()
        {
            userRepository = new Repository<Users>(dbContext);
        }

        public bool InsertUser(UserModel user)
        {
            try
            {
                var entity = Mapper.Map<Users>(user);
                entity.IsActive = true;
                entity.IsDeleted = false;
                userRepository.Insert(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserModel GetUserByUserPassword(string user, string pass)
        {
            try
            {
                Users entity = userRepository.GetAll()
                    .Where(u => u.UserName == user && u.PassWord == pass && !u.IsDeleted).FirstOrDefault();
                return Mapper.Map<UserModel>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

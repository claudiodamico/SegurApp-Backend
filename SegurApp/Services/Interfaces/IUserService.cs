﻿using Microsoft.AspNetCore.Mvc;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(Domain.QueryParameters queryParameters);
        User CreateUser(string FullName, string Dni, string Email, string Phone, String Password);
        User LoginUser(string email, string password);
        void DeleteUser(int id);
    }
}

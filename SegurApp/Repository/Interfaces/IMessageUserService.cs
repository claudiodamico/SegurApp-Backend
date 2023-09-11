﻿using SegurApp.Domain.Dto;
using SegurApp.Infraestructure.Entities;

namespace SegurApp.Repository.Interfaces
{
    public interface IMessageUserRepository
    {
        void Add(SendMessageUserDto sendMessageUserDto);
    }
}

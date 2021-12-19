﻿using System;
using System.Collections.Generic;
using System.Linq;
using api.gearstore.logic.Data.DbContext;
using api.gearstore.logic.Models;

namespace api.gearstore.logic.Data.Repositories.Users
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public bool Clean()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
            return !GetAll().Any();
        }

        public bool Create(UserData user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public UserData DeleteById(long id)
        {
            UserData user = GetById(id);
            if (user is not null)
            {
                _context.Users.Remove(user);
            }

            return user;
        }

        public IQueryable<UserData> GetAll()
        {
            return _context.Users;
        }

        public UserData GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public void Update(UserData user)
        {
            UserData old = GetById(user.Id);
            old.CopyFrom(user);

            _context.Users.Update(old);
            _context.SaveChanges();
        }
    }
}

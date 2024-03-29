using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevenNote.Models.User;
using ElevenNote.Data;
using ElevenNote.Data.Entities;

namespace ElevenNote.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
        _context = context;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            UserEntity entity = new()
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(entity);
            int numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}
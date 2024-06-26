﻿namespace Auth.ModelsCore
{
    public class User
    {
        public int Id { get; set; }

        public string Salt { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime CreationTime { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public User(string email, string password, string salt)
        {
            Email = email;
            Password = password;
            CreationTime = DateTime.Now;
            Salt = salt;
        }
    }
}
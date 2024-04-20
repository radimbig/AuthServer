﻿namespace Auth.ModelsCore
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime CreationTime { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
            CreationTime = DateTime.Now;
        }
    }
}
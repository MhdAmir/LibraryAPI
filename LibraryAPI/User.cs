﻿namespace LibraryAPI
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
    }

}

﻿namespace Corgi.Backend.Models
{
    public class User : ICreatedAt, ILastModified
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Character> Characters { get; set; } = [];
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}

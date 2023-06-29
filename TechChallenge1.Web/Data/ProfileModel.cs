﻿namespace TechChallenge1.Web.Data
{
    public class ProfileModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string? UserName { get; set; }
        public string? Biography { get; set; }
        public string? PictureUri { get; set; }
        public string? Gender { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}

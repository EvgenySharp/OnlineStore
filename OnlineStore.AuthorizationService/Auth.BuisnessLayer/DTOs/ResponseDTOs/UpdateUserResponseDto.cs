﻿using Auth.DataAccessLayer.Enums;

namespace Auth.BuisnessLayer.DTOs.ResponseDTOs
{
    public class UpdateUserResponseDto
    {
        public string Name { get; set; }
        public Roles UserRole { get; set; }
        public string Password { get; set; }
    }
}
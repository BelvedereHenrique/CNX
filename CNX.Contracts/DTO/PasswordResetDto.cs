using System;
using CNX.Contracts.Enums;

namespace CNX.Contracts.DTO
{
    public class PasswordResetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid Hash { get; set; }
        public PasswordResetStatusEnum Status { get; set; }
    }
}

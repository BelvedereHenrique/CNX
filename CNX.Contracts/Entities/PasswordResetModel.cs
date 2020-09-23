using System;
using CNX.Contracts.Enums;

namespace CNX.Contracts.Entities
{
    public class PasswordResetModel
    {
        public int Id { get; set; }
        public Guid Hash { get; set; }
        public PasswordResetStatusEnum Status { get; set; }
        public DateTime RequestedOn { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}

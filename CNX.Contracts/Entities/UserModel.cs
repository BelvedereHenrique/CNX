using System.Collections.Generic;

namespace CNX.Contracts.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hometown { get; set; }

        public List<NoteModel> Notes { get; } = new List<NoteModel>();
    }
}

namespace CNX.Contracts.Entities
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}

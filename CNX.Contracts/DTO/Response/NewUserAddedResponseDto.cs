using System;
using System.Collections.Generic;
using System.Text;

namespace CNX.Contracts.DTO.Response
{
    public class NewUserAddedResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hometown { get; set; }
        public List<NoteDto> Notes { get; set; }
    }
}

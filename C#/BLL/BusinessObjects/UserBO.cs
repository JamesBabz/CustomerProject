using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.BusinessObjects
{
    public class UserBO : IBusinessObject
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [NotMapped]
        public string UserPassword { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsAdmin { get; set; }
    }
}

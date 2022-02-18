using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

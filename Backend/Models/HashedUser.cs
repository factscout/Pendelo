namespace Backend.Models
{
    public class HashedUser
    {     
        public string UserName { get; set; }

        public byte[] PasswordHashed { get; set; }

        public byte[] PasswordSalt { get; set; }
    
    }
}

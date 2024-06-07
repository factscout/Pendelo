using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        public int User_id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public float? Km_total { get; set; }
       

        public User(int user_id, string username, string email, float? km_total) {
            User_id = user_id;
            Username = username;
            Email = email;
            Km_total = km_total;

        }
    }
    public class Ride
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public float Km { get; set; } 

        [Required]
        public DateTime Datetime { get; set; } 

        public Ride(int id, int userId, float km, DateTime datetime) {
            Id = id;
            Km = km;
            Datetime = datetime;
        }
        public Ride() { }
    }


}

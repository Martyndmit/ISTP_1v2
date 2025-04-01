using System;
using System.ComponentModel.DataAnnotations;

namespace GymDomain.Entities
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Ім'я відвідувача є обов'язковим")]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        // Якщо потрібно вказувати "улюблений зал" чи "основний зал":
        // public int PreferredGymId { get; set; }
        // public Gym PreferredGym { get; set; }
    }
}

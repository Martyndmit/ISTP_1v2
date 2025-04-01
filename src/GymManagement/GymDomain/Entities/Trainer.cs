using System.ComponentModel.DataAnnotations;

namespace GymDomain.Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }

        [Required(ErrorMessage = "Ім'я тренера є обов'язковим")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Спеціалізація є обов'язковою")]
        [StringLength(100)]
        public string Specialization { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        // Якщо тренер прив'язаний до певного залу:
        // public int GymId { get; set; }
        // public Gym Gym { get; set; }
    }
}


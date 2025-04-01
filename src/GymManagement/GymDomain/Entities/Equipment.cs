using System.ComponentModel.DataAnnotations;

namespace GymDomain.Entities
{
    public class Equipment
    {
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "Назва обладнання є обов'язковою")]
        [Display(Name = "Назва обладнання")]
        public string Name { get; set; }

        [Display(Name = "Бренд")]
        public string Brand { get; set; }

        // Зовнішній ключ (FK) на Gym
        [Required]
        [Display(Name = "Тренажерний зал")]
        public int GymId { get; set; }

        // Навігаційна властивість на Gym
        public Gym Gym { get; set; }
    }
}

using GymDomain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymDomain.Entities
{
    public class Gym
    {
        public int GymId { get; set; }

        [Required(ErrorMessage = "Назва залу є обов'язковою")]
        [Display(Name = "Назва залу")]
        public string Name { get; set; }

        [Display(Name = "Розташування")]
        public string Location { get; set; }

        [Display(Name = "Графік роботи")]
        public string WorkingHours { get; set; }

        [Display(Name = "Місткість")]
        public int Capacity { get; set; }

        // Навігаційна властивість для обладнання
        public ICollection<Equipment> Equipment { get; set; }
    }
}

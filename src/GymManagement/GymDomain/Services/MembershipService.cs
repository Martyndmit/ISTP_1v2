using System;
using GymDomain.Entities;

namespace GymDomain.Services
{
    public class MembershipService
    {
        public decimal CalculateMembershipPrice(Member member)
        {
            // Умовна логіка для прикладу:
            // Знижка для неповнолітніх (до 18 років)
            if (member.DateOfBirth.HasValue && member.DateOfBirth.Value.AddYears(18) > DateTime.Now)
            {
                return 100m; // грн (чи інша валюта)
            }

            // Базова вартість
            return 200m;
        }
    }
}


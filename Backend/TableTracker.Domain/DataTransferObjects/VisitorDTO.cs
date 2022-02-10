using System.Collections.Generic;

namespace TableTracker.Domain.DataTransferObjects
{
    public class VisitorDTO
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public float GeneralTrustFactor { get; set; }

        public ICollection<ReservationDTO> Reservations { get; set; }
    }
}

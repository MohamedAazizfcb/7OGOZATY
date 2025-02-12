using Application.Dtos.AppointmentDTO.Response;
using Application.Dtos.Authentication.Response;
using Domain.Entities.AppointmentEntities;
using Domain.Entities.DoctorCertificateEntity;
using Domain.Entities.FeedbackEntity;
using Domain.Entities.Lookups;
using Domain.Entities.SpecializationServicesEntity;
using Domain.Entities.User;

namespace Application.Dtos.DoctorDTO.Response
{
    public class DoctorResponse : AuthenticationResponse
    {
        public string Brief { get; set; }
        public int CheckPrice { get; set; }

        public int? ClinicId { get; set; }

        public int? SpecializationId { get; set; }
        
        public float AvgFeedbackRating { get; set; } // Rating out of 5
    }
}

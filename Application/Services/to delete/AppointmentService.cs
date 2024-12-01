//using Application.Contracts;
//using AutoMapper;
//using Domain.Dtos.Appointment;
//using Domain.Entities;
//using Domain.Enums;
//using Infrastructure.Data;
//using Domain.Results;
//using Domain.Wrappers;
//using Microsoft.EntityFrameworkCore;

//namespace Application.Implementations
//{
//    public class AppointmentService : ResponseHandler, IAppointmentService
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;
//        private readonly IDoctorService _doctorService;

//        public AppointmentService(ApplicationDbContext context, IMapper mapper, IDoctorService doctorService)
//        {
//            _context = context;
//            _mapper = mapper;
//            _doctorService = doctorService;
//        }

//        private async Task<Appointment> UpdateAppointmentStatus(string appointmentId, AppointmentStatus newStatus)
//        {
//            var appointment = await _context.Appointments.FindAsync(appointmentId);

//            if (appointment != null)
//            {
//                appointment.Status = newStatus;
//                await _context.SaveChangesAsync();
//                return appointment;
//            }
//            else 
//            {
//                return null;
//            }



//        }

//        public async Task<Response<GetAppointmentResponse>> Add(AddAppointmentRequest request)
//        {
//            var appointment = new Appointment
//            {
//                Id = DateTime.Now.ToString(),
//                PatientId = request.PatientId,
//                DoctorId = request.DoctorId,
//                slotId = request.SlotId,
//                Status = AppointmentStatus.Pending,
//                CreatedAt = DateTime.UtcNow
//            };

//            _context.Appointments.Add(appointment);
//            await _doctorService.ChangeSlotStatus(appointment.slotId, SlotStatus.Occupied);
//            await _context.SaveChangesAsync();

//            return Created(_mapper.Map<GetAppointmentResponse>(appointment));
//        }

//        public async Task<Response<GetAppointmentResponse[]>> GetAll()
//        {
//            // Retrieve all appointments
//            var appointments = await _context.Appointments.ToListAsync();

//            // Get all patient and doctor IDs from appointments
//            var patientIds = appointments.Select(a => a.PatientId).Distinct().ToList();
//            var doctorIds = appointments.Select(a => a.DoctorId).Distinct().ToList();

//            // Retrieve patients and doctors
//            var patients = await _context.Users
//                .Where(u => patientIds.Contains(u.Id))
//                .Select(u => new { u.Id, u.FirstName, u.LastName })
//                .ToListAsync();

//            var doctors = await _context.Users
//                .Where(u => doctorIds.Contains(u.Id))
//                .Select(u => new { u.Id, u.FirstName, u.LastName })
//                .ToListAsync();

//            // Create a dictionary for quick lookup of patient and doctor names
//            var patientDict = patients.ToDictionary(p => p.Id, p => $"{p.FirstName} {p.LastName}");
//            var doctorDict = doctors.ToDictionary(d => d.Id, d => $"{d.FirstName} {d.LastName}");

//            // Map appointments to GetAppointmentResponse DTO
//            var appointmentResponses = appointments.Select(appoint =>
//            {
//                var patientName = patientDict.ContainsKey(appoint.PatientId)
//                    ? patientDict[appoint.PatientId]
//                    : "Unknown";

//                var doctorName = doctorDict.ContainsKey(appoint.DoctorId)
//                    ? doctorDict[appoint.DoctorId]
//                    : "Unknown";

//                return new GetAppointmentResponse
//                {
//                    Id = appoint.Id,
//                    PatientName = patientName,
//                    DoctorName = doctorName,
//                    Slot = appoint.Slot,
//                    Status = appoint.Status
//                };
//            }).ToArray();

//            return Success(appointmentResponses);
//        }


//        public async Task<Response<GetAppointmentResponse>> Get(string appointmentId)
//        {
//            // Retrieve the appointment including patient and doctor
//            var appointment = await _context.Appointments
//                .Include(a => a.Patient)
//                .Include(a => a.Doctor)
//                .FirstOrDefaultAsync(a => a.Id == appointmentId);

//            // Check if the appointment exists
//            if (appointment == null)
//            {
//                return NotFound<GetAppointmentResponse>();
//            }

//            // Map appointment to GetAppointmentResponse DTO
//            var appointmentResponse = new GetAppointmentResponse
//            {
//                Id = appointment.Id,
//                PatientId = appointment.PatientId,
//                PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
//                DoctorId = appointment.DoctorId,
//                DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
//                Slot = appointment.Slot,
//                Status = appointment.Status
//            };

//            // Return response
//            return Success(appointmentResponse);
//        }


//        public async Task<Response<string>> AcceptAppointment(string appointmentId)
//        {
//            var appointment = await UpdateAppointmentStatus(appointmentId, AppointmentStatus.Accepted);
//            if(appointment == null)
//            {
//                return NotFound<string>();
//            }

//            // Return response
//            return Success("Success");

//        }

//        public async Task<Response<string>> RejectAppointment(string appointmentId)
//        {
//            var appointment = await UpdateAppointmentStatus(appointmentId, AppointmentStatus.Rejected);
//            if (appointment == null)
//            {
//                return NotFound<string>();
//            }
//            await _doctorService.ChangeSlotStatus(appointment.slotId, SlotStatus.Free);

//            // Return response
//            return Success("Success");
//        }

//        public async Task<Response<string>> CancelAppointment(string appointmentId)
//        {
//            var appointment = await UpdateAppointmentStatus(appointmentId, AppointmentStatus.Cancelled);
//            if (appointment == null)
//            {
//                return NotFound<string>();
//            }
//            await _doctorService.ChangeSlotStatus(appointment.slotId, SlotStatus.Cancelled);

//            // Return response
//            return Success("Success");
//        }

//        public async Task<Response<GetAppointmentResponse>> Reschedule(string appointmentId, RescheduleAppointmentRequest request)
//        {
//            var appointment = await _context.Appointments.FindAsync(appointmentId);

//            if (appointment == null)
//            {
//                return NotFound<GetAppointmentResponse>();
//            }
//            await _doctorService.ChangeSlotStatus(appointment.slotId, SlotStatus.Free); //old slot

//            appointment.slotId = request.SlotId;

//            await _doctorService.ChangeSlotStatus(appointment.slotId, SlotStatus.Occupied); //new slot

//            await _context.SaveChangesAsync();
//            // Retrieve the appointment including patient and doctor
//            var appointmentResul = await _context.Appointments
//                .Include(a => a.Patient)
//                .Include(a => a.Doctor)
//                .FirstOrDefaultAsync(a => a.Id == appointmentId);

//            // Check if the appointment exists
//            if (appointment == null)
//            {
//                return NotFound<GetAppointmentResponse>();
//            }

//            // Map appointment to GetAppointmentResponse DTO
//            var appointmentResponse = new GetAppointmentResponse
//            {
//                Id = appointment.Id,
//                PatientId = appointment.PatientId,
//                PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
//                DoctorId = appointment.DoctorId,
//                DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
//                Slot = appointment.Slot,
//                Status = appointment.Status
//            };
//            return Success(appointmentResponse);
//        }

//        public async Task<Response<GetAppointmentResponse>> ChangeDoctor(string appointmentId, ChangeAppointmentDoctorRequest request)
//        {
//            var appointment = await _context.Appointments.FindAsync(appointmentId);

//            if (appointment == null)
//            {
//                return NotFound<GetAppointmentResponse>();
//            }

//            appointment.DoctorId = request.DoctorId;
//            await _context.SaveChangesAsync();
//            // Retrieve the appointment including patient and doctor
//            var appointmentResul = await _context.Appointments
//                .Include(a => a.Patient)
//                .Include(a => a.Doctor)
//                .FirstOrDefaultAsync(a => a.Id == appointmentId);

//            // Check if the appointment exists
//            if (appointment == null)
//            {
//                return NotFound<GetAppointmentResponse>();
//            }

//            // Map appointment to GetAppointmentResponse DTO
//            var appointmentResponse = new GetAppointmentResponse
//            {
//                Id = appointment.Id,
//                PatientId = appointment.PatientId,
//                PatientName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}",
//                DoctorId = appointment.DoctorId,
//                DoctorName = $"{appointment.Doctor.FirstName} {appointment.Doctor.LastName}",
//                Slot = appointment.Slot,
//                Status = appointment.Status
//            };
//            return Success(appointmentResponse);

//        }
//    }
//}

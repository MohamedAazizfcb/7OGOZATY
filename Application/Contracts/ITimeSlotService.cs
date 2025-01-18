using Application.Dtos.TimeSlot;
using Domain.Entities.AppointmentEntities;
using Domain.Enums;
using Domain.Results;

namespace Application.Contracts
{
    public interface ITimeSlotService
    {
        Task<OperationResultSingle<string>> CreateNewTimeSlot(TimeSlotRequest request);
        Task<OperationResultSingle<string>> UpdateTimeSlotForDoctor(int timeSlotId, TimeSlotRequest request);
        Task<OperationResultSingle<string>> ChangeTimeSlotStatus(int timeSlotId, int newStatusId);
        Task<OperationResultSingle<TimeSlotResponse>> GetByIdAsync(int timeSlotId);
        Task<OperationResultSingle<ICollection<TimeSlotResponse>>> GetAllAsync();
        Task<OperationResultSingle<ICollection<TimeSlotResponse>>> GetDectorTimeSlots(GetDoctorTimeSlostRequest request);
        Task<OperationResultSingle<Appointment>> GetSlotAppointment(int timeSlotId);
    }
}

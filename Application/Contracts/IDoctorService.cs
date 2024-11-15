using Domain.Dtos.Auth;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Enums;
using Domain.Results;

namespace Application.Contracts
{
    public interface IDoctorService
    {
        public Task<Response<List<ScheduleDetail>>> GetDrSlotsByDate(string doctorId, DateTime date);
        public Task<Response<string>> ChangeSlotStatus(string slotId, SlotStatus newStatus);
        public Task<Response<string>> AddSlotForDoctor(string doctorId, DateTime date);
    }
}

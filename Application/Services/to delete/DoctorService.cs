//using Application.Contracts;
//using AutoMapper;
//using Domain.Entities;
//using Domain.Enums;
//using Domain.Results;
//using Domain.Wrappers;
//using Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//namespace Application.Implementations
//{
//    internal class DoctorService : ResponseHandler, IDoctorService
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public DoctorService(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<Response<string>> AddSlotForDoctor(string doctorId, DateTime date)
//        {
//            var doc = await _context.Users
//            .Include(s => s.Schedule)  // Include the ScheduleDetails collection
//            .FirstOrDefaultAsync(s => s.Id == doctorId);

//            // Create the new ScheduleDetail slot
//            var newSlot = new ScheduleDetail
//            {
//                Id = DateTime.Now.ToString(),
//                Date = date.Date,
//                Slot = date.Hour,
//                Status = (int)SlotStatus.Free
//            };

//            await _context.ScheduleDetails.AddAsync(newSlot);

//            // Add the new slot to the schedule's Details collection
//            doc.Schedule.Add(newSlot);

//            await _context.SaveChangesAsync();
//            return Success("added!");
//        }

//        public async Task<Response<string>> ChangeSlotStatus(string slotId, SlotStatus newStatus)
//        {
//                var slot = await _context.Set<ScheduleDetail>().FirstOrDefaultAsync(sd => sd.Id == slotId);

//                if (slot == null)
//                {
//                    return NotFound<string>("slot not found!");
//                }

//                slot.Status = (int)newStatus; 
//                await _context.SaveChangesAsync();

//                return Success("Updated!");
//        }

//        public async Task<Response<List<ScheduleDetail>>> GetDrSlotsByDate(string doctorId, DateTime date)
//        {
//            var doc = await _context.Users.Include(u => u.Schedule).Where(u => u.Id == doctorId)
//                .Select(u => new User
//                {
//                    Id = u.Id,
//                    Schedule = u.Schedule.Where(d => d.Date.Date == date.Date).ToList()
//                })
//                .FirstOrDefaultAsync();


//            return Success(doc?.Schedule);
//        }
//    }
//}

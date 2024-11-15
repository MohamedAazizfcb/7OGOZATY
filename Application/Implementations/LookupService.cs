using Application.Contracts;
using Domain.Entities;
using Domain.Results;
using Domain.Wrappers;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementations
{
    public class LookupService : ResponseHandler, ILookupService
    {
        private readonly ApplicationDbContext _context;

        public LookupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<string>> AddGender(Gender request)
        {
            _context.Genders.Add(request);
            await _context.SaveChangesAsync();
            return Created("Done!");
        }

        public async Task<Response<List<Gender>>> GetGenders()
        {
            var genders = await _context.Genders.ToListAsync();
            return Success(genders);
        }

    }
}

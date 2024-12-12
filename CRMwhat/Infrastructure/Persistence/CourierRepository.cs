using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Infrastructure.Persistence
{
    public class CourierRepository : ICourierRepository
    {
        private readonly AppDbContext _context;

        public CourierRepository(AppDbContext context)
        {
            _context = context;
        }

        public Courier GetById(Guid id)
        {
            return _context.Set<Courier>().FirstOrDefault(c => c.Id == id);
        }

        public List<Courier> GetAll()
        {
            return _context.Set<Courier>().ToList();
        }

        public void Add(Courier courier)
        {
            _context.Set<Courier>().Add(courier);
            _context.SaveChanges();
        }

        public void Update(Courier courier)
        {
            _context.Set<Courier>().Update(courier);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var courier = GetById(id);
            if (courier != null)
            {
                _context.Set<Courier>().Remove(courier);
                _context.SaveChanges();
            }
        }
    }
}

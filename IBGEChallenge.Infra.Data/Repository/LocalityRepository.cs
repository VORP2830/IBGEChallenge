using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Interfaces;
using IBGEChallenge.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace IBGEChallenge.Infra.Data.Repository
{
    public class LocalityRepository : GenericRepository<Locality>, ILocalityRepository
    {
        private readonly ApplicationDbContext _context;
        public LocalityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PageList<Locality>> GetAll(LocalityFilter localityFilter, PageParams pageParams)
        {
            var query = _context.Localities.Where(s => s.Active == true);
            
            if(!string.IsNullOrEmpty(localityFilter.Name))
            {
                query = query.Where(s => s.Name.Contains(localityFilter.Name.ToLower()));
            }   

            if(!string.IsNullOrEmpty(localityFilter.StateName))
            {
                query = query.Where(s => s.State.Name.ToLower().Contains(localityFilter.StateName.ToLower()));
            }   

            if(!string.IsNullOrEmpty(localityFilter.IBGECode))
            {
                query = query.Where(s => s.IBGECode.Contains(localityFilter.IBGECode));
            }           
            var totalCount = await query.CountAsync();

            var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                                .Take(pageParams.PageSize)
                                .ToListAsync();

            return new PageList<Locality>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<Locality> GetById(long id)
        {
            return await _context.Localities.FirstOrDefaultAsync(l => l.Active == true && l.Id == id);
        }
    }
}
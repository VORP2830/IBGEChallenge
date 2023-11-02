using IBGEChallenge.Domain.Entities;
using IBGEChallenge.Domain.Filter;
using IBGEChallenge.Domain.Interfaces;
using IBGEChallenge.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace IBGEChallenge.Infra.Data.Repository
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        private readonly ApplicationDbContext _context;
        public StateRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PageList<State>> GetAll(StateFilter stateFilter, PageParams pageParams)
        {
            var query = _context.States.Where(s => s.Active == true);

            if(!string.IsNullOrEmpty(stateFilter.Name))
            {
                query = query.Where(s => s.Name.ToLower().Contains(stateFilter.Name.ToLower()));
            }      

            var totalCount = await query.CountAsync();

            var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                                .Take(pageParams.PageSize)
                                .ToListAsync();
                                
            return new PageList<State>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
        }
        public async Task<State> GetById(long id)
        {
            return await _context.States.FirstOrDefaultAsync(s => s.Active == true && s.Id == id);
        }
    }
}
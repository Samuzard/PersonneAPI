using PersonneAPI.Data.Repository.IRepository;
using PersonneAPI.Model;

namespace PersonneAPI.Data.Repository
{
    public class PersonneRepository : Repository<Personne>, IPersonneRepository
    {
        private readonly ApplicationDbContext _db;
        public PersonneRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Personne> UpdateAsync(Personne entity)
        {
            entity.UpdateDate = DateTime.Now;
            _db.Personne.Update(entity);
            await SaveAsync(entity);
            return entity;
        }
    }
}

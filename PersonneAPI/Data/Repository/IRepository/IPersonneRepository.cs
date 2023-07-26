using PersonneAPI.Model;

namespace PersonneAPI.Data.Repository.IRepository
{
    public interface IPersonneRepository :  IRepository<Personne>
    {
        Task<Personne> UpdateAsync(Personne entity);
    }
}

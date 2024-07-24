using TechChallenge.Domain.Shared;

namespace TechChallenge.Domain._Shared
{
    public interface IValidator<T> where T : Entity
    {
        public void Validar(T entity);
    }
}

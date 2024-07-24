using TechChallenge.Application.DTO;

namespace TechChallenge.Application.UseCases.Editar
{
    public interface IEditarProdutoUseCase
    {
        public Task Execute(EditarProdutoDTO updateProdutoDTO);
    }
}

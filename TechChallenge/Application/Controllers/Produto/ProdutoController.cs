using AutoMapper;
using Domain.Enuns;
using Domain.Ports;
using TechChallenge.Application.DTO;
using TechChallenge.Application.UseCases;
using TechChallenge.Application.UseCases.Criar;

namespace TechChallenge.Application.Controllers.Produto
{
    public class ProdutoController : IProdutoController
    {
        private IProdutoRepository _produtoRepository;
        private IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<VisualizarProdutoDTO> Criar(CriarProdutoDTO produtoDTO)
        {
            var useCase = new CriarProdutoUseCase(_produtoRepository);
            var result = await useCase.Execute(produtoDTO);
            return _mapper.Map<VisualizarProdutoDTO>(result);
        }

        public async Task Editar(EditarProdutoDTO editarProdutoDTO)
        {
            var useCase = new EditarProdutoUseCase(_produtoRepository);
            await useCase.Execute(editarProdutoDTO);
        }

        public async Task<ListaProdutosDTO> ObterPorCategoria(int categoria)
        {
            var useCase = new ObterProdutoUseCase(_produtoRepository);

            CategoriaProduto c;

            if (!Enum.TryParse(categoria.ToString(), out c))
            {
                throw new Exception("Categoria informada é inválida");
            }

            var produtos = await useCase.ObterPorCategoria(c);

            return _mapper.Map<ListaProdutosDTO>(produtos);
        }

        public async Task<VisualizarProdutoDTO?> ObterPorId(int id)
        {
            var useCase = new ObterProdutoUseCase(_produtoRepository);
            var result = await useCase.ObterPorId(id);
            return _mapper.Map<VisualizarProdutoDTO>(result);
        }

        public async Task Remover(int id)
        {
            var useCase = new RemoverProdutoUseCase(_produtoRepository);
            await useCase.Execute(id);
        }
    }
}

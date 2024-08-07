﻿using Domain.Enuns;

namespace Domain
{
    public static class CategoriaProdutoExtension
    {
        public static int ToInt(this CategoriaProduto categoria)
        {
            return (int)categoria;
        }

        public static string ToText(this CategoriaProduto categoria)
        {
            switch (categoria)
            {
                case CategoriaProduto.LANCHE:
                    return nameof(CategoriaProduto.LANCHE);
                case CategoriaProduto.ACOMPANHAMENTO:
                    return nameof(CategoriaProduto.ACOMPANHAMENTO);
                case CategoriaProduto.BEBIDA:
                    return nameof(CategoriaProduto.BEBIDA);
                case CategoriaProduto.SOBREMESA:
                    return nameof(CategoriaProduto.SOBREMESA);
                default:
                    throw new ArgumentException($"Categoria de produto '{categoria}' não existe!");
            }
        }

        public static CategoriaProduto ToCategoriaProduto(this int categoria)
        {
            switch (categoria)
            {
                case (int)CategoriaProduto.LANCHE:
                    return CategoriaProduto.LANCHE;
                case (int)CategoriaProduto.ACOMPANHAMENTO:
                    return CategoriaProduto.ACOMPANHAMENTO;
                case (int)CategoriaProduto.BEBIDA:
                    return CategoriaProduto.BEBIDA;
                case (int)CategoriaProduto.SOBREMESA:
                    return CategoriaProduto.SOBREMESA;
                default:
                    throw new ArgumentException($"Categoria de produto '{categoria}' não existe!");
            }
        }
    }

    public static class StatusPedidoExtension
    {
        public static string ToText(this StatusPedido status)
        {
            switch (status)
            {
                case StatusPedido.INICIADO:
                    return nameof(StatusPedido.INICIADO);
                case StatusPedido.CANCELADO:
                    return nameof(StatusPedido.CANCELADO);
                case StatusPedido.RECEBIDO:
                    return nameof(StatusPedido.RECEBIDO);
                case StatusPedido.PENDENTE_PAGAMENTO:
                    return nameof(StatusPedido.PENDENTE_PAGAMENTO);
                case StatusPedido.EM_PREPARACAO:
                    return nameof(StatusPedido.EM_PREPARACAO);
                case StatusPedido.PRONTO:
                    return nameof(StatusPedido.PRONTO);
                case StatusPedido.FINALIZADO:
                    return nameof(StatusPedido.FINALIZADO);
                default:
                    throw new ArgumentException($"Status '{status}' não existe!");
            }
        }
    };

    public static class StatusPagamentoExtension
    {
        public static string ToText(this StatusPagamento status)
        {
            switch (status)
            {
                case StatusPagamento.PENDENTE:
                    return nameof(StatusPagamento.PENDENTE);
                case StatusPagamento.APROVADO:
                    return nameof(StatusPagamento.APROVADO);
                case StatusPagamento.REPROVADO:
                    return nameof(StatusPagamento.REPROVADO);
                default:
                    throw new ArgumentException($"Status '{status}' não existe!");
            }
        }
    };

}

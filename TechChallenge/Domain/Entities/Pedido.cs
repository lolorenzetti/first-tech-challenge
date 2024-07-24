using Domain.Enuns;
using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Factory;
using TechChallenge.Domain.Shared;

namespace Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            Status = StatusPedido.PENDENTE_PAGAMENTO;
            Itens = new();

            Validate();
        }

        public int? ClienteId { get; private set; } // Referência ao agregado Cliente
        public StatusPedido Status { get; private set; }
        public List<PedidoItem> Itens { get; private set; }

        public void ReferenciarCliente(int? id)
        {
            ClienteId = id;
        }

        public void AdicionarItens(List<PedidoItem> itens)
        {
            Itens.AddRange(itens);
            Validate();
        }

        public void AdicionarItem(PedidoItem item)
        {
            Itens.Add(item);
            Validate();
        }

        public void RemoverItem(PedidoItem item)
        {
            Itens.Remove(item);
            Validate();
        }

        public decimal CalculaValorTotal()
        {
            decimal result = 0;

            foreach (var item in Itens)
            {
                result += item.Preco * item.Quantidade;
            }

            return result;
        }

        public void Cancelar()
        {
            Status = StatusPedido.CANCELADO;
        }

        public void ReceberPedido()
        {
            Status = StatusPedido.RECEBIDO;
        }

        public void Finalizar()
        {
            Status = StatusPedido.FINALIZADO;
        }

        public override void Validate()
        {
            PedidoValidatorFactory.Create().Validar(this);
            if (this.Notification.HasErrors())
                throw new NotificationError(this.Notification.GetErrors());
        }
    }
}

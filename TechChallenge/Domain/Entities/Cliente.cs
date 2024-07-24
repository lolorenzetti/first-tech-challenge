using TechChallenge.Domain._Shared;
using TechChallenge.Domain.Factory;
using TechChallenge.Domain.Shared;

namespace Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;

            Validate();
        }

        public string Nome { get; }
        public string Email { get; }
        public string Cpf { get; }

        public override void Validate()
        {
            ClienteValidatorFactory.Create().Validar(this);
            if (this.Notification.HasErrors())
                throw new NotificationError(this.Notification.GetErrors());
        }
    }
}

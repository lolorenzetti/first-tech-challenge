using System.Text.Json;
using TechChallenge.Domain.Shared;

namespace TechChallenge.Domain._Shared
{
    public class NotificationError : Exception
    {
        public NotificationError(IEnumerable<NotificationErrorProp> erros)
            : base(JsonSerializer.Serialize(erros))
        {
        }
    }
}

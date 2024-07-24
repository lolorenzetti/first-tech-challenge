namespace TechChallenge.Domain.Shared
{
    public record NotificationErrorProp
    {
        public string Message { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
    }

    public class Notification
    {
        private List<NotificationErrorProp> Errors = new List<NotificationErrorProp>();


        public void AddError(NotificationErrorProp message)
        {
            Errors.Add(message);
        }

        public IEnumerable<NotificationErrorProp> GetErrors()
        {
            return Errors;
        }

        public bool HasErrors()
        {
            return Errors.Count > 0;
        }
    }
}

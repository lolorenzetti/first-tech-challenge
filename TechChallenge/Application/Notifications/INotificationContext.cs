using Application.Notifications;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Application.Notifications
{
    public interface INotificationContext
    {
        public void AddNotification(string key, string message);
        public void AddNotification(Notification notification);
        public void AddNotifications(IEnumerable<Notification> notifications);
        public void AddNotifications(IReadOnlyCollection<Notification> notifications);
        public void AddNotifications(IList<Notification> notifications);
        public void AddNotifications(ICollection<Notification> notifications);
        public void AddNotifications(ValidationResult validationResult);
    }
}

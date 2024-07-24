namespace TechChallenge.Domain.Shared
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public Notification Notification { get; private set; } = new Notification();
        public abstract void Validate();
    }
}

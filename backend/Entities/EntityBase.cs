using Flunt.Notifications;

namespace CrudLancamentos.Entities;

public abstract class EntityBase : Notifiable<Notification>
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string IdCurto => Id.ToString()[..8];
}
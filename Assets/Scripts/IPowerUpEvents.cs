using UnityEngine.EventSystems;

    public interface IPowerUpEvents : IEventSystemHandler
    {
        void OnPowerUpCollected(PowerUp powerUp, TurtleControl player);

        void OnPowerUpExpired(PowerUp powerUp, TurtleControl player);
    }

using UnityEngine.EventSystems;

/// <summary>
/// Interface defining messages sent by the main game controller
/// </summary>
public interface IMainGameEvents : IEventSystemHandler
{
    void OnGameLost ();
}

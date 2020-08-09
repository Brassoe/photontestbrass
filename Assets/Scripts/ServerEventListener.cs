using UnityEngine;

public class ServerEventListener : Bolt.GlobalEventListener
{
    public override void OnEvent(PlayerJoinedEvent evnt)
    {
        Debug.LogWarning(evnt.Message);
    }
}

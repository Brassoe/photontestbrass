using System;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;

public class Menu : Bolt.GlobalEventListener
{
    public void StartServer()
    {
        BoltLauncher.StartServer();
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    public override void BoltStartDone()
    {
        if (BoltNetwork.IsServer)
        {
            string matchName = "Test Match";

            BoltMatchmaking.CreateSession(
                sessionID: matchName,
                sceneToLoad: "SampleScene"
            );
        }

    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        //hello my friend
        //Change hello
        foreach ( var session in sessionList )
        {
            UdpSession photonSession = session.Value as UdpSession;

            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }



    }
}

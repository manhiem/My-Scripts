using System;
using Bolt;
using Bolt.Matchmaking;
using UdpKit;
using UnityEngine;
using UnityEngine.UI;

public class Menu : GlobalEventListener
{
    //public GameObject canvas1;
    //public GameObject canvas;

    //public Button create;
    //public Button join;
    public void StartServer()
    {
        BoltLauncher.StartServer();
    }

    public override void BoltStartDone()
    {
        BoltMatchmaking.CreateSession(sessionID: "test", sceneToLoad: "Ar-Scene");

        //var spawnPos = new Vector3(0, 0, 0);
        /*BoltNetwork.Instantiate(Device, spawnPos, Quaternion.identity);*/
        //BoltNetwork.Instantiate(canvas, spawnPos, Quaternion.identity);


        //reate.gameObject.SetActive(false);
        //join.gameObject.SetActive(false);
    }

    public void StartClient()
    {
        BoltLauncher.StartClient();
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach (var session in sessionList)
        {
            UdpSession photonSession = session.Value as UdpSession;
            if (photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }
}

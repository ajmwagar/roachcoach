using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetManager : NetworkManager 
{
    public GameObject chefPrefab;
    public GameObject mousePrefab;
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader) 
    {
        NetworkMessage message = extraMessageReader.ReadMessage< NetworkMessage>();
        int playerType = message.playerType;

        GameObject spawnPrefab = playerPrefab;
        Vector3 startPos = Vector3.zero;

        if(playerType == 0)
        {
            spawnPrefab = chefPrefab;
            startPos = new Vector3(2,2,2);
        }
        else
        {
            spawnPrefab = mousePrefab;
            startPos = new Vector3(-2,2,-2);
        }

        GameObject player = (GameObject)Instantiate(spawnPrefab, startPos, Quaternion.identity);

        if(playerType == 1)
        {
            var mouse = player.GetComponent<Mouse>();
            mouse.playerName = message.playerName;
            mouse.playerColor = message.playerColor;
        }
        else
        {
            spawnPrefab = mousePrefab;
            startPos = new Vector3(-2,2,-2);
        }

        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

    public override void OnClientConnect(NetworkConnection conn) 
    {
        NetworkMessage netMessage = new NetworkMessage();

        netMessage.playerType = GameManager.playerType == PlayerType.Chef  ? 0 : 1;
        netMessage.playerName = GameManager.playerName;
        netMessage.playerColor = GameManager.playerColor;
 
        ClientScene.AddPlayer(conn, 0, netMessage);
    }

    public override void OnClientSceneChanged(NetworkConnection conn) 
    {
        //base.OnClientSceneChanged(conn);
    }

    public void RegisterPrefab(GameObject prefab)
    {
        ClientScene.RegisterPrefab(prefab);
    }
}

public class NetworkMessage : MessageBase 
{
    public string playerName;
    public int playerType;
    public Color playerColor;
}
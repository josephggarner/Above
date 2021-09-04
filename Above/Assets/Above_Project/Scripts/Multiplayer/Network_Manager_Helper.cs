
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.Spawning;

public class Network_Manager_Helper : NetworkBehaviour
{

    public void Start()
    {

#if SERVER_BUILD
        
#else
        NetworkManager.Singleton.StartClient();
        //UpdateNetworkManager();
        SpawnPlayerServerRpc();
#endif

    }

    public void UpdateNetworkManager()
    {
        //load selected character prefab
        //NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClientId].PlayerObject.SpawnAsPlayerObject(Player_PreConn_Data.Instance.selectedChar.GetComponent<NetworkObject>().NetworkObjectId);
        //Player_PreConn_Data.Instance.selectedChar.GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);

    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnPlayerServerRpc()
    {
       
        // Spawn on Client
        GameObject go = Instantiate(Player_PreConn_Data.Instance.selectedChar,new Vector3(0,0,0), Quaternion.identity);
        
        go.GetComponent<NetworkObject>().SpawnAsPlayerObject(NetworkManager.Singleton.LocalClientId);
        
        
        ulong objectId = go.GetComponent<NetworkObject>().NetworkObjectId;

        SpawnClientRpc(objectId);

    }

    // A ClientRpc can be invoked by the server to be executed on a client
    [ClientRpc]
    private void SpawnClientRpc(ulong objectId)
    {
        NetworkObject player = NetworkSpawnManager.SpawnedObjects[objectId];
    }

}

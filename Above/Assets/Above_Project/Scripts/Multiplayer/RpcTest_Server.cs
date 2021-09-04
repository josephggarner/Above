#define SERVER_BUILD
using MLAPI;
using MLAPI.Messaging;
using UnityEngine;

public partial class RpcTest : NetworkBehaviour
{
    enum ItemType
    {
        Potion,Sword
    }


    [ServerRpc]
    void TestServerRpc(int value)
    {
#if SERVER_BUILD 
       if (IsServer)
        {
            Debug.Log("Server Received the RPC #" + value);
            TestClientRpc(value);
        }
#endif
    }


}

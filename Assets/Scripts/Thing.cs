using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Thing : NetworkBehaviour
{
    public void Say(string message)
    {
        Debug.Log(message);
    }

    [ClientRpc]
    public void RpcSay(string message)
    {
        Debug.Log(message);
    }
}

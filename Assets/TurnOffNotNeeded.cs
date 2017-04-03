using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;

public class TurnOffNotNeeded : NetworkBehaviour
{
    [SerializeField]
    private MonoBehaviour[]  components;
    [SerializeField]
    private MonoBehaviour[] VRcomponents;

    void Awake()
    {
        if (NetworkServer.connections.Count > 0)
        {
            Debug.Log("Im host");
        }
        else
        {
            Debug.Log("Im Client of HTC");


            components = GetComponentsInChildren<MonoBehaviour>();
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i].ToString().Contains("SteamVR"))
                {
                    components[i].enabled = true;
                }
            }
        }

    }
}

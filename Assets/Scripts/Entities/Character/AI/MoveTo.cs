using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : NetworkBehaviour {

    [SerializeField]
    public Transform goal;

    void Awake()
    {
        if (NetworkServer.connections.Count > 0)
        {
        }
        else
        {
            this.enabled = false;
        }
    }

    void Start() {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
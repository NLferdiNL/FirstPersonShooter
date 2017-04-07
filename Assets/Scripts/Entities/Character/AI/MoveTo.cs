using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
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
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
}
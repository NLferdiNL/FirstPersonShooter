using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour {

    [SerializeField]
    public Transform goal;

    void Start() {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
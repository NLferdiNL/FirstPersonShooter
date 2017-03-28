using UnityEngine;

public class BehaviorAnim : MonoBehaviour {

    Animator animator;

    new Transform transform;

    Vector3 lastPos;

    void Start() {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>().parent.GetComponent<Transform>();
        lastPos = transform.position;
    }

    void LateUpdate() {
        bool walking = lastPos != transform.position;
        lastPos = transform.position;
        animator.SetBool("walking", walking);

        //RaycastHit hit; //Attack
    }

}

using UnityEngine;

[RequireComponent(typeof(InputData))]
public class CharacterMovement : MonoBehaviour {

    InputData inputData;
    Transform tf;
    Rigidbody rb;

    [SerializeField]
    float walkSpeed = 5.0f;

    [SerializeField]
    float jumpStrength = 5.0f;

    [SerializeField, Tooltip("This is the divider to not make the player seem like going insane speeds. But to allow for whole numbers in maxSpeed. Real speed is maxSpeed divided by this.")]
    float movementDivider = 30.0f;

    bool touchingGround = false;

    void Start() {
        inputData = GetComponent<InputData>();
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other) {
        if(!other.isTrigger)
            touchingGround = true;
    }

    void OnTriggerStay(Collider other) {
        if (!other.isTrigger)
            touchingGround = true;
    }

    void OnTriggerExit(Collider other) {
        if (!other.isTrigger)
            touchingGround = false;
    }

    void FixedUpdate() {
        Vector3 movement = inputData.movement;

        tf.Translate(new Vector3(movement.x * (walkSpeed / movementDivider),
                                 0, 
                                 -movement.z * (walkSpeed / movementDivider)));

        if (movement.y == 1 && touchingGround) {
            rb.AddForce(tf.up * jumpStrength, ForceMode.Impulse);
        }
    }
}

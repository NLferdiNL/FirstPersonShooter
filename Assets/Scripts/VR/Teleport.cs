using UnityEngine;

[RequireComponent(typeof(InputData))]
public class Teleport : MonoBehaviour {

    new Transform transform;
    [SerializeField]
    Transform CamRig;

    Animator anim;
    InputData inputData;
    LineRenderer teleLine;

    void Start() {
        transform = GetComponent<Transform>();
        inputData = GetComponent<InputData>();
        teleLine = GetComponent<LineRenderer>();
    }

    void FixedUpdate() {
        if (inputData.rightClick) {
            ActivateTeleport();
        }
    }

    void ActivateTeleport() {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10)) {

        }
    }

    void ShowLine() {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10)) {
            teleLine.SetPositions(new Vector3[2]{transform.position, hit.point});
        }
    }

    void ToggleFade() {

    }

}

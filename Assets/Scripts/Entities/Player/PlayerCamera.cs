using UnityEngine;

[RequireComponent(typeof(InputData))]
public class PlayerCamera : MonoBehaviour {

    [SerializeField]
    float maxUpView = -50;

    [SerializeField]
    float maxDownView = 60;

    [SerializeField]
    float cameraSensitivity = 5f;

    [SerializeField]
    Camera cam;

    Transform bodyTransform;
    Transform cameraTransform;

    InputData inputData;

    float currentRot = 0.0f;

    void Start() {
        bodyTransform = GetComponent<Transform>();
        cameraTransform = cam.GetComponent<Transform>();

        inputData = GetComponent<InputData>();
    }

    void FixedUpdate() {
        bodyTransform.Rotate(new Vector3(0, inputData.cameraMovement.y * cameraSensitivity, 0));

        currentRot += inputData.cameraMovement.x * cameraSensitivity;

        if (currentRot > maxDownView) {
            currentRot = maxDownView;
        } else if (currentRot < maxUpView) {
            currentRot = maxUpView;
        }

        cameraTransform.rotation = Quaternion.Euler(new Vector3(currentRot, bodyTransform.rotation.eulerAngles.y + 90, 0));
    }

}

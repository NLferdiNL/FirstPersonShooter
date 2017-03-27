using UnityEngine;

[RequireComponent(typeof(InputData))]
public class KeyboardInput : MonoBehaviour {

    InputData inputData;

    [SerializeField]
    bool invertedX = false;

    [SerializeField]
    bool invertedY = false;

    [SerializeField]
    Vector2 newCameraMovement;

    void Start() {
        inputData = GetComponent<InputData>();
    }

    void FixedUpdate() {
        Vector3 newMovement = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if (Input.GetButton("Jump")) {
            newMovement.y = 1;
        } else {
            newMovement.y = 0;
        }

        inputData.interact = Input.GetButtonDown("Interact");

        inputData.leftClick = Input.GetMouseButton(0);

        inputData.leftClickDown = Input.GetMouseButtonDown(0);

        inputData.rightClick = Input.GetMouseButton(1);

        inputData.rightClickDown = Input.GetMouseButtonDown(1);

        inputData.movement = newMovement;

        newCameraMovement = new Vector2(Input.GetAxis("Mouse Y"),
                                        Input.GetAxis("Mouse X"));

        if (!invertedX) {
            newCameraMovement.x = -newCameraMovement.x;
        }

        if (invertedY) {
            newCameraMovement.y = -newCameraMovement.y;
        }

        inputData.cameraMovement = newCameraMovement;

        if (Input.GetKeyDown(KeyCode.F11)) {
            if (Cursor.visible) {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Screen.fullScreen = true;
            } else {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Screen.fullScreen = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Screen.fullScreen = false;
        }
    }
}

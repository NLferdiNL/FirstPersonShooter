using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(InputData))]
public class OpenVRInput : MonoBehaviour {

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    [SerializeField]
    private SteamVR_TrackedObject leftControllerObject;

    [SerializeField]
    private SteamVR_TrackedObject rightControllerObject;

    private SteamVR_Controller.Device leftController {
        get { return SteamVR_Controller.Input((int)leftControllerObject.index); }
    }

    private SteamVR_Controller.Device rightController
    {
        get { return SteamVR_Controller.Input((int)rightControllerObject.index); }
    }

    InputData inputData;

    void Start() {
        inputData = GetComponent<InputData>();
    }

    void FixedUpdate() {
        if (leftController == null || rightController == null) {

            Debug.LogError("Controller not initialized");

            return;

        }

        inputData.leftClick = leftController.GetPress(triggerButton);

        inputData.leftClickDown = leftController.GetPressDown(triggerButton);

        inputData.rightClick = leftController.GetPress(triggerButton);

        inputData.rightClickDown = leftController.GetPressDown(triggerButton);

        if (inputData.leftVibrationLength > 0)
            StartCoroutine("LeftVibrate");

        if (inputData.rightVibrationLength > 0)
            StartCoroutine("RightVibrate");


    }

    IEnumerator LeftVibrate() {
        for (float i = 0; i < inputData.leftVibrationLength; i += Time.deltaTime) {
            leftController.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, inputData.leftVibrationStrength));
            yield return null;
        }

        inputData.leftVibrationStrength = 0;
        inputData.leftVibrationLength = 0;
    }

    IEnumerator RightVibrate()
    {
        for (float i = 0; i < inputData.rightVibrationLength; i += Time.deltaTime)
        {
            leftController.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, inputData.rightVibrationStrength));
            yield return null;
        }

        inputData.leftVibrationStrength = 0;
        inputData.leftVibrationLength = 0;
    }
}

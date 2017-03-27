using UnityEngine;

[RequireComponent(typeof(InputData))]
public class OpenVRInput : MonoBehaviour {

    public bool triggerButtonDown = false;

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    [SerializeField]
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device controller {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    InputData inputData;

    void Start() {
        inputData = GetComponent<InputData>();
        if(trackedObj == null)
            trackedObj = transform.parent.GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate() {
        if (controller == null) {

            Debug.LogError("Controller not initialized");

            //return;

        }

        inputData.leftClick = controller.GetPress(triggerButton);

        inputData.leftClickDown = controller.GetPressDown(triggerButton);
        
    }
}

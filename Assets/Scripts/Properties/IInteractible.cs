using UnityEngine;

public class IInteractible : MonoBehaviour {

    [SerializeField]
    protected float cooldownTimer = 0.0f;

    protected float coolingDownTime = 0.0f;

    public virtual void Interact() {
        Debug.LogError(this.GetType() + " has not defined a custom Interact function and will do nothing when it is used.");
    }
}

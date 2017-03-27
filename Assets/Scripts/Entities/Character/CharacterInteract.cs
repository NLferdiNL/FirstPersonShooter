using UnityEngine;

[RequireComponent(typeof(InputData))]
public class CharacterInteract : MonoBehaviour {

    InputData inputData;
    CharacterStatus status;
    CharacterAttack attacker;

    [SerializeField]
    LayerMask rayCastMask;

    [SerializeField]
    float maxReach = 3.0f;

    void Start() {
        inputData = GetComponent<InputData>();
        status = GetComponent<CharacterStatus>();
    }

    void FixedUpdate() {
        if (inputData.interact) {
            Interact();
        }
    }

    void Interact() {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxReach)) {
            //Debug.DrawLine(ray.origin, hit.point, Color.red, 10);

            IInteractible interactible = hit.transform.gameObject.GetComponent<IInteractible>();
            IPickUp iPickUp = hit.transform.gameObject.GetComponent<IPickUp>();

            if (interactible != null) {
                interactible.Interact();
            } else if (iPickUp != null) {
                iPickUp.Interact(this);
            }
        }
    }

    public void GiveWeapon(GameObject weapon) {
        if (attacker != null) {
            GameObject droppedWeapon = attacker.currentWeapon.gameObject;
            weapon.transform.parent = droppedWeapon.transform.parent;
            droppedWeapon.transform.parent = null;

            attacker.currentWeapon = weapon.GetComponent<Item>();
            attacker.transform.position = droppedWeapon.transform.position;
            droppedWeapon.GetComponent<Rigidbody>().isKinematic = false;
            weapon.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Heal(float points) {
        if (status != null) {
            status.Heal(points);
        }
    }

    public void Damage(float damage) {
        if (status != null) {
            status.Damage(damage);
        }
    }
}

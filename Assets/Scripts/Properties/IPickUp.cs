using UnityEngine;

public class IPickUp : MonoBehaviour {

    public void Interact(CharacterInteract other) {
        other.GiveWeapon(gameObject);
    }

}

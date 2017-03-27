using UnityEngine;

// TBD: Come up with a better name.
public class CharacterStatus : IDamagable {

    [SerializeField]
    bool destroyMe = false;

    protected override void OnDeath() {
        transform.Rotate(new Vector3(0, 0, 1), 90);

        if(destroyMe)
            Destroy(gameObject);
    }
}

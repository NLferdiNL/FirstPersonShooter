using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicsDamageable : IDamagable {

    Rigidbody rigidbody;

    protected void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected void Update() {
        transform.localScale = transform.localScale;
    }

    protected override void OnDeath() {
        rigidbody.constraints = RigidbodyConstraints.None;
    }

}

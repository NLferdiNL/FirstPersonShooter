using System.Collections;
using UnityEngine;

public class BaseProjectile : MonoBehaviour {

    protected float speed; // How fast will I travel.

    protected float lifetime; // For how many seconds I will live.

    protected float health; // How much objects can I penetrate before coming to an halt.

    protected float damage;

    protected GameObject owner;

    protected bool initialized = false;

    new Transform transform;

    AudioSource audioSource;

    public void Initialize(ProjectileData data, GameObject _owner) {
        speed = data.speed;
        lifetime = data.lifetime;
        health = data.health;
        damage = data.damage;
        owner = _owner;

        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = data.impactNoise;

        initialized = true;
    }

    protected void FixedUpdate() {
        if (initialized) {
            lifetime -= Time.fixedDeltaTime * 10;

            if(lifetime <= 0) {
                EndProjectile();
            }

            transform.position += transform.forward * (speed / 30) / Time.fixedDeltaTime;
        }
    }

    protected void OnTriggerEnter(Collider other) {
        //Debug.Log("hit " + other.name);

        Rigidbody otherRb = other.GetComponent<Rigidbody>();

        if (other.gameObject == owner) {
            //Debug.Log("suicide???");
            return;
        }

        if (otherRb != null) {
            otherRb.AddForce(transform.forward * speed, ForceMode.Impulse);
            //otherRb.AddExplosionForce(speed * 5, transform.position, 10, 5, ForceMode.Impulse);
        }

        IDamagable idmg = other.GetComponent<IDamagable>();

        if (idmg != null) {
            //Debug.Log("found");
            idmg.Damage(damage);

            if (idmg.penetrable) {
                health -= idmg.penetrationDamage;
            } else {
                StartCoroutine(EndAfterAudio());
            }

            if (health <= 0) {
                StartCoroutine(EndAfterAudio());
            }
        } else {
            StartCoroutine(EndAfterAudio());
        }
    }

    void EndProjectile() {
        Destroy(gameObject);
    }

    IEnumerator EndAfterAudio() {
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        EndProjectile();
    }
}
    
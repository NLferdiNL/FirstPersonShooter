using UnityEngine;

/// <summary>
/// To be used by characters and destructible objects.
/// </summary>
public class IDamagable : MonoBehaviour {

    [SerializeField]
    protected float _health = 100.0f;

    [SerializeField]
    protected float _maxHealth = 100.0f;

    [SerializeField]
    protected bool _penetrable = true;

    [SerializeField]
    protected float _penetrationDamage = 1.0f;

    public float health {
        get { return _health; }
    }

    public float maxHealth {
        get { return _maxHealth; }
    }

    public float penetrationDamage {
        get { return _penetrationDamage; }
    }

    public bool penetrable {
        get { return _penetrable; }
    }

    /// <summary>
    /// Damage this entity. Returns true if this killed it.
    /// </summary>
    /// <param name="points">How much damage are you inflicting?</param>
    /// <returns>Did you kill me?</returns>
    public bool Damage(float points) {
        if (points < 0) {
            Heal(-points);
            Debug.LogError("You are trying to heal an entity using the damage function. Instead I've sent the instructions to Heal()");
            return false;
        }

        if (_health == 0) {
            return false;
        }

        _health -= points;

        if (_health <= 0) {
            _health = 0;
            OnDeath();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Heal this entity.
    /// </summary>
    /// <param name="points">How much will you heal me for?</param>
    public void Heal(float points) {
        if (points < 0) {
            Heal(-points);
            Debug.LogError("You are trying to damage an entity using the heal function. Instead I've sent the instructions to Damage(). This eliminates kill confirmation.");
            return;
        }
        _health += points;

        if (_health >= _maxHealth) {
            _health = _maxHealth;
        }
    }

    protected virtual void OnDeath() {
        Debug.LogError(this.GetType() + " has not defined a custom OnDeath function and will do nothing when it dies.");
    }
}

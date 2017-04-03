using UnityEngine;

public class ProjectileData : MonoBehaviour {

    [SerializeField]
    float _health;

    [SerializeField]
    float _speed;

    [SerializeField]
    float _lifetime;

    [SerializeField]
    float _damage;

    [SerializeField]
    AudioClip _impactNoise;

    public float health {
        get { return _health; }
    }

    public float speed {
        get { return _speed; }
    }

    public float lifetime {
        get { return _lifetime; }
    }

    public float damage {
        get { return _damage; }
    }

    public AudioClip impactNoise {
        get { return _impactNoise; }
    }

}

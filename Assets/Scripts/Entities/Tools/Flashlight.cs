using UnityEngine;

public class Flashlight : Item {

    [SerializeField]
    new Light light; 

    new void Start() {
        base.Start();

        if (light == null) {
            light = GetComponent<Light>();
        }

        if (light == null) {
            throw new System.ArgumentNullException("No light component was found or added.");
        }
    }

    void FixedUpdate() {
        light.intensity = _abilityEnabled ? 1 : 0.1f;
        if(_abilityEnabled)
            _audioSource.Play();
    }
    
}

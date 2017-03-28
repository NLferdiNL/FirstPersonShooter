﻿using UnityEngine;

public class Flashlight : Item {

    [SerializeField]
    Light light; 

    void Start() {
        if (light == null) {
            light = GetComponent<Light>();
        }

        if (light == null) {
            throw new System.ArgumentNullException("No light component was found or added.");
        }
    }

    void FixedUpdate() {
        light.intensity = _abilityEnabled ? 1 : 0.1f;
    }
    
}

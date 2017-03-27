﻿using System.Collections;
using UnityEngine;

public class Item : IPickUp {

    [SerializeField]
    protected string _type = "";

    [SerializeField]
    protected GameObject _body;

    [SerializeField]
    protected float _damage = 1.0f;

    [SerializeField]
    protected float _cooldownTime = 2.0f;

    [SerializeField]
    protected float _maxReach = 5.0f;

    [SerializeField]
    protected bool _attackDown = false;

    [SerializeField]
    protected GameObject _owner;

    protected Animator _animator;

    public float maxReach {
        get { return _maxReach; }
    }

    protected bool _isReady = true;

    protected bool _secondary = false;

    [SerializeField]
    protected bool _abilityEnabled = false;

    public string type {
        get { return _type; }
    }

    public bool abilityEnabled {
        get { return _abilityEnabled; }
        set { _abilityEnabled = value; }
    }

    public bool isReady {
        get { return _isReady; }
    }

    public float damage {
        get { return _damage; }
    }

    public bool attackDown {
        get { return _attackDown; }
        set { _attackDown = value; }
    }

    public GameObject owner {
        get { return _owner; }
        set { _owner = value; }
    }

    public void Primary() {
        if (_isReady) {
            _isReady = false;
            StartCoroutine("_StartCooldown");
            PrimaryFire();
        }
    }

    protected void PrimaryFire() {
        Debug.LogError(this.GetType() + " has not defined a custom PrimaryFire function and will do nothing when it is used.");
    }

    public void Secondary(bool value) {
        Debug.LogError(this.GetType() + " has not defined a custom Secondary function and will do nothing when it is used.");
    }

    public void Secondary() {
        Debug.LogError(this.GetType() + " has not defined a custom Secondary function and will do nothing when it is used.");
    }

    public void ToggleEnabled() {
        _abilityEnabled = !_abilityEnabled;
    }

    IEnumerator _StartCooldown() {
        yield return new WaitForSeconds(_cooldownTime);
        _isReady = true;
    }
}
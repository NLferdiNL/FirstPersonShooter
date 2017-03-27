using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ProjectileData))]
public class ProjectileWeapon : Item {

    [SerializeField]
    protected GameObject _projectile;

    [SerializeField]
    protected float _projectileSpread = 0.0f;

    [SerializeField]
    protected int _projectilesToFire = 1;

    [SerializeField]
    protected int _ammoBag = 200;

    [SerializeField]
    protected int _clipSize = 12;

    [SerializeField]
    protected int _currentClip = 0;

    [SerializeField]
    protected float _reloadTime = 5.0f;

    [SerializeField]
    protected float _weaponCooldown = 1.0f;

    [SerializeField]
    protected Transform _bulletExit;

    protected bool _reloading = false;

    [SerializeField]
    protected bool _weaponCooling = false;

    protected Transform _transform;

    protected ProjectileData _projData;

    protected void Start() {
        _transform = GetComponent<Transform>();
        _projData = GetComponent<ProjectileData>();
    }

    protected void FixedUpdate() {
        if (_attackDown) {
            Fire();
        }
    }

    protected void Fire() {
        if (_currentClip > 0 && !_reloading && !_weaponCooling) {
            _currentClip -= 1;
            StartCoroutine("WeaponCooldown");
            SpawnProjectiles();
        } else if(!_reloading && _currentClip == 0) {
            ReloadClip();
        }
    }

    protected void SpawnProjectiles() {
        for (int i = 0; i < _projectilesToFire; i++) {
            GameObject projectile = Instantiate<GameObject>(_projectile);
            Transform projTransform = projectile.GetComponent<Transform>();

            projTransform.position = _bulletExit.position;
            projTransform.rotation = _bulletExit.rotation;

            projTransform.Rotate(new Vector3(Random.Range(0, _projectileSpread),
                                             Random.Range(0,_projectileSpread),
                                             0));

            projectile.GetComponent<BaseProjectile>().Initialize(_projData, _owner);
        }
    }

    public void ReloadClip() {
        if (!_reloading) {
            StartCoroutine("ReloadTimer");
        }
    }

    IEnumerator ReloadTimer() {
        _reloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _ammoBag -= (_clipSize - _currentClip);
        _currentClip = _clipSize;
        _reloading = false;
    }

    IEnumerator WeaponCooldown() {
        _weaponCooling = true;
        yield return new WaitForSeconds(_weaponCooldown);
        _weaponCooling = false;
    }
}

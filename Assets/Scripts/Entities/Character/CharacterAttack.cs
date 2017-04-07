using System.Collections;
using UnityEngine;

// TBD: Revamp weapons system.
[RequireComponent(typeof(InputData))]
public class CharacterAttack : MonoBehaviour {

    InputData inputData;

    [SerializeField]
    Item _currentWeapon;

    public Item currentWeapon {
        get { return currentWeapon; }
        set { currentWeapon = value; }
    }

#pragma warning disable 414 // Disable the never used warning
    [SerializeField]
    float punchDamage = 1.0f;

    [SerializeField, Range(0,1)]
    float vibrationStrength = 1;

    [SerializeField]
    float vibrationLength = 0.5f;

    [SerializeField]
    float punchReach = 2.0f;

    [SerializeField]
    float _punchCooldown = 3.0f;

    bool _punchCooling = false;

    bool inAction;
#pragma warning restore 414 // Restore it

    void Start() {
        inputData = GetComponent<InputData>();
    }

    void FixedUpdate() {
        bool leftClick = inputData.leftClick;
        bool leftClickDown = inputData.leftClickDown;

        bool rightClick = inputData.rightClick;
        bool rightClickDown = inputData.rightClickDown;
        

        if ((leftClick || leftClickDown) && (rightClick || rightClickDown)) {
            leftClick = rightClick = false;
        }

        System.Type currentWepType = _currentWeapon.GetType();
        if (currentWepType == typeof(ProjectileWeapon)) {
            if (_currentWeapon.owner != gameObject) {
                _currentWeapon.owner = gameObject;
            }
            _currentWeapon.attackDown = _currentWeapon.automatic ? leftClick : leftClickDown;
            if (_currentWeapon.isFiring) {
                inputData.vibrationStrength = vibrationStrength;
                inputData.vibrationLength = vibrationLength;
            }
        } else if (_currentWeapon.type == "Tool") {
            if(leftClickDown) {
                _currentWeapon.ToggleEnabled();
            }
        }/* else if (leftClick) {
            Primary();
        } else if (rightClick) {
            Secondary();
        }*/

    }

    /*void Primary() {
        if (_currentWeapon != null) {
            if (_currentWeapon.GetType() == typeof(MeleeWeapon)) {
                if (_currentWeapon.isReady) {
                    _currentWeapon.Primary();
                    PrimaryMelee();
                }
            }
        } else {
            if (!_punchCooling) {
                Strike(punchReach, punchDamage);
                StartCoroutine("PunchCooldownTimer");
            }
        }
    }

    void Secondary() {
        if (_currentWeapon != null) {
            if (_currentWeapon.GetType() == typeof(MeleeWeapon)) {
                if (_currentWeapon.isReady) {
                    _currentWeapon.Primary();
                    PrimaryMelee();
                }
            } else if (_currentWeapon.GetType() == typeof(ProjectileWeapon)) {
                // TBD
            }
        }
    }
    
    void PrimaryMelee() {
        Strike(_currentWeapon.maxReach, _currentWeapon.damage);
    }
     
    void SecondaryMelee() {

    }*/

    void Strike(float reach, float damage) {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, reach)) {
            IDamagable idamage = hit.transform.gameObject.GetComponent<IDamagable>();

            if (idamage != null) {
                idamage.Damage(damage);
            }
        }
    }

    

    IEnumerator PunchCooldownTimer() {
        _punchCooling = true;
        yield return new WaitForSeconds(_punchCooldown);
        _punchCooling = false;
    }
}

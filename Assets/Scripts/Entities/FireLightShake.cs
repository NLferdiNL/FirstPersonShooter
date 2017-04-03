using UnityEngine;

public class FireLightShake : MonoBehaviour {

    new Transform transform;

    Vector3 fixedPos;

    [SerializeField]
    float slowness = 50;

    void Start() {
        transform = GetComponent<Transform>();

        fixedPos = transform.position;
    }

    void FixedUpdate() {
        Vector3 tempPos = fixedPos;

        tempPos.x += Random.Range(-1, 1) / slowness;
        tempPos.y += Random.Range(-1, 1) / slowness;
        tempPos.z += Random.Range(-1, 1) / slowness;

        transform.position = tempPos;
    }
}

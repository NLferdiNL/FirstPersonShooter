using UnityEngine;

public class DayAndNightCycle : MonoBehaviour {

    new Transform transform;

    [SerializeField]
    float speed = 1.0f;

    void Start() {
        transform = GetComponent<Transform>();
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(Time.deltaTime * speed, 0, 0));
    }
}

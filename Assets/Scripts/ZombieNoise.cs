using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ZombieNoise : MonoBehaviour {

    AudioSource audioSource;

    [SerializeField]
    AudioClip[] noises;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        bool willMoan = (Random.Range(1, 50) > 40 && audioSource.isPlaying == false);

        if (willMoan) {
            audioSource.clip = noises[Random.Range(0,noises.Length-1)];
            audioSource.Play();
        }
    }
	
}

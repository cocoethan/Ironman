using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFire : MonoBehaviour
{
    public GameObject robotPrefab;
    public AudioClip fireSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = fireSound;
    }

    void OnCollisionEnter() {
	Vector3 spawnPosition = transform.position + transform.forward;			// likely will be wonky
        Quaternion spawnRotation = Quaternion.identity;	
	audioSource.Play();									// may need to be 0 ^
        GameObject cylinder = Instantiate(robotPrefab, spawnPosition, spawnRotation);
    }
}

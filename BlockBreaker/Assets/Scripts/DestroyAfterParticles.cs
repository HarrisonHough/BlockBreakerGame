using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterParticles : MonoBehaviour {

    ParticleSystem particles;
	// Use this for initialization
	void Start () {
        particles = GetComponent<ParticleSystem>();

        Invoke("DestroySelf", particles.main.duration + 1f);
	}

    void DestroySelf()
    {
        Debug.Log("Destroying game object");
        Destroy(gameObject);
    }
}

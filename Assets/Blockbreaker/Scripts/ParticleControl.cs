using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

    [SerializeField]
    private GameObject smokePrefab;
    private ParticleSystem[] smokePool;
    [SerializeField]
    private int poolSize = 5;
    private int poolIndex = 0;
	// Use this for initialization
	void Start () {
        CreateSmokeParticlePool();
	}

    void CreateSmokeParticlePool()
    {
        smokePool = new ParticleSystem[poolSize];
        for (int i = 0; i < smokePool.Length; i++)
        {
            //create smoke particle object
            GameObject smokeObject = Instantiate(smokePrefab,Vector3.zero, Quaternion.identity);
            //parent under this object
            smokeObject.transform.parent = transform;
            //assign in array
            smokePool[i] = smokeObject.GetComponent<ParticleSystem>();
        }
    }

    public void SpawnSmokeParticles(Vector3 position)
    {
        smokePool[poolIndex].transform.position = position;
        smokePool[poolIndex].Play();

        poolIndex++;
        if (poolIndex >= smokePool.Length)
        {
            poolIndex = 0;
        }
    }
}

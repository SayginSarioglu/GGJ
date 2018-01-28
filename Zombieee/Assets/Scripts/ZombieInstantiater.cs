using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiater : MonoBehaviour
{
    public GameObject zombiePrefab;

    public Transform ethanBlue;//hey
    public Transform ethanRed;//hey

    public Transform zombies;
    public int zombiesSpawned;
    private float spawn;

    public void DestroyZombies()
    {
        for (int i = 0; i < zombies.childCount; i++)
            Destroy(zombies.GetChild(i).gameObject);
    }
    
    public void Initialize()
    {
        zombiesSpawned = 0;
        spawn = 10f;
        StartCoroutine(InstantiateObject());		
	}

    private IEnumerator InstantiateObject()
    {
        if (!gameObject.activeInHierarchy)
            yield break;
        GameObject go = (Instantiate(zombiePrefab, Vector3.zero, new Quaternion(0, 0, 0, 0)) as GameObject);
        go.GetComponent<Animator>().SetFloat("speed", Random.Range(0.8f, 1.2f));
        go.GetComponent<Animator>().SetBool("mirror", Random.Range(0f, 1f) > 0.5f);

        zombiesSpawned++;
        int dist = Random.Range(10, 50);
        int angle = Random.Range(0, 360);

        Vector3 pos = new Vector3(dist, 0, 0);
        pos = Quaternion.Euler(0,angle, 0) * pos;
        go.transform.position = pos;
        go.transform.LookAt(Vector3.zero);
        yield return new WaitForSeconds(0.1f * Random.Range(1f,spawn));
        if (Random.Range(0f, 1f) > 0.9f)
            spawn += 0.001f;
        else
        {
            spawn -= 0.005f;
            if (spawn < 2f)
                spawn = 2f;
        }
        StartCoroutine(InstantiateObject());
    }

    private void Update()
    {
        
    }
}

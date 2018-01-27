using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiater : MonoBehaviour {

    public GUIManager guiManager;
    public List<GameObject> zombies;

    public GameObject zombiePrefab;
    public Transform samuzai;//hey

	void Awake ()
    {
        Utility.guiManager = guiManager;

        zombies = new List<GameObject>();
        StartCoroutine(InstantiateObject());		
	}

    private IEnumerator InstantiateObject()
    {
        yield return new WaitForSeconds(1f);
        GameObject go = (Instantiate(zombiePrefab, Vector3.zero, new Quaternion(0, 0, 0, 0)) as GameObject);

        int rndX = Random.Range(-20, 21);
        int rndZ = Random.Range(0, 2);
        if (rndZ == 0)
            rndZ = -rndX;
        else
            rndZ = rndX;

        go.transform.position = new Vector3(rndX, 0, rndZ);
        zombies.Add(go);
        StartCoroutine(InstantiateObject());
    }

    private void Update()
    {
        for (int i = 0; i < zombies.Count; i++)
            if (zombies[i] != null && Vector3.Distance(zombies[i].transform.position, samuzai.position) < 3)
            {
                Utility.guiManager.AddHealth(5);
                Destroy(zombies[i]);
            }
    }
}

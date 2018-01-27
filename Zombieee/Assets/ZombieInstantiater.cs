using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiater : MonoBehaviour {

    public GameObject zombiePrefab;

	void Start () {
        StartCoroutine(InstantiateObject());		
	}

    private IEnumerator InstantiateObject()
    {
        yield return new WaitForSeconds(1f);
        GameObject go = (Instantiate(zombiePrefab, Vector3.zero, new Quaternion(0, 0, 0, 0)) as GameObject);
        //go.transform.SetParent(content, false);

        int rndX = Random.Range(-20, 21);
        int rndZ = Random.Range(0, 2);
        if (rndZ == 0)
            rndZ = -rndX;
        else
            rndZ = rndX;

        go.transform.position = new Vector3(rndX, 0, rndZ);
        StartCoroutine(InstantiateObject());
    }

}

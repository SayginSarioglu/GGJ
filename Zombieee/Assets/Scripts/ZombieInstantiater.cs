using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiater : MonoBehaviour {

    public GUIManager guiManager;

    public GameObject zombiePrefab;
    public Transform samuzai;//hey

	void Awake ()
    {
        Utility.guiManager = guiManager;
        
        StartCoroutine(InstantiateObject());		
	}

    private IEnumerator InstantiateObject()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject go = (Instantiate(zombiePrefab, Vector3.zero, new Quaternion(0, 0, 0, 0)) as GameObject);
        go.GetComponent<Animator>().SetFloat("speed", Random.Range(0.8f, 1.2f));
        go.GetComponent<Animator>().SetBool("mirror", Random.Range(0f, 1f) > 0.5f);

        int dist = Random.Range(10, 50);
        int angle = Random.Range(0, 360);

        Vector3 pos = new Vector3(dist, 0, 0);
        pos = Quaternion.Euler(0,angle, 0) * pos;
        go.transform.position = pos;
        go.transform.LookAt(Vector3.zero);
        StartCoroutine(InstantiateObject());
    }

    private void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieInstantiater : MonoBehaviour {

    public GUIManager guiManager;
    public List<GameObject> zombies;

    public GameObject zombiePrefab;
    public Transform samuzai;//hey
    public Transform ethan;//hey

    void Awake ()
    {
        Utility.guiManager = guiManager;

        zombies = new List<GameObject>();
        StartCoroutine(InstantiateObject());		
	}

    private IEnumerator InstantiateObject()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject go = (Instantiate(zombiePrefab, Vector3.zero, new Quaternion(0, 0, 0, 0)) as GameObject);

        int dist = Random.Range(10, 50);
        int angle = Random.Range(0, 360);

        Vector3 pos = new Vector3(dist, 0, 0);
        pos = Quaternion.Euler(0,angle, 0) * pos;
        go.transform.position = pos;
        go.transform.LookAt(Vector3.zero);
        zombies.Add(go);
        StartCoroutine(InstantiateObject());
    }

    private void Update()
    {
        if (Vector3.Distance(ethan.position, samuzai.position) < 3)
        {
            ethan.transform.position = new Vector3(Random.Range(-10, 10), ethan.transform.position.y, Random.Range(-10, 10));
            Utility.guiManager.samuZaiScoreText.text = "samuZai: " + ++Utility.guiManager.samuZaiScore;

            Debug.LogError("samurai ethanın ağzına sıçtı");        
        }

        for (int i = 0; i < zombies.Count; i++)
            if (zombies[i] != null)
            {
                if (Vector3.Distance(zombies[i].transform.position, samuzai.position) < 3)
                {
                    Utility.guiManager.AddHealth(1);
                    Destroy(zombies[i]);
                }
                else if (Vector3.Distance(zombies[i].transform.position, Vector3.zero) < 5)
                {
                    Utility.guiManager.AddHealth(-10);
                    Destroy(zombies[i]);
                }
            }
    }
}

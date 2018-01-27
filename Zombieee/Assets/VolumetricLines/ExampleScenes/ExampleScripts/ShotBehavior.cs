using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

    public GameObject samurai;
	// Use this for initialization
	void Start () {
        samurai = GameObject.Find("samuzai");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 30f;

        if (Vector3.Distance(transform.position, samurai.transform.position) < 2)
        {
            samurai.transform.position = new Vector3(Random.Range(-10, 10), samurai.transform.position.y, Random.Range(-10, 10));
            Utility.guiManager.ethanScoreText.text = "Ethan: " + ++Utility.guiManager.ethanScore;
            Destroy(gameObject);
        }
    }
}

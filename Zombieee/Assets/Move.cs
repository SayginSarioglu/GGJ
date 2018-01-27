using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    Vector3 pos;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
        float x;
        float z;
        if (transform.position.x < -1)
            x = Time.deltaTime;
        else if (transform.position.x > 1)
            x = -Time.deltaTime;
        else
            x = 0;

        if (transform.position.z < -1)
            z = Time.deltaTime;
        else if (transform.position.z > 1)
            z = -Time.deltaTime;
        else
            z = 0;

        pos = new Vector3(x, 0, z);

        if (Mathf.Abs(transform.position.x) > 1)
            transform.position += pos;
        else
        {
            Utility.guiManager.AddHealth(-5);
            Destroy(gameObject);
        }
    }
}

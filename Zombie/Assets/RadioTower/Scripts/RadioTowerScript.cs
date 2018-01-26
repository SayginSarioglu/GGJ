using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTowerScript : MonoBehaviour {
    float blinkSpeed = 1.0f;
    float secondsPassed = 0f;
    bool positive = false;

    public Light towerLight;
	void Update ()
    {
        if (positive)
            secondsPassed += Time.deltaTime;
        else
            secondsPassed -= Time.deltaTime;

        if ( secondsPassed > 2f)
        {
            secondsPassed = 2f;
            positive = !positive;
        }
        if ( secondsPassed < -0.5f)
        {
            secondsPassed = -0.5f;
            positive = !positive;
        }
        

        towerLight.intensity = secondsPassed;
	}
}

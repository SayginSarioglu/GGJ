using UnityEngine;

public class SamuzaiController : MonoBehaviour {

    void Update ()
    {
        float x = 0;
        float z = 0;

        if (Input.GetKey("left"))
            x = -5;
        else if (Input.GetKey("right"))
            x = 5;

        if (Input.GetKey("down"))
            z = -Time.deltaTime * 10;
        else if (Input.GetKey("up"))
            z = Time.deltaTime * 10;

        transform.Rotate(new Vector3(0, x, 0));
        transform.Translate(new Vector3(0, 0, z));
	}
}

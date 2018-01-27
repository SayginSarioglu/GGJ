using UnityEngine;

public class MeController : MonoBehaviour {

    float turn;
    float speed;
    int angle = 0;

    void Update ()
    {
        if (Input.GetKeyDown("left"))
        {
            turn = 90;
            angle += 90;
        }
        else if (Input.GetKeyDown("right"))
        {
            turn = -90;
            angle -= 90;
            if (angle < 0)
                angle += 360;
        }
        else
            turn = 0;

        if (Input.GetKey("down"))
            speed = -Time.deltaTime;
        else if (Input.GetKey("up"))
            speed = Time.deltaTime;
        else
            speed = 0;

        transform.Rotate(new Vector3(0, 0, turn));

        if (angle % 360 == 0)
            transform.position +=  new Vector3(0, -speed, 0);
            //transform.Translate(new Vector3(0, -speed, 0));
        else if (angle % 360 == 90)
            transform.position += new Vector3(speed, 0, 0);
            //transform.Translate(new Vector3(speed, 0, 0));
        else if (angle % 360 == 180)
            transform.position += new Vector3(0, speed, 0);
            //transform.Translate(new Vector3(0, speed, 0));
        else if (angle % 360 == 270)
            transform.position += new Vector3(-speed, 0, 0);
            //transform.Translate(new Vector3(-speed, 0, 0));
    }
}

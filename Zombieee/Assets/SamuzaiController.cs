using UnityEngine;

public class SamuzaiController : MonoBehaviour {

    public Animator animator;

    int prevType = 0;
    int type = 0;

    void Update ()
    {
        float x = 0;
        float z = 0;

        if (Input.GetKey("left"))
            x = -5;
        else if (Input.GetKey("right"))
            x = 5;

        if (Input.GetKey("down"))
        {
            z = -Time.deltaTime * 10;
            animator.SetBool("walk", true);
            type = 1;
        }
        else if (Input.GetKey("up"))
        {
            z = Time.deltaTime * 10;
            animator.SetBool("walk", true);
            type = 1;
        }
        else
        {
            animator.SetBool("walk", false);
            type = 0;
        }

        if (Input.GetKey("space"))
        {
            animator.SetBool("attack", true);
            type = 2;
        }
        else
            animator.SetBool("attack", false);

        if(prevType != type)
            prevType = type;

        transform.Rotate(new Vector3(0, x, 0));
        transform.Translate(new Vector3(0, 0, z));
	}
}

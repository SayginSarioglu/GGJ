using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public Animator animator;
    private bool up, down,right, left;
    Vector3[] moveVector = new Vector3[] { (Vector3.right + Vector3.forward) ,
                                           (Vector3.left + Vector3.forward) ,
                                           (Vector3.forward) ,
                                           (Vector3.right + Vector3.back) ,
                                           (Vector3.left + Vector3.back) ,
                                           (Vector3.back) ,
                                           (Vector3.right) ,
                                           (Vector3.left)  };

    private void Awake()
    {
        for (int i = 0; i < moveVector.Length; i++)
            moveVector[i] = moveVector[i] * Time.deltaTime;
    }

    void Update ()
    {
        up = Input.GetKey("up");
        down = Input.GetKey("down");
        right = Input.GetKey("right");
        left = Input.GetKey("left");

        if (up)
        {
            if (right)
            {
                animator.Play("RightTop");
                transform.Translate(moveVector[0]);
            }
            else if (left)
            { 
                animator.Play("LeftTop");
                transform.Translate(moveVector[1]);
            }
            else
            {
                animator.Play("Top");
                transform.Translate(moveVector[2]);
            }
        }
        else if (down)
        {
            if (right)
            {
                animator.Play("RightBottom");
                transform.Translate(moveVector[3]);
            }
            else if (left)
            {
                animator.Play("LeftBottom");
                transform.Translate(moveVector[4]);
            }
            else
            {
                animator.Play("Bottom");
                transform.Translate(moveVector[5]);
            }
        }
        else if (right)
        {
            animator.Play("Right");
            transform.Translate(moveVector[6]);
        }
        else if (left)
        {
            animator.Play("Left");
            transform.Translate(moveVector[7]);
        }
        else
            animator.Play("Idle");
    }
}

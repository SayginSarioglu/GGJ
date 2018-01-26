using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public Animator animator;
	void Update () {
        animator.SetInteger("X", (int)Input.GetAxis("Horizontal"));
        animator.SetInteger("Y", (int)Input.GetAxis("Vertical"));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool started = false;

    public void Initialize()
    {
        started = true;
    }

    void Update()
    {
        if (!started)
            return;

        if (Input.GetMouseButton(0))
        {
            gameObject.transform.localScale = Vector3.one;
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }
    }
}

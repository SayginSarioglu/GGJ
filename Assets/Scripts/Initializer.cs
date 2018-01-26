using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameObject gameArea;
    
	void Start ()
    {
        gameArea.GetComponent<PlayerController>().Initialize();
	}
}

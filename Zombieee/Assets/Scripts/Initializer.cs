using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public GameRect gameRect;
    public StartRect startRect;
    public EndRect endRect;

	// Use this for initialization
	void Start ()
    {
        Utility.gameRect = gameRect;
        Utility.startRect = startRect;
        Utility.endRect = endRect;

        gameRect.gameObject.SetActive(false);
        startRect.gameObject.SetActive(false);
        endRect.gameObject.SetActive(false);

        startRect.Initialize();

        Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRect : MonoBehaviour {
    public Button onePlayer;
    public Button twoPlayer;

    public void Initialize()
    {
        gameObject.SetActive(true);
        Utility.gameRect.gameObjects.GetComponent<ZombieInstantiater>().DestroyZombies();

        onePlayer.onClick.RemoveAllListeners();
        onePlayer.onClick.AddListener(() => Utility.gameRect.Initialize(false));

        twoPlayer.onClick.RemoveAllListeners();
        twoPlayer.onClick.AddListener(() => Utility.gameRect.Initialize(true));
    }
}

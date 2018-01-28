using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRect : MonoBehaviour
{
    public GameObject gameObjects;
    public GameObject bluePlayer;
    public GameObject redPlayer;
    public GameObject blueHP;
    public GameObject redHP;

    public Tower tower;

    public void Initialize(bool twoPlayer)
    {
        Utility.startRect.gameObject.SetActive(false);
        gameObject.SetActive(true);
        gameObjects.SetActive(true);
        Utility.gameRect.gameObjects.GetComponent<ZombieInstantiater>().Initialize();

        tower.Initialize();

        bluePlayer.SetActive(true);
        blueHP.SetActive(true);
        bluePlayer.GetComponent<EthanBlue>().Initialize();
        redPlayer.SetActive(twoPlayer);
        redHP.SetActive(twoPlayer);
        bluePlayer.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        bluePlayer.transform.position = twoPlayer ? new Vector3(-2f, 0f, 0f) : new Vector3(0f, 0f, -2f);
        if (twoPlayer)
        {
            redPlayer.GetComponent<EthanRed>().Initialize();
            redPlayer.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            redPlayer.transform.position = new Vector3(2f, 0f, 0f);
        }
    }
}

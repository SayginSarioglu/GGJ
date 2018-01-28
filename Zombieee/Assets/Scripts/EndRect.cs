using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndRect : MonoBehaviour
{
    public Text blueKills;
    public Text blueHits;
    public Text redKills;
    public Text redHits;
    public Text shotsFired;
    public Text zombiesSpawned;
    public Text towerHits;
    public Button doneButton;

    public void Initialize(int shotFired, int zombies, int hitCount)
    {
        int blueScore, blueHit, redScore, redHit;
        gameObject.SetActive(true);

        blueScore = Utility.gameRect.bluePlayer.GetComponent<EthanBlue>().score;

        blueKills.gameObject.SetActive(true);
        blueKills.text = "Blue killed " + blueScore + (blueScore == 1 ? " zombie" : " zombies") + "!";
        if (Utility.gameRect.redHP.activeInHierarchy) //two player
        {
            blueHits.gameObject.SetActive(true);
            redKills.gameObject.SetActive(true);
            redHits.gameObject.SetActive(true);

            blueHit = Utility.gameRect.redPlayer.GetComponent<EthanRed>().hitBy;
            redScore = Utility.gameRect.redPlayer.GetComponent<EthanRed>().score;
            redHit = Utility.gameRect.bluePlayer.GetComponent<EthanBlue>().hitBy;

            blueHits.text = "Blue attacked teammate " + blueHit + (blueHit == 1 ? " time" : " times") + "!";
            redKills.text = "Red killed " + redScore + (redScore == 1 ? " zombie" : " zombies") + "!";
            redHits.text = "Red attacked teammate " + redHit + (redHit == 1 ? " time" : " times") + "!";
        }
        else
        {
            blueHits.gameObject.SetActive(false);
            redKills.gameObject.SetActive(false);
            redHits.gameObject.SetActive(false);
        }

        shotsFired.text = shotFired + (shotFired == 1 ? " shot" : " shots") + " fired!";
        zombiesSpawned.text = zombies + (hitCount == 1 ? " zombie" : " zombies") + " spawned!";
        towerHits.text = "Tower got hit " + hitCount + (hitCount == 1 ? " time" : " times") + "!";

        doneButton.onClick.RemoveAllListeners();
        doneButton.onClick.AddListener(Done);
    } 

    void Done()
    {
        Utility.startRect.Initialize();
        gameObject.SetActive(false);
    }
}

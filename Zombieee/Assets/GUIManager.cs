using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    private int health = 100;
    public Text healthTxt;
    public Text ethanScoreText;
    public Text samuZaiScoreText;
    public int ethanScore = 0;
    public int samuZaiScore = 0;

    public void AddHealth(int health)
    {
        this.health += health;
        if (this.health > 100)
            this.health = 100;
        if (this.health < 0)
        {
            this.health = 0;
            Debug.LogError("Ta ta ta öldün Çık");
        }

        healthTxt.text = this.health + "";
    }
}

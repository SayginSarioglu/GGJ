using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public EthanRed m_muzzle;
	public GameObject m_shotPrefab;
	public Texture2D m_guiTexture;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.LeftShift) && Utility.gameRect.tower.GetEnergy())
		{
			GameObject go = GameObject.Instantiate(m_shotPrefab, transform.position, m_muzzle.transform.rotation) as GameObject;
            go.GetComponent<ShotBehavior>().ethan = m_muzzle;
            go.transform.localScale *= 0.001f;
			GameObject.Destroy(go, 2.5f);
		}
	}

	void OnGUI()
	{
		//GUI.DrawTexture(new Rect(0f, 0f, m_guiTexture.width / 2, m_guiTexture.height / 2), m_guiTexture);
	}
}

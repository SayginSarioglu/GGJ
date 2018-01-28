using UnityEngine;
using System.Collections;

public class ShotBehaviorBlue : MonoBehaviour {
    Vector3 inc = new Vector3(0.01f, 0.01f, 0.01f);
    public EthanBlue ethan;
    
	void Update ()
    {
		transform.position += transform.forward * Time.deltaTime * 30f;
        transform.localScale += inc * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ethan.gameObject)
            return;
        HitObject hit = other.gameObject.GetComponent<HitObject>();
        if (hit != null)
            if (hit.Hit(Vector3.Angle(transform.forward, other.gameObject.transform.forward) / 180f))
                ethan.IncreaseScore();
    }
}

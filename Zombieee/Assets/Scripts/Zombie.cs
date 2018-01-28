
using UnityEngine;

public class Zombie : HitObject {
    private bool attacking = false;
    private bool hitted = false;
    private int hit;

	// Use this for initialization
	void Start () {
        attacking = false;
        hitted = false;
        hit = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if (Vector3.Distance(transform.position, Vector3.zero) < 3)
        {
            attacking = true;
            GetComponent<Animator>().SetTrigger("attack");
        }
    }

    void Attack()
    {
        Utility.gameRect.tower.GotHit();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    public override bool Hit(float direction)
    {
        if (hitted)
            return false;
        GetComponent<Animator>().SetFloat("hitDirection", direction);
        GetComponent<Animator>().SetTrigger("fall");
        Invoke("DestroyObject", 1.5f);
        return hitted = true;
    }
}

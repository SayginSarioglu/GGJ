
using UnityEngine;

public class Zombie : HitObject {
    private bool attacking = false;
    private int hit;

	// Use this for initialization
	void Start () {
        attacking = false;
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
        Utility.guiManager.AddHealth(-10);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    public override void Hit(float direction)
    {
        GetComponent<Animator>().SetFloat("hitDirection", direction);
        GetComponent<Animator>().SetTrigger("fall");
        Invoke("DestroyObject", 1.5f);
    }
}

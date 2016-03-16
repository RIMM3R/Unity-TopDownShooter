using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float ProjectileSpeed;
    //public bool Enabled = false;
    //public Transform bulletStart, bulletEnd;
    //public Transform playerPrefab;

	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {

        //Raycasting();

        transform.Translate(0, ProjectileSpeed * Time.deltaTime, 0); // sets bullets direction to the one shooting

        /*
        Physics2D.IgnoreLayerCollision(8, 11);
        Physics2D.IgnoreLayerCollision(8, 12);

        

        if (Enabled == true)
        {
            Transform player = Instantiate(playerPrefab) as Transform;
            Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
         */
	
	}

    void OnCollisionEnter2D(Collision2D target)
    {

        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Raycasting()
    {
        //Debug.DrawLine(bulletStart.position, bulletEnd.position, Color.yellow);
        //Enabled = Physics2D.Linecast(bulletStart.position, bulletEnd.position, 1 << LayerMask.NameToLayer("Block"));
    }
}

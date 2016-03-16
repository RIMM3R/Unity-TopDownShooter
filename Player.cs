using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float playerSpeed = 8;
    public float ammo;
    public GameObject PlayerBullet;

	// Use this for initialization
	void Start () 
    {
        Physics2D.IgnoreLayerCollision(9, 11);
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Player faces mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        Shoot();

        
	
	}

    void FixedUpdate()
    {
        
        /* Used to face the player towards the mouse, wasn't accurate 
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
         
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
         */

        GetComponent<Rigidbody2D>().angularVelocity = 0; //stops slide

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = new Vector2(x * playerSpeed, y * playerSpeed);

        //Sops the player from exceding its designated speed
        if (GetComponent<Rigidbody2D>().velocity.magnitude > playerSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * playerSpeed;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Instantiate(PlayerBullet, transform.position, transform.rotation);
            ammo = ammo - 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            ammo = 6;
        }
        else
        {
            return;
        }
    }
}

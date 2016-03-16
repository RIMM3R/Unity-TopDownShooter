using UnityEngine;
using System.Collections;

public class CoverPoint : MonoBehaviour {

    public Transform player;
    public bool goodCover = false;
    public bool block = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Raycasting();

        if (goodCover == true)
        {
            gameObject.tag = "GoodCover";
        }
        if (goodCover == false)
        {
            gameObject.tag = "BadCover";
        }
	
	}
    
    

    void Raycasting()
    {
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            
            Debug.DrawLine(transform.position, player.position, Color.yellow);
            goodCover = Physics2D.Linecast(transform.position, player.position, 1 << LayerMask.NameToLayer("Block"));
        }
        else
        {
            goodCover = false;
        }
        
    }
}

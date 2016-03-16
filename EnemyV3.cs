using UnityEngine;
using System.Collections;

public class EnemyV3 : MonoBehaviour {

    public bool seen = false;
    public Transform player;
    public GameObject EnemyBullet;
    

    //Fire
    public float fireRate;
    private float nextFire = 1;
    public float ammo;
    public bool shot = false;

    //Reload
    private float nextReload = 1;
    public float reloadRate;
    public float wait;
    public float bulletLimit;

    public Transform CurrentTarget;

    
    //I use a pluging to handle my pathfinding as Navmesh doesn't work in 2D
    private PolyNavAgent _agent;
    public PolyNavAgent agent
    {
        get
        {
            if (!_agent)
                _agent = GetComponent<PolyNavAgent>();
            return _agent;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Physics2D.IgnoreLayerCollision(10, 12);

        Raycasting();
        Wait();

        if (ammo <= 0 && shot == false)
        {

            CurrentTarget = GetComponent<FindGoodCover>().SelectedTarget;
            //agent.OnDestinationReached += InvokeReload;

            if (agent.remainingDistance <= float.Epsilon)
            {
                Invoke("Reload", wait);
            }  
        }
        if (ammo <= 0 && shot == true)
        {
            agent.Stop();
            Invoke("Reload", wait);
        }
        if (ammo > 0)
        {
            CancelInvoke("Reload");
            CurrentTarget = GetComponent<FindBadCover>().SelectedTarget;
            
        }

        agent.SetDestination(CurrentTarget.transform.position);

        if (shot == false && ammo > 0)
        {
            FireOnTime();
            
            
        }
       
       
	
	}

    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90; //targets player

        transform.eulerAngles = new Vector3(0, 0, z);
    }

    void TargetPlayer()
    {
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            seen = true;
        }
        else
        {
            seen = false;
        }
    }

    void OnBecameInvisible()
    {
        seen = false;
    }

    void OnBecameVisible()
    {
        seen = true;
    }

    void Fire()
    {
        Instantiate(EnemyBullet, transform.position, transform.rotation);
        ammo = ammo - 1;

    }

    void FireOnTime()
    {
        if (Time.time > this.nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            //ammo = ammo - 1;
        }

    }

    void Raycasting()
    {
        Debug.DrawLine(transform.position, player.position, Color.red);
        shot = Physics2D.Linecast(transform.position, player.position, 1 << LayerMask.NameToLayer("Block"));
    }

    void Reload()
    {
        ammo = 6;
    }

    void Wait()
    {
        bulletLimit = Random.Range(1, 6);
        wait = Random.Range(2, 6);
    }
   
}

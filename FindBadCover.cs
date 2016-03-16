using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindBadCover : MonoBehaviour {

    //Find cover
    public List<Transform> CoverPoints;
    public Transform SelectedTarget;
    public Transform coverPoint;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Set up Cover
        SelectedTarget = null;
        CoverPoints = new List<Transform>();
        AddCoverToList();
        TargetedPoint();

    }
    void AddCoverToList()
    {

        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("BadCover");

        foreach (GameObject _Cover in ItemsInList)
        {
            AddTarget(_Cover.transform);
        }
    }

    void AddTarget(Transform cover)
    {
        CoverPoints.Add(cover);
    }

    public void DistanceToTarget()
    {
        CoverPoints.Sort(delegate(Transform t1, Transform t2)
        {
            return Vector2.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });

    }

    void TargetedPoint()
    {
        if (SelectedTarget == null)
        {
            DistanceToTarget();
            SelectedTarget = CoverPoints[0];
        }
    }

    void MoveToCover()
    {
        agent.SetDestination(SelectedTarget.transform.position);
    }
}

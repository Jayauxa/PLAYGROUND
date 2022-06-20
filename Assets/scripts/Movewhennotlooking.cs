using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movewhennotlooking : MonoBehaviour
{
    Transform playerTransform;
    UnityEngine.AI.NavMeshAgent myNavmesh;
    public float checkRate = 0.01f;
    float nextCheck;
    public bool NotLookedAt;
    public float speed = 10f;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        myNavmesh = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        myNavmesh.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            FollowPlayer();
        }
        if (GetComponent<Renderer>().isVisible)
        {

            NotLookedAt = false;
            Vector3 lookVector = Player.transform.position - transform.position;
            lookVector.x = transform.position.x;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 3);
        }
        if (!GetComponent<Renderer>().isVisible)
        {

            NotLookedAt = true;
        }
        if (NotLookedAt == true)
        {
            speed = 100f;
            myNavmesh.speed = 100f;
        }
        if (NotLookedAt == false)
        {
            speed = 0f;
            myNavmesh.speed = 0;
        }
    }

    void FollowPlayer()
    {
        myNavmesh.transform.LookAt(playerTransform);
        myNavmesh.destination = playerTransform.position;
    }
}

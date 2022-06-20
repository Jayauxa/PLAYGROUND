using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crawlerfollowsyou : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;

    // public float distToPlayer = 5,0f;
    // public float faceplayerFactor = 20f;
    // public float attackRadius = 1,0f;
  

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        enemy.SetDestination(Player.position);

        // float distance = vector3.Distance(PlayerMove.PlayerPos, transform.position);
        // if(distance > attackRadius) {stop();}
        // else if (distance <= attackRadius) {Attack();}
    }
}

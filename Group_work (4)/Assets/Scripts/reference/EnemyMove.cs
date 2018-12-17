using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {


    public float speed;
    public Transform[] moveSpots;
    int targetSpot;

    float distToSpot;

    float waitTime;
    float startWait;

    public GameObject player;

    float chaseDist;

    float chaseSpeed;

    void Start()
    {

        waitTime = startWait;
        startWait = 1f;
        targetSpot = 0;
        distToSpot = 0.02f;

        chaseDist = 3;
        chaseSpeed = 2f;

    }


    void Update()
    {

        if (Vector2.Distance(transform.position, player.transform.position) < chaseDist)
        {
            // chase
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            chaseSpeed += 0.05f;

        }
        else
        {
            //patrol
            chaseSpeed = 2f;
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[targetSpot].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[targetSpot].position) < distToSpot)
            {

                if (waitTime <= 0)
                {
                    targetSpot = Random.Range(0, moveSpots.Length);
                    //targetSpot++;

                    //if (targetSpot > moveSpots.Length - 1)
                    //{
                    //    targetSpot = 0;
                    //}
                    waitTime = startWait;

                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}


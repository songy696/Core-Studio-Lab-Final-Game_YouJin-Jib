using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour {


    public Transform target;
    public float chaseRange;

    public bool HuntPlayer;
    public bool playerShowing;

    float chaseSpeed;


    public float speed;
    public Transform[] moveSpots;
    int targetSpot;

    float distToSpot;

    float waitTime;
    float startWait;

    public UnityEvent OnFinishFade;

    public GameObject restartText, restartButton;


    //Facing
    Vector3 CurrentPosition, LastPosition;
    //Patrol
    int Round;
    bool isDisappearing;

    public void StartHunting()
    {
        Debug.Log("Chase!");
        HuntPlayer = true;
    }

  
    // Use this for initialization
    void Start () {
        playerShowing = true;

        chaseSpeed = 2f;

        waitTime = startWait;
        startWait = 1f;
        targetSpot = 0;
        distToSpot = 0.02f;


        restartText.SetActive(false);
        restartButton.SetActive(false);

    }

 

    // Update is called once per frame
    void Update()
    {
        if (HuntPlayer)
        {

            if (playerShowing)
            {
                //chasing player
                float distanceToTarget = Vector3.Distance(transform.position, target.position);


                if (distanceToTarget < chaseRange)
                {

                    //new chase
                    Vector3 localPosition = target.position - transform.position;
                    localPosition = localPosition.normalized;
                    transform.Translate(localPosition.x * Time.deltaTime * chaseSpeed, 0, localPosition.z * Time.deltaTime * chaseSpeed);
                    chaseSpeed += 0.002f;


                    //flip
                    Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                    float worldXPos = Camera.main.ScreenToWorldPoint(pos).x;

                    if (worldXPos > gameObject.transform.position.x)
                    {
                        // Facing right
                        transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
                    }
                    else
                    {
                        // Facing left
                        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    }

                }
            }
            else
            {
                CurrentPosition = transform.position;
                //Facing
                if (LastPosition != CurrentPosition)
                {
                    if (LastPosition.x > CurrentPosition.x)
                    {
                        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
                    }
                    LastPosition = CurrentPosition;
                }

                //patrol
                chaseSpeed = 2f;
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[targetSpot].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, moveSpots[targetSpot].position) < distToSpot)
                {

                    if (waitTime <= 0)
                    {
                        Round++;
                        targetSpot++;

                        if (targetSpot > moveSpots.Length - 1)
                        {
                            targetSpot = 0;
                        }
                        waitTime = startWait;

                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }

                //Disappear
                if(Round >= 4 && !isDisappearing)
                {
                    Debug.Log("Go away~");
                    isDisappearing = true;
                    HuntPlayer = false;
                    playerShowing = false;

                    StartCoroutine("Fading");

                }             


            }
        }

        
    }

    IEnumerator Fading()
    {
        //Debug.Log("Start");
        //Wait for 3 seconds
        //yield return new WaitForSeconds(3);
        //Debug.Log("three seconds !");

        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        Light L = GetComponentInChildren<Light>();
        float alpha = 1f;
        while (SR.color.a >= 0.01f)
        {
            alpha -= 0.01f;
            SR.color = new Color(SR.color.r, SR.color.g, SR.color.b,alpha);
            L.intensity = alpha * 39.6f;
            yield return null;
        }

        OnFinishFade.Invoke();

    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (playerShowing)
        {
            if (other.CompareTag("Player"))
            {
                restartText.SetActive(true);
                restartButton.SetActive(true);
                Destroy(other.gameObject);
            }
        }
    }

}

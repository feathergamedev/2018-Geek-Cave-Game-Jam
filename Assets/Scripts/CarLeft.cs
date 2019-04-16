using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLeft : MonoBehaviour
{
    Vector2 posStart;
    Vector2 posEnd;

    float moveSpeed = 0.000001f;
    float totalTime = 10;
    float timer = 0;

    Rigidbody2D playerRigidbody2D;

    Vector2 force = Vector2.right * 10.0f;

    public GameObject gameobject;

    // Use this for initialization
    void Start()
    {
        //float length = (posEnd - posStart).magnitude;
        //totalTime = length / moveSpeed;

        //posStart.x = -12.0f;
        //posStart.y = 0.16f;
        //transform.position = posStart;

        //posEnd.x = -1.16f;
        //posEnd.y = 0.16f;


        playerRigidbody2D.AddForce(force);
//        playerRigidbody2D = GetComponent<Rigidbody2D>().AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //transform.position = Vector2.Lerp(transform.position, posEnd, timer/totalTime);

        //if (timer >= totalTime)
            //this.enabled = false;
    }
}

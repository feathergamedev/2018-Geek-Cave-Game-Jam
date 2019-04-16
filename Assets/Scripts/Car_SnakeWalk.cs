using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_SnakeWalk : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0f, Mathf.Sin(Time.time), 0f);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Get hitted!");
        //待辦事項：加特效
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour {

    Vector3 initpos;
    public bool isDangerous;
	// Use this for initialization
	void Start () {
        initpos = transform.position;

        if(isDangerous)
            transform.GetChild(0).gameObject.SetActive(true);
        else
            transform.GetChild(0).gameObject.SetActive(false);



    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Get hitted!");
            //待辦事項：加特效
            GetComponent<Rigidbody2D>().AddTorque(500f);
        }
        else if(collision.gameObject.tag=="Bomb")
        {
            Destroy(this.gameObject);
        }
    }

    public void Go_Bad()
    {
        transform.GetChild(0).gameObject.SetActive(true);   

        if (StageManager.instance.cur_stageNum == 2)
            StartCoroutine(Snake_Walk());

    }

    IEnumerator Snake_Walk()
    {
        while (true)
        {
            transform.DOMoveY(initpos.y + 0.7f, 0.3f, false).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.3f);
            transform.DOMoveY(initpos.y, 0.3f, false).SetEase(Ease.OutBounce);;
            yield return new WaitForSeconds(0.3f);
        }
    }
}

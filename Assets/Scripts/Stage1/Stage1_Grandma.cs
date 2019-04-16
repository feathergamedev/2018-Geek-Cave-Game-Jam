using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Stage1_Grandma : MonoBehaviour {

    public float moveSpeed;
    SpriteRenderer m_renderer;
    public Sprite Sprite_grandmaBold;
    public GameObject bigGrandma, hair;

    Animator m_aim;

    bool beenHit=false;

    Vector3 initPos;

	// Use this for initialization
	void Start () {
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.enabled = false;
        Invoke("Real_Grandma_Show", 4.5f);

        initPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if(StageManager.instance.m_gameStatus==GameStatus.Playing)
        {
            
            if(StageManager.instance.cur_stageNum==1)
                transform.Translate(new Vector3(0f, moveSpeed*Time.deltaTime, 0f));
            else
                transform.Translate(new Vector3(0f, moveSpeed * Time.deltaTime, 0f));                
        }
	}

    void Real_Grandma_Show()
    {
        m_renderer.enabled = true;
        StageManager.instance.GameStatus_Toggle();

        if(StageManager.instance.cur_stageNum==2)
            StartCoroutine(Stage2_ChaCha());
    }

    IEnumerator Stage2_ChaCha()
    {
        while(true)
        {
            transform.DOMoveX(initPos.x + 0.7f, 0.3f, false).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.3f);
            transform.DOMoveX(initPos.x - 0.7f, 0.3f, false).SetEase(Ease.OutBounce); ;
            yield return new WaitForSeconds(0.3f);
        }

        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Finish")
        {
            StageManager.instance.Stage_Complete();
        }
        else if(collision.gameObject.tag=="Car" || collision.gameObject.tag == "Bomb")
        {

            GetComponent<Rigidbody2D>().AddTorque(200f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 3f);

            SoundManager.instance.Play_Sound(Sounds.被車撞);

            Get_Hitted();

        }
    }


    void Get_Hitted()
    {
        if (beenHit == false)
        {
            GameObject newHair = Instantiate(hair, transform.position, Quaternion.Euler(0f, 0f, Random.Range(30f, 359f)));
            newHair.transform.Translate(new Vector3(Random.Range(0f, 0.08f), Random.Range(0f, 0.08f), 0f) * Time.fixedTime);
            m_renderer.sprite = Sprite_grandmaBold;
            StageManager.instance.Stage_Failed();
            beenHit = true;

            if(StageManager.instance.cur_stageNum==1)
                StageManager.instance.Stage1_BGM.Stop();
            else
                StageManager.instance.Stage2_BGM.Stop();                
        }

    }

}

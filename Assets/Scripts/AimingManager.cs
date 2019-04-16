using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingManager : MonoBehaviour{
    public static AimingManager instance;

    public GameObject aim, Prefab_Bomb;
    public float explodeTime;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        aim.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StageManager.instance.m_gameStatus == GameStatus.Playing)
        {


            if (Cursor.visible == true)
            {
                Cursor.visible = false;
                aim.GetComponent<SpriteRenderer>().enabled = true;                
            }

            aim.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 10f);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 shootPos = aim.transform.position;

                Generate_Bomb(shootPos);

            }
        }
        else
        {


            if (Cursor.visible == false)
            {
                Cursor.visible = true;
                aim.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void Generate_Bomb(Vector3 bornPos)
    {
        GameObject newBomb = Instantiate(Prefab_Bomb, bornPos, transform.rotation);

    }

}
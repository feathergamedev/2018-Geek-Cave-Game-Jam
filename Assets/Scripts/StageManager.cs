using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum GameStatus{Pausing, Playing, Finished, Failed}

public class StageManager : MonoBehaviour {
    public static StageManager instance;

    public int cur_stageNum;

    public GameStatus m_gameStatus;
    public Sprite Sprite_Play, Sprite_Pause;

    public GameObject Page_completed, Page_failed;

    public CarGenerator generator;

    public AudioSource Stage1_BGM, Stage2_BGM;

    private void Awake()
    {
        if (instance == null)
            instance = this;    
    }

    // Use this for initialization
    void Start () 
    {
        generator.enabled = false;
        m_gameStatus = GameStatus.Pausing;
        Page_completed.SetActive(false);
        Page_failed.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(m_gameStatus==GameStatus.Finished)
        {
            if(Input.anyKey)
            {
                if (cur_stageNum == 2)
                    SceneManager.LoadScene("Menu");
                else
                    SceneManager.LoadScene("Stage2");
            }
        }
        else if(m_gameStatus==GameStatus.Failed)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }            
        }
	}

    public void GameStatus_Toggle()
    {
        if(m_gameStatus==GameStatus.Playing)
        {
            m_gameStatus = GameStatus.Pausing;

        }
        else if(m_gameStatus==GameStatus.Pausing)
        {
            generator.enabled = true;
            m_gameStatus = GameStatus.Playing;     


            if (StageManager.instance.cur_stageNum == 1)
                Stage1_BGM.Play();
            else
                Stage2_BGM.Play();
        }


    }

    public void Go_Menu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void Change_GameStatus(GameStatus newStatus)
    {
        m_gameStatus = newStatus;
    }

    public void Stage_Complete()
    {
        Debug.Log("Win!");
        SoundManager.instance.Play_Sound(Sounds.過關);
        m_gameStatus = GameStatus.Finished;
        Page_completed.SetActive(true);
    }

    public void Stage_Failed()
    {
        m_gameStatus = GameStatus.Failed;
        Invoke("Show_Fail_Page", 2f);
    }

    void Show_Fail_Page()
    {
        Page_failed.SetActive(true);
        SoundManager.instance.Play_Sound(Sounds.失敗);
                    
    }
}

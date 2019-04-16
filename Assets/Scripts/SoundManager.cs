using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds{爆炸聲=0,被車撞=1,過關=2,失敗=3,裝備假髮=4}

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;

    public AudioSource[] sounds;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Invoke("Play_Armored_Sound", 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play_Sound(Sounds sound)
    {
        sounds[(int)sound].Play();
    }

    void Play_Armored_Sound()
    {
        Play_Sound(Sounds.裝備假髮);
    }
}

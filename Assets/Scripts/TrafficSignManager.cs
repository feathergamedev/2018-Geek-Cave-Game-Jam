using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Sign { Red, Yellow, Green }


public class TrafficSignManager : MonoBehaviour {
    public static TrafficSignManager instance;

    public Sign cur_sign = Sign.Red;
    public SpriteRenderer m_renderer;

    public Sprite[] signs;

    public AudioSource BGM;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () 
    {
        StartCoroutine(Random_Sign());
	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    IEnumerator Random_Sign()
    {
        while(true)
        {
            m_renderer.sprite = signs[Random.Range(0, 3)];
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
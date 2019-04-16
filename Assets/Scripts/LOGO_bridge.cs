using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOGO_bridge : MonoBehaviour {

    public GameObject speedCamera;

    public AudioSource Ama_sound;

	// Use this for initialization
	void Start () {
        StartCoroutine(Go_Menu());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Go_Menu()
    {
        yield return new WaitForSeconds(1.0f);
        Ama_sound.enabled = true;
            
        yield return new WaitForSeconds(2.0f);
        speedCamera.SetActive(true);

        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("Menu");
        yield return null;
    }
}

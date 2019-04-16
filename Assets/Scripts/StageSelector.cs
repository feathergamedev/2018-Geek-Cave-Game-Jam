using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Choose_Stage(int stageNum)
    {
        SceneManager.LoadScene(string.Format("Stage{0}", stageNum));
    }
}

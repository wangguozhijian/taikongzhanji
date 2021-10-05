using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("MyGane/TitleSceen")]

public class TitleSceen : MonoBehaviour {


    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("level1");
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

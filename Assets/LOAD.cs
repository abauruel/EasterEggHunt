using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR;

public class LOAD : MonoBehaviour {

	

	public VideoPlayer video;
	
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(aguarde());
		
	}

	void onMovieEnded(){
		aguarde();
		
	}

	IEnumerator aguarde(){
		yield return new WaitForSeconds(17);
		Application.LoadLevel("Cena2");
	}

	void OnGUI(){
		
		GUI.Box(new Rect(10,20,200,50),"Começar o Game");
		GUI.backgroundColor = Color.green;
		if(GUI.Button(new Rect(30,40,150,20),"Pular Intro")){
			Application.LoadLevel("Cena1");
		}
	}
}

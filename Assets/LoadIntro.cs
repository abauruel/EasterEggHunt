using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadIntro : MonoBehaviour {

	// Use this for initialization
	public VideoPlayer video;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(aguarde());
	}
	IEnumerator aguarde(){
		yield return new WaitForSeconds(16);
		Application.LoadLevel("Cena1");
	}
	void OnGUI(){
		
		GUI.Box(new Rect(10,20,200,50),"Começar o Game");
		GUI.backgroundColor = Color.green;
		if(GUI.Button(new Rect(30,40,150,20),"Pular Intro")){
			Application.LoadLevel("Cena1");
		}
	}
}

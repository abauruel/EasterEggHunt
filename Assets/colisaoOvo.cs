using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colisaoOvo : MonoBehaviour {
	public RawImage m_RawImage;
	public Texture Textura1;
	public Texture Textura2;
	public Texture Textura3;
	public Texture Textura4;
	public Texture Textura5;
	
	public GameObject particulaOvo;
	public GameObject particulaWin;
	public GameObject ovoInteiro;

	public int  count =0;
	// Use this for initialization
	void Start () {
		
		ovoInteiro.gameObject.SetActive(false);
				
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="ovo"){
			Instantiate(particulaOvo, other.gameObject.transform.position, Quaternion.identity);
			other.gameObject.SetActive(false);
			count++;
			VerificaObjetos();
			VerificaTextura();
		}

		

	}

	void VerificaObjetos(){
		if(count >= 4 ){
			ovoInteiro.gameObject.SetActive(true);
			Instantiate(particulaWin, ovoInteiro.gameObject.transform.position, Quaternion.identity);
		}
	}

	void VerificaTextura(){
		switch(count){
				case 1:
				m_RawImage.texture = Textura1;
				break;
				case 2:
				m_RawImage.texture = Textura2;
				break;
				case 3:
				m_RawImage.texture = Textura3;
				break;
				case 4:
				m_RawImage.texture = Textura4;
				StartCoroutine( aguarde());
				
				break;
				default:
				break;
			}
	}
	IEnumerator aguarde(){
		yield return new WaitForSeconds(1);
		m_RawImage.texture = Textura5;
	}
}

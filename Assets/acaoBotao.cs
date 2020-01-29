using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class acaoBotao : MonoBehaviour {
public RawImage m_RawImage;
public Texture Textura1;
public Texture Textura2;
public Texture Textura3;
public Texture Textura4;
public Texture Textura5;


public AudioClip clicaOvo;
public AudioClip pecasOvoCompleta;
public AudioClip ovoCompleto;
public GameObject particulaOvo,particulaWin;
public GameObject ovoPart1,ovoPart2,ovoPart3,ovoPart4, ovoPart5,cube,texto;

int count ;
	// Use this for initialization
	void Start () {
		ovoPart1 = GameObject.Find("parte1");
		ovoPart2 = GameObject.Find("parte2");
		ovoPart3 = GameObject.Find("parte3");
		ovoPart4 = GameObject.Find("parte4");
		ovoPart5.gameObject.SetActive(false);
		cube.gameObject.SetActive(false);
		texto.gameObject.SetActive(false);
		m_RawImage.transform.position = new Vector2(100,150);
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
			Ray ray = 	Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit Hit;
			if(Physics.Raycast(ray, out Hit)){
				Debug.Log(Hit.collider.tag);
				Debug.Log(Hit.transform.name);
				Hit.transform.gameObject.SetActive(false);
				GetComponent<AudioSource>().PlayOneShot(clicaOvo, 0.7f);
				Instantiate(particulaOvo, Hit.transform.gameObject.transform.position, Quaternion.identity);
				count++;
				VerificaTextura();
				VerificaObjetos();
				
			}
			
		}


		if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
			Ray ray = 	Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit Hit;
			if(Physics.Raycast(ray, out Hit)){
				
				if(Hit.transform.tag!="cubo"){
				Debug.Log(Hit.collider.tag);
				Debug.Log(Hit.transform.name);
				Hit.transform.gameObject.SetActive(false);
				GetComponent<AudioSource>().PlayOneShot(clicaOvo, 0.7f);
				Instantiate(particulaOvo, Hit.transform.gameObject.transform.position, Quaternion.identity);
				count++;
				VerificaTextura();

				
				//VerificaTextura();
				}
				
			}

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
		
		GetComponent<AudioSource>().PlayOneShot(pecasOvoCompleta, 0.10f);
		Instantiate(particulaOvo, ovoPart5.transform.gameObject.transform.position, Quaternion.identity);
		ovoPart5.gameObject.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(ovoCompleto,0.7f);
		yield return new WaitForSeconds (2);
		ovoPart5.gameObject.SetActive(false);
		cube.gameObject.SetActive(true);
		
		
		texto.gameObject.SetActive(true);
		
	}

	
	void VerificaObjetos(){
		if(count >= 4 ){
			//ovoPart5.transform.position = new Vector3(Screen.width/2,Screen.height/2,0);
			GetComponent<AudioSource>().PlayOneShot(ovoCompleto,0.7f);
			//ovoPart5.gameObject.SetActive(true);
			//Instantiate(particulaWin, ovoInteiro.gameObject.transform.position, Quaternion.identity);
		}
	}

	void OnGUI(){
		
		GUI.Box(new Rect(15,20,200,250),"");
		GUI.backgroundColor = Color.red;
		if(GUI.Button(new Rect(40,30,150,20),"Fechar")){
			Application.Quit();
		}
		if(GUI.Button(new Rect(40,80,150,20),"Reiniciar")){
			Application.LoadLevel("Cena1");
		}
	}
}
using UnityEngine;
using System.Collections;

public class pickBin : MonoBehaviour {
	public compostSelect receiver;
	public GameObject bins;
	private bool loading = false;
	public GameObject checkBox;
	public AudioSource buttonClick;
	

	void OnMouseEnter(){
		checkBox.GetComponent<SpriteRenderer>().enabled = true;
	}

	void OnMouseExit(){
		checkBox.GetComponent<SpriteRenderer>().enabled = false;
	}

	void OnMouseDown(){
		buttonClick.Play();
		StartCoroutine(waiting());
	}

	IEnumerator waiting(){
		yield return new WaitForSeconds(0.1f);
		receiver.setBin (bins.name);
	}
}

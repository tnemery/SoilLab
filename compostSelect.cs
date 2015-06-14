using UnityEngine;
using System.Collections;

public class compostSelect : MonoBehaviour {
	private string compost;
	public compostSelect compostScript;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
		compostScript = this;
	}

	public void setBin(string name){
		compost = name;
		print (compost);
		Application.LoadLevel ("lab1");
	}

	public string getBin(){

		return compost;
	}
}

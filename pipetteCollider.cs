using UnityEngine;
using System.Collections;

public class pipetteCollider : MonoBehaviour {
	private pipetteInteraction pipeScript;
	public GameObject thisPipe;
	// Use this for initialization
	void Awake () {
		pipeScript = thisPipe.GetComponent<pipetteInteraction>();
	}


	void OnMouseDown(){
		if(pipeScript.target == true){
			pipeScript.resetPipe();
		}
	}
}

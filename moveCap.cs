using UnityEngine;
using System.Collections;

public class moveCap : MonoBehaviour {
	[HideInInspector]
	public bool capOff = false;
	//private GameObject yey;
	//z - 10, y - 12
	void Start(){
		//yey = this;
	}

	void OnMouseDown(){
		if(!capOff){
			this.renderer.transform.localPosition = new Vector3(this.renderer.transform.localPosition.x,this.renderer.transform.localPosition.y-12f,this.renderer.transform.localPosition.z-10f);
			capOff = true;
		}else{
			this.renderer.transform.localPosition = new Vector3(this.renderer.transform.localPosition.x,this.renderer.transform.localPosition.y+12f,this.renderer.transform.localPosition.z+10f);
			capOff = false;
		}
	}
}

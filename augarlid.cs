using UnityEngine;
using System.Collections;

public class augarlid : MonoBehaviour {
	private bool lidOff = false;
	private float currentF = 0f;

	void OnMouseDown(){
		print (this.transform.parent.name.Substring(5,1));
		if(this.transform.parent.name.Substring(5,1) == "1"){
			currentF = -14f;
		}else if(this.transform.parent.name.Substring(5,1) == "2"){
			currentF = -14f;
		}else if(this.transform.parent.name.Substring(5,1) == "3"){
			currentF = 13f;
		}else if(this.transform.parent.name.Substring(5,1) == "4"){
			currentF = 13f;
		}



		if(!lidOff){
			this.renderer.transform.localPosition = new Vector3(this.renderer.transform.localPosition.x-currentF,this.renderer.transform.localPosition.y,this.renderer.transform.localPosition.z);
			lidOff = true;
		}else{
			this.renderer.transform.localPosition = new Vector3(this.renderer.transform.localPosition.x+currentF,this.renderer.transform.localPosition.y,this.renderer.transform.localPosition.z);
			lidOff = false;
		}
	}
}

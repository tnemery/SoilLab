using UnityEngine;
using System.Collections;

public class whatsInMyHand : MonoBehaviour {
	public bool pipeInHand = false;
	public bool hockeyInHand = false;

	public void setPipe(){
		pipeInHand = !pipeInHand;
		Screen.showCursor = !Screen.showCursor;
	}

	public void setHockey(){
		hockeyInHand = !hockeyInHand;
		Screen.showCursor = !Screen.showCursor;
	}

	public string returnObj(){
		string myObj = "Empty";
		if(pipeInHand){
			myObj = "Pipe";
		}
		if(hockeyInHand){
			myObj = "Hockey";
		}
		return myObj;
	}
}

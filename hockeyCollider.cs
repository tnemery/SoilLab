using UnityEngine;
using System.Collections;

public class hockeyCollider : MonoBehaviour {
	private hockeyInteraction hockeyScript;
	private GameGUI gameoptions;
	public GameObject thisHockey;
	// Use this for initialization
	void Awake () {
		hockeyScript = thisHockey.GetComponent<hockeyInteraction>();
		gameoptions = GameObject.Find("GameGUI").GetComponent<GameGUI>();
	}
	
	void OnMouseDown(){
		if(hockeyScript.target == true){
			hockeyScript.resetHockey();
			if(gameoptions.curStep == 3){
				if(gameoptions.step3progress[1] == 1){
					gameoptions.step3progress[2] = 1;
				}if(gameoptions.step3progress[4] == 1){
					gameoptions.step3progress[5] = 1;
				}if(gameoptions.step3progress[7] == 1){
					gameoptions.step3progress[8] = 1;
				}if(gameoptions.step3progress[10] == 1){
					gameoptions.step3progress[11] = 1;
				}
			}
			if(gameoptions.curStep == 4){
				if(gameoptions.step4progress[5] == 1){
					gameoptions.step4progress[6] = 1;
				}if(gameoptions.step4progress[8] == 1){
					gameoptions.step4progress[9] = 1;
				}if(gameoptions.step4progress[11] == 1){
					gameoptions.step4progress[12] = 1;
				}if(gameoptions.step4progress[14] == 1){
					gameoptions.step4progress[15] = 1;
				}
			}
		}
	}
}

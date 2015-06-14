using UnityEngine;
using System.Collections;

public class flameInteraction : MonoBehaviour {
	private GameObject myObj;
	public GameObject hockeyFlame;
	private GameGUI gameoptions;
	[HideInInspector]
	public bool flammed = false;
	[HideInInspector]
	public bool flamming = false;

	void Awake(){
		gameoptions = GameObject.Find("GameGUI").GetComponent<GameGUI>();
	}

	public bool checkFlamed(){
		return flammed;
	}

	public void setFalse(){
		flammed = false;
	}

	void OnGUI(){
		GUI.skin = gameoptions.popupbox;
		if(flamming){
			gameoptions.popupbox.GetStyle("pop").fontSize = Mathf.CeilToInt(Screen.height/32.727272f);
			GUI.Box (new Rect(Screen.width/1.34f,Screen.height/3.5f,Screen.width/6.4f,Screen.height/3.6f),"Flaming",gameoptions.popupbox.GetStyle("pop"));
		}
	}

	void Update(){
		if(GameObject.Find ("hockeystick").transform.localPosition.x >= 44 && GameObject.Find ("hockeystick").transform.localPosition.x <= 47 &&
		   GameObject.Find ("hockeystick").transform.localPosition.z >= 2 && GameObject.Find ("hockeystick").transform.localPosition.z <= 5){
			//burning the hockey stick
			hockeyFlame.SetActive(true);
			flammed = true;
			flamming = true;
			if(gameoptions.curStep == 3){
				if(gameoptions.step3progress[0] == 0){
					gameoptions.step3progress[0] = 1;
				}if(gameoptions.step3progress[2] == 1){
					gameoptions.step3progress[3] = 1;
				}if(gameoptions.step3progress[5] == 1){
					gameoptions.step3progress[6] = 1;
				}if(gameoptions.step3progress[8] == 1){
					gameoptions.step3progress[9] = 1;
				}
			}
			if(gameoptions.curStep == 4){
				if(gameoptions.step4progress[0] == 1 && gameoptions.step4progress[1] == 1 && gameoptions.step4progress[2] == 1 && gameoptions.step4progress[3] == 1){
					gameoptions.step4progress[4] = 1;
				}if(gameoptions.step4progress[6] == 1){
					gameoptions.step4progress[7] = 1;
				}if(gameoptions.step4progress[9] == 1){
					gameoptions.step4progress[10] = 1;
				}if(gameoptions.step4progress[12] == 1){
					gameoptions.step4progress[13] = 1;
				}
			}
		}else{
			flamming = false;
			hockeyFlame.SetActive(false);
		}
	}
}

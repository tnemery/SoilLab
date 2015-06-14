using UnityEngine;
using System.Collections;

public class lerpCam: MonoBehaviour {
	private Camera myCam;
	private Camera mainCam;
	private float detect;
	private float checkNum = 0f;
	private float smooth = 1.0f;
	private static string mycamname;

	private GameGUI gameoptions;

	private bool camGUIon = false;
	private bool reverse = false;
	private bool doOnce = false;

	private GameObject[] allclickables;
	public GUISkin backoutS;

	void Awake(){
		allclickables = GameObject.FindGameObjectsWithTag("Agar");
		gameoptions = GameObject.Find ("GameGUI").GetComponent<GameGUI>();
		myCam = GameObject.Find("followCam").camera;
		mainCam = GameObject.FindGameObjectWithTag("MainCamera").camera;
		myCam.enabled = false;
	}

	void Update(){
		if(doOnce){
			if(checkNum <= 5f){
				for(int i = 0;i<allclickables.Length;i++){
					allclickables[i].transform.collider.enabled = false;
				}
				PositionChanging();
			}else if(checkNum >= 5f){
				doOnce = false;
				camGUIon = true;
				checkNum = 0f;
			}
			if(reverse){
				reverse = false;
				myCam.enabled = false;
				mainCam.enabled = true;
				myCam.transform.position = mainCam.transform.position;
				myCam.transform.rotation = mainCam.transform.rotation;
				camGUIon = false;
				doOnce = false;
				gameoptions.GUIenabled = true;
				for(int i = 0;i<allclickables.Length;i++){
					allclickables[i].transform.collider.enabled = true;
				}
			}
		}
	}

	void OnGUI(){
		if(camGUIon){
			//do some stuff
			GUI.skin = backoutS;
			if(GUI.Button (new Rect(1,Screen.height-101,200,100),"")){
				reverse = true;
				camGUIon = false;
				doOnce = true;
			}
			GUI.skin = null;
		}
	}

	void OnMouseDown(){
		if(gameoptions.curStep == 5){
			gameoptions.GUIenabled = false;
			mainCam.enabled = false;
			myCam.enabled = true;
			doOnce = true;
			if(this.transform.parent.transform.parent.name == "TSAPlates"){
				if(this.transform.parent.name.Substring(5,1) == "1"){
					mycamname = "camPiv1";
				}
				if(this.transform.parent.name.Substring(5,1) == "2"){
					mycamname = "camPiv2";
				}
				if(this.transform.parent.name.Substring(5,1) == "3"){
					mycamname = "camPiv3";
				}
				if(this.transform.parent.name.Substring(5,1) == "4"){
					mycamname = "camPiv4";
				}
			}
			if(this.transform.parent.transform.parent.name == "PDAPlates"){
				if(this.transform.parent.name.Substring(5,1) == "1"){
					mycamname = "camPiv1_2";
				}
				if(this.transform.parent.name.Substring(5,1) == "2"){
					mycamname = "camPiv2_2";
				}
				if(this.transform.parent.name.Substring(5,1) == "3"){
					mycamname = "camPiv3_2";
				}
				if(this.transform.parent.name.Substring(5,1) == "4"){
					mycamname = "camPiv4_2";
				}
			}
		}
	}




	void PositionChanging ()
	{
		detect = smooth * Time.deltaTime;
		myCam.transform.position = Vector3.Lerp(myCam.transform.position, 
		                                        new Vector3(GameObject.Find(mycamname).gameObject.transform.position.x,GameObject.Find(mycamname).gameObject.transform.position.y,GameObject.Find(mycamname).gameObject.transform.position.z), 
			                                    detect);
		myCam.transform.rotation = Quaternion.Lerp(myCam.transform.rotation, 
		                                           Quaternion.Euler(new Vector3(90f,0f,0f)), 
		                                           detect);
		checkNum = checkNum+detect;
	}




}

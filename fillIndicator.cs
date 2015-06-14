using UnityEngine;
using System.Collections;

public class fillIndicator : MonoBehaviour {
	public GameObject filler;
	public GameObject fillerAmt;
	public GameObject fillerCam;
	private float fill1 = 3.01721f;
	private float fill2 = 10.01721f;
	[HideInInspector]
	public bool first = false;
	[HideInInspector]
	public bool second = false;
	[HideInInspector]
	public bool dump = false;
	[HideInInspector]
	public bool guioff = false;
	public float smooth;
	private float defualtX;
	private float defualtY;
	private float defualtZ;
	private float detect;
	private float checkNum = 0f;
	private fillpipette fillpipescript;
	private string readytxt = "<size=22><color=lime>O</color></size>";
	public GameObject[] fillScripts;
	public GUISkin pipeDump;
	
	public Vector3 initpos;
	// Use this for initialization
	void Awake() {
		//filler.SetActive(false);
		//fillerCam.camera.enabled = false;
		fillpipescript = GameObject.Find ("_MiscComponents").GetComponent<fillpipette>();
		defualtX = fillerAmt.transform.position.x;
		defualtY = fillerAmt.transform.position.y;
		defualtZ = fillerAmt.transform.position.z;
	}
	
	void Start(){
		initpos = GameObject.Find ("measure_amt").transform.position;
	}
	
	public void resetfill(){
		first = false;
		second = false;
		dump = false;
		guioff = false;
		GameObject.Find ("measure_amt").transform.position = initpos;
	}
	
	// Update is called once per frame
	void Update () {
		if(first || second || dump){
			PositionChanging();
			readytxt = "<size=22><color=red>X</color></size>";
		}
		//print(detect);
		if(checkNum >= 5f){
			//filler.SetActive(false);
			//fillerCam.camera.enabled = false;
			//fillerAmt.transform.position = new Vector3(defualtX,defualtY,defualtZ);
			first = false;
			second = false;
			dump = false;
			checkNum = 0f;
			fillpipescript.enabled = true;
			readytxt = "<size=22><color=green>O</color></size>";
		}
	}
	
	public void turnoff(){
		guioff = true;
	}
	
	void OnGUI(){
		//guiText.richText = true;
		if(guioff == false){
			GUI.Box(new Rect(Screen.width-35,Screen.height/2+(Screen.height/10),35,35),readytxt);
			
			if(GUI.Button(new Rect(Screen.width/1.6f,Screen.height-52,50,50),"",pipeDump.GetStyle("Dump"))){
				for(int i = 0; i < fillScripts.Length; i++){
					fillScripts[i].SendMessage("Empty");
				}
				resetfill();
			}
		}
	}
	
	void PositionChanging ()
	{
		detect = smooth * Time.deltaTime;
		if(first){
			fillerAmt.transform.position = Vector3.Lerp(fillerAmt.transform.position, 
			                                            new Vector3(fillerAmt.transform.position.x,fill1,fillerAmt.transform.position.z), 
			                                            detect);
			checkNum = checkNum+detect;
		}if(second){
			fillerAmt.transform.position = Vector3.Lerp(fillerAmt.transform.position, 
			                                            new Vector3(fillerAmt.transform.position.x,fill2,fillerAmt.transform.position.z), 
			                                            detect);
			checkNum = checkNum+detect;
		}
		if(dump){
			fillerAmt.transform.position = Vector3.Lerp(fillerAmt.transform.position, 
			                                            fillerAmt.transform.position = new Vector3(defualtX,defualtY,defualtZ),
			                                            detect);
			checkNum = checkNum+detect;
			
		}
	}
	
	public void makeActive(int fillNum){
		if(fillNum == 1){
			first = true;
			fillpipescript.enabled = false;
		}
		if(fillNum == 2){
			second = true;
			fillpipescript.enabled = false;
		}
		if(fillNum == 3){
			dump = true;
			fillpipescript.enabled = false;
		}
		//filler.SetActive(true);
		//fillerCam.camera.enabled = true;
	}
}

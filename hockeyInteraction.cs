using UnityEngine;
using System.Collections;

public class hockeyInteraction : MonoBehaviour {
	private Vector3 pos;
	private whatsInMyHand handScript;
	[HideInInspector]
	public bool target = false;
	[HideInInspector]
	static public int currentStep = 1;
	public GameObject hockey;
	public GameObject hCollider;
	private float defaultX;
	private float defaultY;
	private float defaultZ;
	// Use this for initialization
	void Awake () {
		handScript = Camera.main.GetComponent<whatsInMyHand>();
		hCollider.collider.enabled = false;
		defaultX = hockey.transform.localPosition.x;
		defaultY = hockey.transform.localPosition.y;
		defaultZ = hockey.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		//print (target);
		if(target){
			pos.x = Input.mousePosition.x;
			pos.z = 40f;
			pos.y = Input.mousePosition.y;
			hockey.transform.localPosition = Camera.main.ScreenToWorldPoint(pos);
			
		}
	}
	
	void OnMouseDown(){
		if(target == false && handScript.returnObj() != "Pipe"){
			handScript.setHockey();
			print ("clicked hockey Stick");
			target = true;
			//Screen.showCursor = false;
			hCollider.collider.enabled = true;
			this.collider.enabled = false;
		}
	}
	
	public void resetHockey(){
		hockey = GameObject.Find ("hockeystick");
		handScript.setHockey();
		Screen.showCursor = true;
		hCollider.collider.enabled = false;
		this.collider.enabled = true;
		hockey.transform.localPosition = new Vector3(defaultX,defaultY,defaultZ);
		enabled = true;
		print ("collision");
		target = false;
	}
}

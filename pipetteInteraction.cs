using UnityEngine;
using System.Collections;

public class pipetteInteraction : MonoBehaviour {
	private Vector3 pos;
	private whatsInMyHand handScript;
	[HideInInspector]
	public bool target = false;
	public GameObject pipe;
	public GameObject pipe2;
	public GameObject pCollider;
	public GameObject bottle1;
	public GameObject bottle2;
	public GameObject bottle3;
	private float defaultX;
	private float defaultY;
	private float defaultZ;
	public GameObject circle;
	// Use this for initialization
	void Awake () {
		handScript = Camera.main.GetComponent<whatsInMyHand>();
		pCollider.collider.enabled = false;
		circle.renderer.enabled = false;
		defaultX = pipe.transform.localPosition.x;
		defaultY = pipe.transform.localPosition.y;
		defaultZ = pipe.transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		//print (target);
		if(target){
			pos.x = Input.mousePosition.x;
			pos.y = Input.mousePosition.y;
			pos.z = 48f;
			pipe.transform.localPosition = Camera.main.ScreenToWorldPoint(pos);

		}
	}

	void OnMouseDown(){
		if(target == false && (handScript.returnObj() != "Hockey" || handScript.returnObj() != "Pipe") ){
			handScript.setPipe();
			pipe2.GetComponent<pipetteInteraction>().enabled = false;
			pipe2.collider.enabled = false;
			//pipe2.SetActive(false);
			print ("clicked pipe");
			target = true;
			//Screen.showCursor = false;
			pCollider.collider.enabled = true;
			circle.renderer.enabled = true;
			pipe.transform.localRotation = Quaternion.Euler(new Vector3(pipe.transform.localRotation.x,pipe.transform.localRotation.y,pipe.transform.localRotation.z-20f));
		}
	}

	public void resetPipe(){
		//pipe = GameObject.Find ("pipette");
		pipe2.GetComponent<pipetteInteraction>().enabled = true;
		pipe2.collider.enabled = true;
		//pipe2.SetActive(true);
		print ("collision");
		target = false;
		handScript.setPipe();
		//Screen.showCursor = true;
		pCollider.collider.enabled = false;
		circle.renderer.enabled = false;
		pipe.transform.localRotation = Quaternion.Euler(new Vector3(66.41712f,130.115f,90.00008f));
		pipe.transform.localPosition = new Vector3(defaultX,defaultY,defaultZ);
	}
}

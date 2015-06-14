using UnityEngine;
using System.Collections;

public class bottleShake : MonoBehaviour {
	public moveCap checkCap;
	public GameGUI gamedata;
	private whatsInMyHand handScript;
	public GameObject water;
	public GameObject cap;
	private bool movebottle,doOnce = false;
	protected Animator animator;
	private float defaultX, defaultY, defaultZ;
	// Use this for initialization
	void Awake () {
		gamedata = GameObject.Find("GameGUI").GetComponent<GameGUI>();
		handScript = Camera.main.GetComponent<whatsInMyHand>();
		animator = this.transform.parent.GetComponent<Animator>();
		animator.enabled = false;
		defaultX = this.transform.parent.localRotation.x;
		defaultY = this.transform.parent.localRotation.y;
		defaultZ = this.transform.parent.localRotation.z;
	}

	// Update is called once per frame
	void Update () {
		if(movebottle)
		{	
			cap.collider.enabled = false;
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			animator.enabled = false;
			this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			if(stateInfo.nameHash == Animator.StringToHash("Base Layer.shake"))
			{
				animator.enabled = true;
				StartCoroutine(waiting());
			}
			else
			{
				animator.enabled = false;
				this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			}
		}else{
			animator.enabled = false;
			this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			cap.collider.enabled = true;
		}
	}

	IEnumerator waiting(){
		if(water.renderer.material.name == "Water_dirty (Instance)"){
			if(gamedata.step1progress[0] == 1){
				gamedata.step1progress[1] = 1;
				gamedata.popup(1);
			}
		}
		if(gamedata.step1progress[2] == 1){
			gamedata.step1progress[3] = 1;
			gamedata.popup(1);
		}
		if(gamedata.step1progress[4] == 1){
			gamedata.step1progress[5] = 1;
			gamedata.popup(1);
		}
		yield return new WaitForSeconds(3);
		movebottle = false;
		animator.enabled = false;
		this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
		doOnce = false;
		gamedata.popup(-1);
		StopAllCoroutines();
	}

	void OnMouseDown(){
		if(checkCap.capOff == false && doOnce == false && handScript.pipeInHand == false && handScript.hockeyInHand == false){
			movebottle = true;
			doOnce = true;
		}
	}
}

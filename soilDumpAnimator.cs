using UnityEngine;
using System.Collections;

public class soilDumpAnimator : MonoBehaviour {
	public moveCap checkCap;
	public GameGUI gamedata;
	[HideInInspector]
	public bool movedumper,doOnce = false;
	protected Animator animator;
	private float defaultX, defaultY, defaultZ;
	public GameObject water;
	public Material dirtyWater;
	// Use this for initialization
	void Awake () {
		checkCap = GameObject.Find("cap1").GetComponent<moveCap>();
		gamedata = GameObject.Find("GameGUI").GetComponent<GameGUI>();
		water = GameObject.Find("water1");
		animator = this.GetComponent<Animator>();
		animator.enabled = false;
		//this.transform.localPosition = new Vector3(this.transform.localPosition.x,this.transform.localPosition.y,this.transform.localPosition.z);
		defaultX = this.transform.localPosition.x;
		defaultY = this.transform.localPosition.y;
		defaultZ = this.transform.localPosition.z;
		this.collider.enabled = true;
		this.transform.Find("soil_dumper_anim_v3").animation.Stop();
		this.transform.Find("soil_dumper_anim_v3").animation.Rewind();
	}
	
	// Update is called once per frame
	void Update () {
		if(movedumper)
		{	
			//cap.collider.enabled = false;
			//get the current state
                                                                            			//this.transform.localPosition = new Vector3(defaultX,defaultY,defaultZ);
			this.transform.Find("soil_dumper_anim_v3").animation.enabled = true;
			this.transform.Find("soil_dumper_anim_v3").animation.Play();
			//AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			//animator.enabled = true;
			//this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			//if(stateInfo.nameHash == Animator.StringToHash("Base Layer.try2"))
			//{
				//animator.enabled = true;
				StartCoroutine(waiting());
				StartCoroutine(dumping());
			//}
			//else
			//{
				//animator.enabled = false;
				//this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			//}
		}else{
			//animator.enabled = false;
			//this.transform.parent.localRotation = Quaternion.Euler(new Vector3(defaultX,defaultY,defaultZ));
			//cap.collider.enabled = true;
		}
	}
	
	IEnumerator waiting(){
		yield return new WaitForSeconds(5);
		movedumper = false;
		this.transform.Find("soil_dumper_anim_v3").animation.enabled = false;
		//animator.enabled = false;
	}

	IEnumerator dumping(){
		yield return new WaitForSeconds(5);
		this.transform.localPosition = new Vector3(defaultX,defaultY,defaultZ);
		this.transform.localRotation = Quaternion.Euler(new Vector3(0f,0f,0f));
		water.renderer.material = dirtyWater;
		gamedata.step1progress[0] = 1;
		doOnce = false;
		this.collider.enabled = false;
		DestroyImmediate(GameObject.Find ("DUMPER"),true);//.SetActive(false);
	}

	void OnMouseDown(){
		if(checkCap.capOff == true && doOnce == false){
			this.transform.localPosition = new Vector3(this.transform.localPosition.x+2f,this.transform.localPosition.y+21f,this.transform.localPosition.z+8f);
			movedumper = true;
			doOnce = true;
		}
	}

}

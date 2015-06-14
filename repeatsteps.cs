using UnityEngine;
using System.Collections;

public class repeatsteps : MonoBehaviour {
	public GameGUI gamedata;
	public bool repeat1 = false;
	public bool repeat2 = false;
	public bool repeat3 = false;
	public bool repeat4 = false;
	public bool repeat5 = false;
	public GameObject DUMPER;
	public GameObject DUMPERnew;
	public GameObject bottle1;
	public GameObject bottle2;
	public GameObject bottle3;
	public GameObject water;
	public GameObject water2;
	public Material normalWater;

	public GameObject aug1_1;
	public GameObject aug1_2;
	public GameObject aug1_3;
	public GameObject aug1_4;
	public GameObject aug2_1;
	public GameObject aug2_2;
	public GameObject aug2_3;
	public GameObject aug2_4;
	public Material normalaug;
	public Material waterdrop;
	public Material waterspread;

	public GUISkin retry;

	private fillIndicator fillIndicate;

	void Awake(){
		fillIndicate = GameObject.Find ("GameGUI").GetComponent<fillIndicator>();
		gamedata = GameObject.Find("GameGUI").GetComponent<GameGUI>();
	}

	public bool checksteps(){
		if(gamedata.curStep == 1){
			if(gamedata.step1progress[0] == 0 && gamedata.step1progress[1] == 1){
				//steps out of order
				repeatstep1();
				return false;
			}else if(gamedata.step1progress[1] == 0 && gamedata.step1progress[2] == 1){
				repeatstep1();
				return false;
			}else if(gamedata.step1progress[2] == 0 && gamedata.step1progress[3] == 1){
				repeatstep1();
				return false;
			}else if(gamedata.step1progress[3] == 0 && gamedata.step1progress[4] == 1){
				repeatstep1();
				return false;
			}else if(gamedata.step1progress[4] == 0 && gamedata.step1progress[5] == 1){
				repeatstep1();
				return false;
			}else if(gamedata.step1progress[0] == 0 || 
			         gamedata.step1progress[1] == 0 ||
			         gamedata.step1progress[2] == 0 ||
			         gamedata.step1progress[3] == 0 ||
			         gamedata.step1progress[4] == 0 ||
			         gamedata.step1progress[5] == 0){
				//check all data paths
				repeatstep1();
				return false;
			}else{
				return true;
			}
			//check completion
		}
		if(gamedata.curStep == 2){
			//check completion
			if(gamedata.step2progress[0] == 0 && gamedata.step2progress[1] == 1){
				//steps out of order
				repeatstep2();
				return false;
			}else if(gamedata.step2progress[1] == 0 && gamedata.step2progress[2] == 1){
				repeatstep2();
				return false;
			}else if(gamedata.step2progress[2] == 0 && gamedata.step2progress[3] == 1){
				repeatstep2();
				return false;
			}else if(gamedata.step2progress[0] == 0 || 
		          gamedata.step2progress[1] == 0 ||
		          gamedata.step2progress[2] == 0 ||
		          gamedata.step2progress[3] == 0){
			//check all data paths
			repeatstep2();
			return false;
		}else{
				return true;
			}
		}
		if(gamedata.curStep == 3){
			//check completion
			if(gamedata.step3progress[0] == 0 && gamedata.step3progress[1] == 1){
				//steps out of order
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[1] == 0 && gamedata.step3progress[2] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[2] == 0 && gamedata.step3progress[3] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[3] == 0 && gamedata.step3progress[4] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[4] == 0 && gamedata.step3progress[5] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[5] == 0 && gamedata.step3progress[6] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[6] == 0 && gamedata.step3progress[7] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[7] == 0 && gamedata.step3progress[8] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[8] == 0 && gamedata.step3progress[9] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[9] == 0 && gamedata.step3progress[10] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[10] == 0 && gamedata.step3progress[11] == 1){
				repeatstep3();
				return false;
			}else if(gamedata.step3progress[0] == 0 || 
			         gamedata.step3progress[1] == 0 ||
			         gamedata.step3progress[2] == 0 ||
			         gamedata.step3progress[3] == 0 ||
			         gamedata.step3progress[4] == 0 ||
			         gamedata.step3progress[5] == 0 ||
			         gamedata.step3progress[6] == 0 ||
			         gamedata.step3progress[7] == 0 ||
			         gamedata.step3progress[8] == 0 ||
			         gamedata.step3progress[9] == 0 ||
			         gamedata.step3progress[10] == 0 ||
			         gamedata.step3progress[11] == 0){
				//check all data paths
				repeatstep3();
				return false;
			}else{
				return true;
			}
		}
		if(gamedata.curStep == 4){
			//check completion
			if(gamedata.step4progress[0] == 0 && gamedata.step4progress[1] == 1){
				//steps out of order
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[1] == 0 && gamedata.step4progress[2] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[2] == 0 && gamedata.step4progress[3] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[3] == 0 && gamedata.step4progress[4] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[4] == 0 && gamedata.step4progress[5] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[5] == 0 && gamedata.step4progress[6] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[6] == 0 && gamedata.step4progress[7] == 1){
				repeatstep4();
				return false;
			}else if(gamedata.step4progress[0] == 0 || 
			         gamedata.step4progress[1] == 0 ||
			         gamedata.step4progress[2] == 0 ||
			         gamedata.step4progress[3] == 0 ||
			         gamedata.step4progress[4] == 0 ||
			         gamedata.step4progress[5] == 0 ||
			         gamedata.step4progress[6] == 0 ||
			         gamedata.step4progress[7] == 0){
				//check all data paths
				repeatstep4();
				return false;
			}else{
				return true;
			}
		}
		if(gamedata.curStep == 5){
			//check completion
		}

		return false;
	}

	public void repeatstep1(){
		repeat1 = true;
	}

	public void repeatstep2(){
		repeat2 = true;
	}

	public void repeatstep3(){
		repeat3 = true;
	}

	public void repeatstep4(){
		repeat4 = true;
	}

	public void repeatstep5(){
		repeat5 = true;
	}

	public void OnGUI(){
		GUI.skin = retry;
		if(repeat1){
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,100), "Something went wrong, would you like to try again?");
			if(GUI.Button(new Rect(Screen.width/2+25,Screen.height/2+30,150,70),"")){
				gamedata.step1progress[0] = 0; 
				gamedata.step1progress[1] = 0;
				gamedata.step1progress[2] = 0;
				gamedata.step1progress[3] = 0;
				gamedata.step1progress[4] = 0;
				gamedata.step1progress[5] = 0;
				fillIndicate.resetfill();
				water.renderer.material = normalWater;
				water2.renderer.material = normalWater;
				if(GameObject.Find("DUMPER") != null){
					DestroyImmediate(GameObject.Find("DUMPER"),true);
				}
				DUMPERnew = (GameObject)Instantiate(DUMPER, new Vector3(60.64368f,17.59855f,28.28142f), Quaternion.Euler(13.46102f,226.7436f,0f)) as GameObject;
				DUMPERnew.name = "DUMPER";
				DUMPERnew.transform.Find("actualdumper").gameObject.GetComponent<soilDumpAnimator>().enabled = true;
				DUMPERnew.SetActive(true);
				repeat1 = false;
			}
		}
		if(repeat2){
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,100), "Something went wrong, would you like to try again?");
			if(GUI.Button(new Rect(Screen.width/2+25,Screen.height/2+30,150,70),"")){
				gamedata.step2progress[0] = 0; 
				gamedata.step2progress[1] = 0;
				gamedata.step2progress[2] = 0;
				gamedata.step2progress[3] = 0;
				aug1_1.renderer.material = normalaug;
				aug1_2.renderer.material = normalaug;
				aug1_3.renderer.material = normalaug;
				aug1_4.renderer.material = normalaug;
				gamedata.aug1circy.renderer.enabled = false;
				gamedata.aug2circy.renderer.enabled = false;
				gamedata.aug3circy.renderer.enabled = false;
				gamedata.aug4circy.renderer.enabled = false;
				gamedata.TSA1text = "";
				gamedata.TSA2text = "";
				gamedata.TSA3text = "";
				gamedata.TSA4text = "";
				fillIndicate.resetfill();
				repeat2 = false;
			}
		}
		if(repeat3){
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,100), "Something went wrong, would you like to try again?");
			if(GUI.Button(new Rect(Screen.width/2+25,Screen.height/2+30,150,70),"")){
				gamedata.step3progress[0] = 0;
				gamedata.step3progress[1] = 0;
				gamedata.step3progress[2] = 0;
				gamedata.step3progress[3] = 0;
				gamedata.step3progress[4] = 0;
				gamedata.step3progress[5] = 0;
				gamedata.step3progress[6] = 0;
				gamedata.step3progress[7] = 0;
				gamedata.step3progress[8] = 0;
				gamedata.step3progress[9] = 0;
				gamedata.step3progress[10] = 0;
				gamedata.step3progress[11] = 0;
				gamedata.aug1circr.renderer.enabled = false;
				gamedata.aug2circr.renderer.enabled = false;
				gamedata.aug3circr.renderer.enabled = false;
				gamedata.aug4circr.renderer.enabled = false;
				gamedata.aug1circy.renderer.enabled = true;
				gamedata.aug2circy.renderer.enabled = true;
				gamedata.aug3circy.renderer.enabled = true;
				gamedata.aug4circy.renderer.enabled = true;
				aug1_1.renderer.material = waterdrop;
				aug1_2.renderer.material = waterdrop;
				aug1_3.renderer.material = waterdrop;
				aug1_4.renderer.material = waterdrop;
				fillIndicate.resetfill();
				repeat3 = false;
			}
		}
		if(repeat4){
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,100), "Something went wrong, would you like to try again?");
			if(GUI.Button(new Rect(Screen.width/2+25,Screen.height/2+30,150,70),"")){
				repeat4 = false;
				gamedata.step4progress[0] = 0;
				gamedata.step4progress[1] = 0;
				gamedata.step4progress[2] = 0;
				gamedata.step4progress[3] = 0;
				gamedata.step4progress[4] = 0;
				gamedata.step4progress[5] = 0;
				gamedata.step4progress[6] = 0;
				gamedata.step4progress[7] = 0;
				gamedata.step4progress[8] = 0;
				gamedata.step4progress[9] = 0;
				gamedata.step4progress[10] = 0;
				gamedata.step4progress[11] = 0;
				gamedata.step4progress[12] = 0;
				gamedata.step4progress[13] = 0;
				gamedata.step4progress[14] = 0;
				gamedata.step4progress[15] = 0;
				gamedata.aug1circr_2.renderer.enabled = false;
				gamedata.aug2circr_2.renderer.enabled = false;
				gamedata.aug3circr_2.renderer.enabled = false;
				gamedata.aug4circr_2.renderer.enabled = false;
				gamedata.aug1circy_2.renderer.enabled = false;
				gamedata.aug2circy_2.renderer.enabled = false;
				gamedata.aug3circy_2.renderer.enabled = false;
				gamedata.aug4circy_2.renderer.enabled = false;
				aug2_1.renderer.material = normalaug;
				aug2_2.renderer.material = normalaug;
				aug2_3.renderer.material = normalaug;
				aug2_4.renderer.material = normalaug;
				gamedata.PDA1text = "";
				gamedata.PDA2text = "";
				gamedata.PDA3text = "";
				gamedata.PDA4text = "";
				fillIndicate.resetfill();
			}
		}
		if(repeat5){
			GUI.Box(new Rect(Screen.width/2,Screen.height/2,200,100), "Something went wrong, would you like to try again?");
			if(GUI.Button(new Rect(Screen.width/2+25,Screen.height/2+30,150,70),"")){
				repeat5 = false;
			}
		}
	}

}

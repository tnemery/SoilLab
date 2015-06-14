using UnityEngine;
using System.Collections;

public class fillpipette : MonoBehaviour {
	private moveCap checkCap;
	private dumpinaugar agardump;
	[HideInInspector]
	public GameGUI gamedata;
	private whatsInMyHand handScript;
	private fillIndicator fillScript;
	private bool filling = false;
	static private bool fill1 = false;
	static private bool fill2 = false;
	static private bool bot1 = false;
	static private bool bot2 = false;
	static private bool bot3 = false;
	static private bool dumping = false;
	static private int firstfill = 0;
	[HideInInspector]
	static public int currentStep = 1;
	[HideInInspector]
	public calcDelution calc;
	
	// Use this for initialization
	void Awake () {
		calc = GameObject.Find ("GameGUI").GetComponent<calcDelution>();
		agardump = GameObject.Find ("agar_1").GetComponent<dumpinaugar>();
		gamedata = GameObject.Find("GameGUI").GetComponent<GameGUI>();
		handScript = Camera.main.GetComponent<whatsInMyHand>();
		fillScript = GameObject.Find ("GameGUI").GetComponent<fillIndicator>();
		fill1 = false;
		fill2 = false;
		bot1 = false;
		bot2 = false;
		bot3 = false;
		dumping = false;
		firstfill = 0;
		currentStep = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(filling){
			//print ("fill");
			StartCoroutine(waitone());
		}
	}
	
	IEnumerator waitone(){
		yield return new WaitForSeconds(1);
		filling = false;
		StopAllCoroutines();
		//print ("full");
	}
	
	IEnumerator wait1sec(){
		yield return new WaitForSeconds(1);
		StopAllCoroutines();
		gamedata.popup(-1);
		//print ("full");
	}
	
	void figureoutfills(int num){
		if(firstfill == 0){
			firstfill = num;
		}
	}
	
	public void changeStep(int num){
		currentStep = num;
	}
	
	
	public void reset(){
		fill1 = false;
		fill2 = false;
		bot1 = false;
		bot2 = false;
		bot3 = false;
		dumping = false;
		firstfill = 0;
		currentStep = 1;
	}
	
	public void Empty(){
		fill2 = false;
		fill1 = false;
		print ("dumped");
		dumping = false;
	}
	
	void fillup(){
		if(dumping == false){
			if(fill1 == true){
				if(fill2 != true){
					fillScript.makeActive(2);
					fill2 = true;
					filling = true;
				}//else over full
			}else{
				fillScript.makeActive(1);
				fill1 = true;
				filling = true;
			}
		}
		
		if(dumping == true && currentStep == 1){
			firstfill = 0;
			dumping = false;
		}
		
	}
	
	void dumpaug(int num){
		dumping = true;
		if(currentStep == 2){
			if(fill2 == true){
				fill2 = false;
				fill1 = false;
				print ("dumped");
				dumping = false;
				fillScript.makeActive(3);
				if(bot2){
					if(num == 1){
						gamedata.aug1circr.renderer.enabled = false;
						gamedata.aug1circy.renderer.enabled = true;
						gamedata.aug1_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr.renderer.enabled = false;
						gamedata.aug2circy.renderer.enabled = true;
						gamedata.aug1_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr.renderer.enabled = false;
						gamedata.aug3circy.renderer.enabled = true;
						gamedata.aug1_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr.renderer.enabled = false;
						gamedata.aug4circy.renderer.enabled = true;
						gamedata.aug1_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step2progress[0] = 1;
					gamedata.updatenumbers(num,calc.calc(.0001f,1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}else if(bot3){
					if(num == 1){
						gamedata.aug1circr.renderer.enabled = false;
						gamedata.aug1circy.renderer.enabled = true;
						gamedata.aug1_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr.renderer.enabled = false;
						gamedata.aug2circy.renderer.enabled = true;
						gamedata.aug1_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr.renderer.enabled = false;
						gamedata.aug3circy.renderer.enabled = true;
						gamedata.aug1_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr.renderer.enabled = false;
						gamedata.aug4circy.renderer.enabled = true;
						gamedata.aug1_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step2progress[2] = 1;
					gamedata.updatenumbers(num,calc.calc(.000001f,1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}
				bot1 = bot2 = bot3 = false;
			}else if(fill1 == true){
				fill1 = false;
				print ("dumped");
				dumping = false;
				fillScript.makeActive(3);
				if(bot2){
					if(num == 1){
						gamedata.aug1circr.renderer.enabled = false;
						gamedata.aug1circy.renderer.enabled = true;
						gamedata.aug1_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr.renderer.enabled = false;
						gamedata.aug2circy.renderer.enabled = true;
						gamedata.aug1_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr.renderer.enabled = false;
						gamedata.aug3circy.renderer.enabled = true;
						gamedata.aug1_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr.renderer.enabled = false;
						gamedata.aug4circy.renderer.enabled = true;
						gamedata.aug1_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step2progress[1] = 1;
					gamedata.updatenumbers(num,calc.calc(.0001f,.1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}else if(bot3){
					if(num == 1){
						gamedata.aug1circr.renderer.enabled = false;
						gamedata.aug1circy.renderer.enabled = true;
						gamedata.aug1_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr.renderer.enabled = false;
						gamedata.aug2circy.renderer.enabled = true;
						gamedata.aug1_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr.renderer.enabled = false;
						gamedata.aug3circy.renderer.enabled = true;
						gamedata.aug1_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr.renderer.enabled = false;
						gamedata.aug4circy.renderer.enabled = true;
						gamedata.aug1_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step2progress[3] = 1;
					gamedata.updatenumbers(num,calc.calc(.000001f,.1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}
				bot1 = bot2 = bot3 = false;
			}else{
				print ("nothing to dump");
			}
		}
		if(currentStep == 4){
			if(fill2 == true){
				fill2 = false;
				fill1 = false;
				print ("dumped");
				dumping = false;
				fillScript.makeActive(3);
				if(bot1){
					if(num == 1){
						gamedata.aug1circr_2.renderer.enabled = false;
						gamedata.aug1circy_2.renderer.enabled = true;
						gamedata.aug2_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr_2.renderer.enabled = false;
						gamedata.aug2circy_2.renderer.enabled = true;
						gamedata.aug2_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr_2.renderer.enabled = false;
						gamedata.aug3circy_2.renderer.enabled = true;
						gamedata.aug2_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr_2.renderer.enabled = false;
						gamedata.aug4circy_2.renderer.enabled = true;
						gamedata.aug2_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step4progress[0] = 1;
					gamedata.updatenumbers(num,calc.calc(.01f,1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}else if(bot2){
					if(num == 1){
						gamedata.aug1circr_2.renderer.enabled = false;
						gamedata.aug1circy_2.renderer.enabled = true;
						gamedata.aug2_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr_2.renderer.enabled = false;
						gamedata.aug2circy_2.renderer.enabled = true;
						gamedata.aug2_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr_2.renderer.enabled = false;
						gamedata.aug3circy_2.renderer.enabled = true;
						gamedata.aug2_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr_2.renderer.enabled = false;
						gamedata.aug4circy_2.renderer.enabled = true;
						gamedata.aug2_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step4progress[2] = 1;
					gamedata.updatenumbers(num,calc.calc(.0001f,1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}
				bot1 = bot2 = bot3 = false;
			}else if(fill1 == true){
				fill1 = false;
				print ("dumped");
				dumping = false;
				fillScript.makeActive(3);
				if(bot1){
					if(num == 1){
						gamedata.aug1circr_2.renderer.enabled = false;
						gamedata.aug1circy_2.renderer.enabled = true;
						gamedata.aug2_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr_2.renderer.enabled = false;
						gamedata.aug2circy_2.renderer.enabled = true;
						gamedata.aug2_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr_2.renderer.enabled = false;
						gamedata.aug3circy_2.renderer.enabled = true;
						gamedata.aug2_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr_2.renderer.enabled = false;
						gamedata.aug4circy_2.renderer.enabled = true;
						gamedata.aug2_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step4progress[1] = 1;
					gamedata.updatenumbers(num,calc.calc(.01f,.1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}else if(bot2){
					if(num == 1){
						gamedata.aug1circr_2.renderer.enabled = false;
						gamedata.aug1circy_2.renderer.enabled = true;
						gamedata.aug2_1_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 2){
						gamedata.aug2circr_2.renderer.enabled = false;
						gamedata.aug2circy_2.renderer.enabled = true;
						gamedata.aug2_2_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 3){
						gamedata.aug3circr_2.renderer.enabled = false;
						gamedata.aug3circy_2.renderer.enabled = true;
						gamedata.aug2_3_mat.renderer.material = gamedata.soil_drop;
					}
					if(num == 4){
						gamedata.aug4circr_2.renderer.enabled = false;
						gamedata.aug4circy_2.renderer.enabled = true;
						gamedata.aug2_4_mat.renderer.material = gamedata.soil_drop;
					}
					gamedata.step4progress[3] = 1;
					gamedata.updatenumbers(num,calc.calc(.0001f,.1f));
					gamedata.popup(1);
					StartCoroutine(wait1sec());
				}
				bot1 = bot2 = bot3 = false;
			}else{
				print ("nothing to dump");
			}
		}
	}
	
	void OnMouseDown(){
		if(fillScript.first || fillScript.second || fillScript.dump) print("true?");
		else if(handScript.pipeInHand){
			if(currentStep == 1){
				if(handScript.pipeInHand == true){
					if(this.gameObject.name == "bottle1"){
						checkCap = GameObject.Find("cap1").GetComponent<moveCap>();
						bot1 = true;
						figureoutfills(1);
					}
					if(this.gameObject.name == "bottle2"){
						checkCap = GameObject.Find("cap2").GetComponent<moveCap>();
						bot2 = true;
						figureoutfills(2);
					}
					if(this.gameObject.name == "bottle3"){
						checkCap = GameObject.Find("cap3").GetComponent<moveCap>();
						bot3 = true;
						figureoutfills(3);
					}
					if(checkCap.capOff == true){
						if((bot1 && bot2) && (fill1 || fill2)){
							if(bot3){ //opps!
								dumping = true;
								bot1 = bot2 = bot3 = false;
							}else{
								dumping = true;
								bot1 = bot2 = false;
								if(fill2 == true){
									fill2 = false;
									fill1 = false;
									if(firstfill == 1){
										if(gamedata.step1progress[1] == 1){
											gamedata.step1progress[2] = 1;
											gamedata.popup(1);
											StartCoroutine(wait1sec());
										}
									}
									//change water here
									gamedata.water2.renderer.material = gamedata.slightlydirtywater;
									print ("dumped");
								}else if(fill1 == true){
									fill1 = false;
								}
								fillScript.makeActive(3);
							}
						}
						if((bot2 && bot3) && (fill1 || fill2)){
							if(bot1){ //opps!
								dumping = true;
								bot1 = bot2 = bot3 = false;
							}else{
								dumping = true;
								bot3 = bot2 = false;
								if(fill2 == true){
									fill2 = false;
									fill1 = false;
									if(firstfill == 2){
										if(gamedata.step1progress[3] == 1){
											gamedata.step1progress[4] = 1;
											gamedata.popup(1);
											StartCoroutine(wait1sec());
										}
									}
									print ("dumped");
								}else if(fill1 == true){
									fill1 = false;
									print ("dumped");
								}
								fillScript.makeActive(3);
							}
						}
						if(bot1 && bot3){
							print ("error");
						}
						fillup();
					}
				}
			}
			if(currentStep == 2){
				if(this.gameObject.name == "bottle1"){
					checkCap = GameObject.Find("cap1").GetComponent<moveCap>();
					bot1 = true;
					figureoutfills(1);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.name == "bottle2"){
					checkCap = GameObject.Find("cap2").GetComponent<moveCap>();
					bot2 = true;
					figureoutfills(2);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.name == "bottle3"){
					checkCap = GameObject.Find("cap3").GetComponent<moveCap>();
					bot3 = true;
					figureoutfills(3);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.transform.parent.name == "agar_1"){
					print (agardump.getlidopen(1));
					dumpaug(1);
				}
				if(this.gameObject.transform.parent.name == "agar_2"){
					print (agardump.getlidopen(2));
					dumpaug(2);
				}
				if(this.gameObject.transform.parent.name == "agar_3"){
					print (agardump.getlidopen(3));
					dumpaug(3);
				}
				if(this.gameObject.transform.parent.name == "agar_4"){
					print (agardump.getlidopen(4));
					dumpaug(4);
				}
			}
			if(currentStep == 4){
				if(this.gameObject.name == "bottle1"){
					checkCap = GameObject.Find("cap1").GetComponent<moveCap>();
					bot1 = true;
					figureoutfills(1);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.name == "bottle2"){
					checkCap = GameObject.Find("cap2").GetComponent<moveCap>();
					bot2 = true;
					figureoutfills(2);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.name == "bottle3"){
					checkCap = GameObject.Find("cap3").GetComponent<moveCap>();
					bot3 = true;
					figureoutfills(3);
					if(checkCap.capOff == true){
						fillup();
					}
				}
				if(this.gameObject.transform.parent.name == "agar_1_2"){
					print (agardump.getlidopen(1));
					dumpaug(1);
				}
				if(this.gameObject.transform.parent.name == "agar_2_2"){
					print (agardump.getlidopen(2));
					dumpaug(2);
				}
				if(this.gameObject.transform.parent.name == "agar_3_2"){
					print (agardump.getlidopen(3));
					dumpaug(3);
				}
				if(this.gameObject.transform.parent.name == "agar_4_2"){
					print (agardump.getlidopen(4));
					dumpaug(4);
				}
			}
		}
	}
}

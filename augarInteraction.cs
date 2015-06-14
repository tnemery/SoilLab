using UnityEngine;
using System.Collections;

public class augarInteraction : MonoBehaviour {
	private whatsInMyHand handScript;
	//private augarlid currentlid;
	private GameGUI gameData;
	private static bool waits4 = false;
	private static bool waits3 = false;

	void Awake(){
		handScript = Camera.main.GetComponent<whatsInMyHand>();
		gameData = GameObject.Find ("GameGUI").GetComponent<GameGUI>();
		//currentlid = GameObject.Find("Top_agar").GetComponent<currentlid>();
	}

	void step3data(){
		if(gameData.step3progress[0] == 1){
			gameData.step3progress[1] = 1;
		}if(gameData.step3progress[3] == 1){
			gameData.step3progress[4] = 1;
		}if(gameData.step3progress[6] == 1){
			gameData.step3progress[7] = 1;
		}if(gameData.step3progress[9] == 1){
			gameData.step3progress[10] = 1;
		}
	}

	void step4data(){
		if(gameData.step4progress[4] == 1){
			gameData.step4progress[5] = 1;
		}if(gameData.step4progress[7] == 1){
			gameData.step4progress[8] = 1;
		}if(gameData.step4progress[10] == 1){
			gameData.step4progress[11] = 1;
		}if(gameData.step4progress[13] == 1){
			gameData.step4progress[14] = 1;
		}
	}

	void OnMouseEnter(){
		if(gameData.curStep == 3 && handScript.returnObj() == "Hockey" && waits3 == false){
			StartCoroutine(waiting3());
		}
		if(gameData.curStep == 4 && handScript.returnObj() == "Hockey" && waits4 == false){
			StartCoroutine(waiting4());
		}
	}

	IEnumerator waiting4(){
		waits4 = true;
		yield return new WaitForSeconds(2);
		waits4 = false;
		if(this.transform.parent.gameObject.name == "agar_1_2"){
			gameData.aug1circy_2.renderer.enabled = false;
			gameData.aug1circr_2.renderer.enabled = true;
			gameData.aug2_1_mat.renderer.material = gameData.waterSpread;
			step4data();
		}
		if(this.transform.parent.gameObject.name == "agar_2_2"){
			gameData.aug2circy_2.renderer.enabled = false;
			gameData.aug2circr_2.renderer.enabled = true;
			gameData.aug2_2_mat.renderer.material = gameData.waterSpread;
			step4data();
		}
		if(this.transform.parent.gameObject.name == "agar_3_2"){
			gameData.aug3circy_2.renderer.enabled = false;
			gameData.aug3circr_2.renderer.enabled = true;
			gameData.aug2_3_mat.renderer.material = gameData.waterSpread;
			step4data();
		}
		if(this.transform.parent.gameObject.name == "agar_4_2"){
			gameData.aug4circy_2.renderer.enabled = false;
			gameData.aug4circr_2.renderer.enabled = true;
			gameData.aug2_4_mat.renderer.material = gameData.waterSpread;
			step4data();
		}
	}

	IEnumerator waiting3(){
		waits3 = true;
		if(this.transform.parent.gameObject.name == "agar_1" && gameData.aug1_1_mat.renderer.material == gameData.waterSpread){
			waits3 = false;
			StopCoroutine("waiting3");
		}
		if(this.transform.parent.gameObject.name == "agar_2" && gameData.aug1_2_mat.renderer.material == gameData.waterSpread){
			waits3 = false;
			StopCoroutine("waiting3");
		}
		if(this.transform.parent.gameObject.name == "agar_3" && gameData.aug1_3_mat.renderer.material == gameData.waterSpread){
			waits3 = false;
			StopCoroutine("waiting3");
		}
		if(this.transform.parent.gameObject.name == "agar_4" && gameData.aug1_4_mat.renderer.material == gameData.waterSpread){
			waits3 = false;
			StopCoroutine("waiting3");
		}
		yield return new WaitForSeconds(2);
		waits3 = false;
		if(this.transform.parent.gameObject.name == "agar_1"){
			gameData.aug1circy.renderer.enabled = false;
			gameData.aug1circr.renderer.enabled = true;
			gameData.aug1_1_mat.renderer.material = gameData.waterSpread;
			step3data();
		}
		if(this.transform.parent.gameObject.name == "agar_2"){
			gameData.aug2circy.renderer.enabled = false;
			gameData.aug2circr.renderer.enabled = true;
			gameData.aug1_2_mat.renderer.material = gameData.waterSpread;
			step3data();
		}
		if(this.transform.parent.gameObject.name == "agar_3"){
			gameData.aug3circy.renderer.enabled = false;
			gameData.aug3circr.renderer.enabled = true;
			gameData.aug1_3_mat.renderer.material = gameData.waterSpread;
			step3data();
		}
		if(this.transform.parent.gameObject.name == "agar_4"){
			gameData.aug4circy.renderer.enabled = false;
			gameData.aug4circr.renderer.enabled = true;
			gameData.aug1_4_mat.renderer.material = gameData.waterSpread;
			step3data();
		}
	}

}

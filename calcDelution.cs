using UnityEngine;
using System.Collections;

public class calcDelution : MonoBehaviour {

	//using later bac[bin][delution] fung[bin][delution]
	public Material[] bac11;
	public Material[] bac12;
	public Material[] bac13;
	public Material[] bac14;

	public Material[] bac21;
	public Material[] bac22;
	public Material[] bac23;
	public Material[] bac24;

	public Material[] bac31;
	public Material[] bac32;
	public Material[] bac33;
	public Material[] bac34;

	public Material[] bac41;
	public Material[] bac42;
	public Material[] bac43;
	public Material[] bac44;

	public Material[] fung11;
	public Material[] fung12;
	public Material[] fung13;
	public Material[] fung14;

	public Material[] fung21;
	public Material[] fung22;
	public Material[] fung23;
	public Material[] fung24;

	public Material[] fung31;
	public Material[] fung32;
	public Material[] fung33;
	public Material[] fung34;

	public Material[] fung41;
	public Material[] fung42;
	public Material[] fung43;
	public Material[] fung44;

	private string curBin;
	private compostSelect getBin;

	void Awake(){
		getBin = GameObject.Find("binData").GetComponent<compostSelect>();
		curBin = getBin.getBin();
		print (curBin);
	}

	//called from fillpipette.cs
	public float calc(float delution,float amt){
		return (float)(delution * amt); //delution(from something), amt(from pippette half or full)
	}

	public float finalcalc(float delution, int count){
		return ((float)(1f/delution)*(float)count);
	}


	//check bin and do a select from that type
	public void setfinalMats(GameObject aug, int type, float num){
		//nums: 1,0.1,0.01,0.001,0.0001,0.00001
		if(curBin == "bin1"){
			if(num == .01f){
				aug.renderer.material = fung14[Random.Range(0,fung14.Length)];
			}if(num == 0.001f){
				aug.renderer.material = fung13[Random.Range(0,fung13.Length)];
			}if(num == 0.0001f){
				if(type == 1){
					aug.renderer.material = bac14[Random.Range(0,bac14.Length)];
				}if(type == 2){
					aug.renderer.material = fung11[Random.Range(0,fung11.Length)];
				}
			}if(num == 0.00001f){
				if(type == 1){
					aug.renderer.material = bac13[Random.Range(0,bac13.Length)];
				}if(type == 2){
					aug.renderer.material = fung12[Random.Range(0,fung12.Length)];
				}
			}if(num == 0.000001f){
				aug.renderer.material = bac12[Random.Range(0,bac12.Length)];
			}if(num == 0.0000001f){
				aug.renderer.material = bac11[Random.Range(0,bac11.Length)];
			}
		}
		if(curBin == "bin2"){
			if(num == .01f){
				aug.renderer.material = fung23[Random.Range(0,fung23.Length)];
			}if(num == 0.001f){
				aug.renderer.material = fung24[Random.Range(0,fung24.Length)];
			}if(num == 0.0001f){
				if(type == 1){
					aug.renderer.material = bac24[Random.Range(0,bac24.Length)];
				}if(type == 2){
					aug.renderer.material = fung21[Random.Range(0,fung21.Length)];
				}
			}if(num == 0.00001f){
				if(type == 1){
					aug.renderer.material = bac23[Random.Range(0,bac23.Length)];
				}if(type == 2){
					aug.renderer.material = fung22[Random.Range(0,fung22.Length)];
				}
			}if(num == 0.000001f){
				aug.renderer.material = bac22[Random.Range(0,bac22.Length)];
			}if(num == 0.0000001f){
				aug.renderer.material = bac21[Random.Range(0,bac21.Length)];
			}
		}
		if(curBin == "bin3"){
			if(num == .01f){
				aug.renderer.material = fung32[Random.Range(0,fung32.Length)];
			}if(num == 0.001f){
				aug.renderer.material = fung33[Random.Range(0,fung33.Length)];
			}if(num == 0.0001f){
				if(type == 1){
					aug.renderer.material = bac34[Random.Range(0,bac34.Length)];
				}if(type == 2){
					aug.renderer.material = fung31[Random.Range(0,fung31.Length)];
				}
			}if(num == 0.00001f){
				if(type == 1){
					aug.renderer.material = bac33[Random.Range(0,bac33.Length)];
				}if(type == 2){
					aug.renderer.material = fung34[Random.Range(0,fung34.Length)];
				}
			}if(num == 0.000001f){
				aug.renderer.material = bac32[Random.Range(0,bac32.Length)];
			}if(num == 0.0000001f){
				aug.renderer.material = bac31[Random.Range(0,bac31.Length)];
			}
		}
		if(curBin == "bin4"){
			if(num == .01f){
				aug.renderer.material = fung43[Random.Range(0,fung43.Length)];
			}if(num == 0.001f){
				aug.renderer.material = fung44[Random.Range(0,fung44.Length)];
			}if(num == 0.0001f){
				if(type == 1){
					aug.renderer.material = bac44[Random.Range(0,bac44.Length)];
				}if(type == 2){
					aug.renderer.material = fung41[Random.Range(0,fung41.Length)];
				}
			}if(num == 0.00001f){
				if(type == 1){
					aug.renderer.material = bac43[Random.Range(0,bac43.Length)];
				}if(type == 2){
					aug.renderer.material = fung42[Random.Range(0,fung42.Length)];
				}
			}if(num == 0.000001f){
				aug.renderer.material = bac42[Random.Range(0,bac42.Length)];
			}if(num == 0.0000001f){
				aug.renderer.material = bac41[Random.Range(0,bac41.Length)];
			}
		}
	}
}

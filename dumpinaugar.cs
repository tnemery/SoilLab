using UnityEngine;
using System.Collections;

public class dumpinaugar : MonoBehaviour {
	[HideInInspector]
	static public bool lid1open = false;
	[HideInInspector]
	static public bool lid2open = false;
	[HideInInspector]
	static public bool lid3open = false;
	[HideInInspector]
	static public bool lid4open = false;

	public void updatelid(int lidnum){
		if(lidnum == 1){
			lid1open = !lid1open;
		}
		if(lidnum == 2){
			lid2open = !lid2open;
		}
		if(lidnum == 3){
			lid3open = !lid3open;
		}
		if(lidnum == 4){
			lid4open = !lid4open;
		}
	}

	public bool getlidopen(int num){
		if(num == 1 ){
			return lid1open;
		}
		if(num == 2 ){
			return lid2open;
		}
		if(num == 3 ){
			return lid3open;
		}
		if(num == 4 ){
			return lid4open;
		}
		return false;
	}
}

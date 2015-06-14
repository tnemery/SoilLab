using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	[HideInInspector]
	public int[] step1progress;
	[HideInInspector]
	public int[] step2progress;
	[HideInInspector]
	public int[] step3progress;
	[HideInInspector]
	public int[] step4progress;
	[HideInInspector]
	public int[] step5progress;
	[HideInInspector]
	public int curStep = 1;
	[HideInInspector]
	public string TSA1text = "";
	[HideInInspector]
	public string TSA2text = "";
	[HideInInspector]
	public string TSA3text = "";
	[HideInInspector]
	public string TSA4text = "";
	[HideInInspector]
	public string PDA1text = "";
	[HideInInspector]
	public string PDA2text = "";
	[HideInInspector]
	public string PDA3text = "";
	[HideInInspector]
	public string PDA4text = "";
	[HideInInspector]
	public int curpopup = -1;
	[HideInInspector]
	public float[] TSAnums;
	[HideInInspector]
	public float[] PDAnums;
	[HideInInspector]
	public bool GUIenabled = true;

	//skins
	public GUISkin videoGUI;
	public GUISkin calcGUI;
	public GUISkin finalpaper;
	public GUISkin popupbox;
	public GUISkin nextBtnS;
	public GUISkin skipBtnS;
	public GUISkin endMenu;
	//movie sources
	public MovieTexture movie1;
	public MovieTexture movie2;
	public MovieTexture movie3;
	public MovieTexture movie4;
	public MovieTexture movie5;
	public AudioSource aud1;
	public AudioSource aud2;
	public AudioSource aud3;
	public AudioSource aud4;
	public AudioSource aud5;
	//textures
	public Texture myTape;
	public Texture myPaper;

	//objects
	public GameObject bot1circ;
	public GameObject bot2circ;
	public GameObject bot3circ;
	public GameObject bot1;
	public GameObject bot2;
	public GameObject bot3;
	public GameObject aug1circy; //yellow circles TSA
	public GameObject aug2circy;
	public GameObject aug3circy;
	public GameObject aug4circy;
	public GameObject aug1circr; //green circles TSA
	public GameObject aug2circr;
	public GameObject aug3circr;
	public GameObject aug4circr;
	public GameObject aug1circy_2; //yellow circles PDA
	public GameObject aug2circy_2;
	public GameObject aug3circy_2;
	public GameObject aug4circy_2;
	public GameObject aug1circr_2; //green circles PDA
	public GameObject aug2circr_2;
	public GameObject aug3circr_2;
	public GameObject aug4circr_2;
	public GameObject aug1_1; //TSA augars
	public GameObject aug2_1;
	public GameObject aug3_1;
	public GameObject aug4_1;
	public GameObject aug1_2; //PDA augars
	public GameObject aug2_2;
	public GameObject aug3_2;
	public GameObject aug4_2;
	public GameObject TSA;		//TSA group
	public GameObject PDA;		//PDA group
	public GameObject aug1_1_mat; //TSA material objects
	public GameObject aug1_2_mat;
	public GameObject aug1_3_mat;
	public GameObject aug1_4_mat;
	public GameObject aug2_1_mat; //PDA material objects
	public GameObject aug2_2_mat;
	public GameObject aug2_3_mat;
	public GameObject aug2_4_mat;
	public GameObject water2; //water for second bottle
	//materials for augars
	public Material soil_drop;    
	public Material waterSpread;
	public Material slightlydirtywater; //material for second bottle
	public Material PipeHead;


	//GUI rectangles for positioning
	private Rect movieBox = new Rect(0, 0, Screen.width, Screen.height); //video 480 x 360
	private Rect btnBox = new Rect(Screen.width/1.3406172f, Screen.height/1.05678f, Screen.width/9.624f, Screen.height/21.7142857f);
	private Rect videoBoxwbtn = new Rect(Screen.width/1.3636172f, Screen.height/1.30138f,Screen.width/3.6571428f, Screen.height/4.0677966f);
	private Rect stepBox = new Rect(0,Screen.height/9.725f,Screen.width/2.8318584f ,Screen.height/12.413793103445f);
	private Rect skipBtn = new Rect(Screen.width/2.2636172f,Screen.height/1.07138f,Screen.width/8.533333333f,Screen.height/12f);
	private Rect resultsPaperbox = new Rect(Screen.width/1.2427184466f,Screen.height/14.4f,Screen.width/5.12f,Screen.height/1.44f);
	private float vidLength; //determines when a video is done playing to set the playing variable
	private bool playing = true;
	private bool stopVideo = false;
	//step descriptions
	private string step1 = "STEP 1: FIRST DILUTION";
	private string step2 = "STEP 2: FILL AGARS";
	private string step3 = "STEP 3: HOCKEY STICKS";
	private string step4 = "STEP 4: REPEAT STEPS";
	private string step5 = "STEP 5: CALCULATIONS";
	//reference scripts
	private fillpipette fillpipe;
	private fillIndicator fillIndicate;
	private repeatsteps repeat;
	private calcDelution getbac;
	//used for calculation displays
	private string TSAplatenum = "";
	private string PDAplatenum = "";
	private string TSAcolCount = "";
	private string PDAcolCount = "";
	private int PDAfinal;
	private int TSAfinal;
	private bool displayResults = false;
	//used for popups
	private bool doOnce = true;
	private string randpoptext;
	//screen resizing
	private int swidth;
	private int sheight;
	
	private compostSelect test;
	
	void Awake(){
		//test = GameObject.Find ("binData").GetComponent<compostSelect>();
		
		
		getbac = this.GetComponent<calcDelution>();
		repeat = GameObject.Find ("GameGUI").GetComponent<repeatsteps>();
		fillpipe = GameObject.Find("bottle1").GetComponent<fillpipette>();
		fillIndicate = GameObject.Find ("GameGUI").GetComponent<fillIndicator>();
		step1progress = new int[6];
		step2progress = new int[4];
		step3progress = new int[12];
		step4progress = new int[16];
		TSAnums = new float[4];
		PDAnums = new float[4];
		aud1.enabled = false;
		aud2.enabled = false;
		aud3.enabled = false;
		aud4.enabled = false;
		aud5.enabled = false;
		bot1circ.renderer.enabled = false;
		bot2circ.renderer.enabled = false;
		bot3circ.renderer.enabled = false;
		print (Screen.width+" "+Screen.height);
	}
	
	public void popup(int num){
		curpopup = num;
	}
	
	private string RandomText(){
		int rand = (int)Random.Range(0F, 5F);
		print ("rand "+rand);
		if(rand == 0) return "Well Done!";
		if(rand == 1) return "Good Job!";
		if(rand == 2) return "Fantastic!";
		if(rand == 3) return "Amazing!";
		return "Superb!";
	}
	
	IEnumerator killpopup(){
		yield return new WaitForSeconds(2);
		popup(-1);
	}
	
	void Update(){
		swidth = Screen.width;
		sheight = Screen.height;
		btnBox = new Rect(swidth/1.3406172f, sheight/1.05678f, swidth/9.624f, sheight/21.7142857f);
		videoBoxwbtn = new Rect(swidth/1.3636172f, sheight/1.30138f,swidth/3.6571428f, sheight/4.0677966f);
		stepBox = new Rect(0,sheight/9.725f,swidth/2.8318584f ,sheight/12.413793103445f);
		skipBtn = new Rect(swidth/2.2636172f,sheight/1.07138f,swidth/8.533333333f,sheight/12f);
		resultsPaperbox = new Rect(swidth/1.2427184466f,sheight/14.4f,swidth/5.12f,sheight/1.44f);
		
		if(playing == false){
			movieBox = new Rect(swidth/1.17356f, sheight/1.25556f, swidth/7.092967f, sheight/5.192857f);
		}else{
			movieBox = new Rect(swidth/8, 0, 960, 540); 
		}
		
	}
	
	void OnGUI(){
		GUI.skin = popupbox;
		popupbox.GetStyle("pop").fontSize = Mathf.CeilToInt(sheight/32.727272f);
		if(curpopup == 1){
			if(doOnce){
				randpoptext = RandomText ();
				doOnce = false;
			}
			GUI.Box (new Rect(swidth/2.37037037f,sheight/72f,swidth/6.4f,sheight/3.6f),randpoptext,popupbox.GetStyle("pop"));
			StartCoroutine (killpopup());
		}else if(curpopup == 0){
			//GUI.Box (new Rect(swidth/2-100,10,200,200),"Opps!");
		}else{
			doOnce = true;
		}
		GUI.skin = null;
		
		if(curStep == 1){
			aud1.enabled = true;
			if(playing == true){
				GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
				//GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("Video"));
				GUI.DrawTexture(movieBox,movie1);
				movie1.Play();
				vidLength = movie1.duration;
				GUI.skin = skipBtnS;
				if(GUI.Button(skipBtn,"")){
					stopVideo = true;
				}
				GUI.skin = null;
				if(movie1.isPlaying){
					StartCoroutine(waitforvid());
				}
			}
			
			
			
			if(playing == false){
				StopAllCoroutines();
				GUI.skin = videoGUI;
				GUI.Box (videoBoxwbtn,"");
				GUI.DrawTexture(movieBox,movie1);
				GUI.DrawTexture(stepBox, myTape);
				videoGUI.GetStyle("tape").fontSize = Mathf.CeilToInt(sheight/22.5f);
				GUI.TextArea(stepBox,step1,videoGUI.GetStyle("tape"));
				GUI.DrawTexture(new Rect(0,sheight/1.20334f,swidth/2.5858585858f,sheight/6.1016949f), myPaper);
				GUI.skin = calcGUI;
				calcGUI.GetStyle("dynfontsize").fontSize = Mathf.CeilToInt(sheight/60f);
				GUI.TextArea(new Rect(swidth/51f,sheight - 80,100,40),TSA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight - 63,100,40),TSA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight - 47,100,40),TSA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight - 30,100,40),TSA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight - 80,100,40),PDA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight - 63,100,40),PDA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight - 47,100,40),PDA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight - 30,100,40),PDA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.skin = videoGUI;
				if(GUI.Button(btnBox,"")){
					movie1.Play();
					movieBox = new Rect(0, 0, swidth, sheight);
					GUI.DrawTexture(movieBox,movie1);
					vidLength = movie1.duration;
					movie1.Play();
					playing = true;
				}
			}
		}else if(curStep == 2){
			aud1.enabled = false;
			aud2.enabled = true;
			if(playing == true){
				GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
				//GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("Video"));
				GUI.DrawTexture(movieBox,movie2);
				movie2.Play();
				vidLength = movie2.duration;
				GUI.skin = skipBtnS;
				if(GUI.Button(skipBtn,"")){
					stopVideo = true;
				}
				GUI.skin = null;
				if(movie2.isPlaying){
					StartCoroutine(waitforvid());
				}
			}
			
			
			
			if(playing == false){
				StopAllCoroutines();
				GUI.skin = videoGUI;
				GUI.Box (videoBoxwbtn,"");
				GUI.DrawTexture(movieBox,movie2);
				GUI.DrawTexture(stepBox, myTape);
				videoGUI.GetStyle("tape").fontSize = Mathf.CeilToInt(sheight/22.5f);
				GUI.TextArea(stepBox,step2,videoGUI.GetStyle("tape"));
				GUI.DrawTexture(new Rect(0,sheight/1.20334f,swidth/2.5858585858f,sheight/6.1016949f), myPaper);
				GUI.skin = calcGUI;
				calcGUI.GetStyle("dynfontsize").fontSize = Mathf.CeilToInt(sheight/60f);
				GUI.TextArea(new Rect(swidth/51f,sheight/1.12567f,swidth/12.8f,sheight/18f),TSA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.09567f,swidth/12.8f,sheight/18f),TSA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.06567f,swidth/12.8f,sheight/18f),TSA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.03567f,swidth/12.8f,sheight/18f),TSA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.12567f,swidth/12.8f,sheight/18f),PDA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.09567f,swidth/12.8f,sheight/18f),PDA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.06567f,swidth/12.8f,sheight/18f),PDA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.03567f,swidth/12.8f,sheight/18f),PDA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.skin = videoGUI;
				if(GUI.Button(btnBox,"")){
					movie2.Play();
					movieBox = new Rect(0, 0, swidth, sheight);
					GUI.DrawTexture(movieBox,movie2);
					vidLength = movie2.duration;
					movie2.Play();
					playing = true;
				}
			}
		}else if(curStep == 3){
			aud2.enabled = false;
			aud3.enabled = true;
			if(playing == true){
				GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
				//GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("Video"));
				GUI.DrawTexture(movieBox,movie3);
				//audio.Play();
				movie3.Play();
				vidLength = movie3.duration;
				GUI.skin = skipBtnS;
				if(GUI.Button(skipBtn,"")){
					stopVideo = true;
				}
				GUI.skin = null;
				if(movie3.isPlaying){
					StartCoroutine(waitforvid());
				}
			}
			
			
			
			if(playing == false){
				StopAllCoroutines();
				GUI.skin = videoGUI;
				GUI.Box (videoBoxwbtn,"");
				GUI.DrawTexture(movieBox,movie3);
				videoGUI.GetStyle("tape").fontSize = Mathf.CeilToInt(sheight/22.5f);
				GUI.DrawTexture(stepBox, myTape);
				GUI.TextArea(stepBox,step3,videoGUI.GetStyle("tape"));
				GUI.DrawTexture(new Rect(0,sheight/1.20334f,swidth/2.5858585858f,sheight/6.1016949f), myPaper);
				GUI.skin = calcGUI;
				calcGUI.GetStyle("dynfontsize").fontSize = Mathf.CeilToInt(sheight/60f);
				GUI.TextArea(new Rect(swidth/51f,sheight/1.12567f,swidth/12.8f,sheight/18f),TSA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.09567f,swidth/12.8f,sheight/18f),TSA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.06567f,swidth/12.8f,sheight/18f),TSA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.03567f,swidth/12.8f,sheight/18f),TSA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.12567f,swidth/12.8f,sheight/18f),PDA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.09567f,swidth/12.8f,sheight/18f),PDA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.06567f,swidth/12.8f,sheight/18f),PDA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.03567f,swidth/12.8f,sheight/18f),PDA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.skin = videoGUI;
				if(GUI.Button(btnBox,"")){
					movie3.Play();
					movieBox = new Rect(0, 0, swidth, sheight);
					GUI.DrawTexture(movieBox,movie3);
					vidLength = movie3.duration;
					movie3.Play();
					playing = true;
				}
			}
		}else if(curStep == 4){
			aud3.enabled = false;
			aud4.enabled = true;
			if(playing == true){
				GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
				//GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("Video"));
				GUI.DrawTexture(movieBox,movie4);
				//audio.Play();
				movie4.Play();
				vidLength = movie4.duration;
				GUI.skin = skipBtnS;
				if(GUI.Button(skipBtn,"")){
					stopVideo = true;
				}
				GUI.skin = null;
				if(movie4.isPlaying){
					StartCoroutine(waitforvid());
				}
			}
			
			
			
			if(playing == false){
				StopAllCoroutines();
				GUI.skin = videoGUI;
				GUI.Box (videoBoxwbtn,"");
				GUI.DrawTexture(movieBox,movie4);
				videoGUI.GetStyle("tape").fontSize = Mathf.CeilToInt(sheight/22.5f);
				GUI.DrawTexture(stepBox, myTape);
				GUI.TextArea(stepBox,step4,videoGUI.GetStyle("tape"));
				GUI.DrawTexture(new Rect(0,sheight/1.20334f,swidth/2.5858585858f,sheight/6.1016949f), myPaper);
				GUI.skin = calcGUI;
				calcGUI.GetStyle("dynfontsize").fontSize = Mathf.CeilToInt(sheight/60f);
				GUI.TextArea(new Rect(swidth/51f,sheight/1.12567f,swidth/12.8f,sheight/18f),TSA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.09567f,swidth/12.8f,sheight/18f),TSA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.06567f,swidth/12.8f,sheight/18f),TSA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.03567f,swidth/12.8f,sheight/18f),TSA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.12567f,swidth/12.8f,sheight/18f),PDA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.09567f,swidth/12.8f,sheight/18f),PDA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.06567f,swidth/12.8f,sheight/18f),PDA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.03567f,swidth/12.8f,sheight/18f),PDA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.skin = videoGUI;
				if(GUI.Button(btnBox,"")){
					movie4.Play();
					movieBox = new Rect(0, 0, swidth, sheight);
					GUI.DrawTexture(movieBox,movie4);
					vidLength = movie4.duration;
					movie4.Play();
					playing = true;
				}
			}
		}else if(curStep == 5){
			//getbac.setfinalMats(aug1_1.transform.Find("Agar_mat").gameObject,1,TSAnums[0]);
			//getbac.setfinalMats(aug2_1.transform.Find("Agar_mat").gameObject,1,TSAnums[1]);
			//getbac.setfinalMats(aug3_1.transform.Find("Agar_mat").gameObject,1,TSAnums[2]);
			//getbac.setfinalMats(aug4_1.transform.Find("Agar_mat").gameObject,1,TSAnums[3]);
			//getbac.setfinalMats(aug1_2.transform.Find("Agar_mat").gameObject,2,PDAnums[0]);
			//getbac.setfinalMats(aug2_2.transform.Find("Agar_mat").gameObject,2,PDAnums[1]);
			//getbac.setfinalMats(aug3_2.transform.Find("Agar_mat").gameObject,2,PDAnums[2]);
			//getbac.setfinalMats(aug4_2.transform.Find("Agar_mat").gameObject,2,PDAnums[3]);
			
			aud4.enabled = false;
			aud5.enabled = true;
			if(playing == true){
				GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
				//GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("Video"));
				GUI.DrawTexture(movieBox,movie5);
				//audio.Play();
				movie5.Play();
				vidLength = movie5.duration;
				GUI.skin = skipBtnS;
				if(GUI.Button(skipBtn,"")){
					stopVideo = true;
				}
				GUI.skin = null;
				if(movie5.isPlaying){
					StartCoroutine(waitforvid());
				}
			}
			
			
			
			if(playing == false && GUIenabled == true){
				StopAllCoroutines();
				GUI.skin = videoGUI;
				GUI.Box (videoBoxwbtn,"");
				GUI.DrawTexture(movieBox,movie5);
				videoGUI.GetStyle("tape").fontSize = Mathf.CeilToInt(sheight/22.5f);
				GUI.DrawTexture(stepBox, myTape);
				GUI.TextArea(stepBox,step5,videoGUI.GetStyle("tape"));
				GUI.DrawTexture(new Rect(0,sheight/1.20334f,swidth/2.5858585858f,sheight/6.1016949f), myPaper);
				GUI.skin = calcGUI;
				calcGUI.GetStyle("dynfontsize").fontSize = Mathf.CeilToInt(sheight/60f);
				GUI.TextArea(new Rect(swidth/51f,sheight/1.12567f,swidth/12.8f,sheight/18f),TSA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.09567f,swidth/12.8f,sheight/18f),TSA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.06567f,swidth/12.8f,sheight/18f),TSA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/51f,sheight/1.03567f,swidth/12.8f,sheight/18f),TSA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.12567f,swidth/12.8f,sheight/18f),PDA1text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.09567f,swidth/12.8f,sheight/18f),PDA2text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.06567f,swidth/12.8f,sheight/18f),PDA3text,calcGUI.GetStyle("dynfontsize"));
				GUI.TextArea(new Rect(swidth/4.3389f,sheight/1.03567f,swidth/12.8f,sheight/18f),PDA4text,calcGUI.GetStyle("dynfontsize"));
				GUI.skin = finalpaper;
				GUI.BeginGroup(resultsPaperbox);
				GUI.Box (new Rect(0,0,swidth/5.12f,sheight/1.44f),"");
				TSAplatenum = GUI.TextField(new Rect(swidth/9.8461538f,sheight/4.5283f,swidth/12.8f,sheight/20.5714f),TSAplatenum);
				TSAcolCount = GUI.TextField(new Rect(swidth/8.2580645f,sheight/3.644646f,swidth/14.22222f,sheight/20.5714f),TSAcolCount);
				PDAplatenum = GUI.TextField(new Rect(swidth/9.8461538f,sheight/2.330097f,swidth/12.8f,sheight/20.5714f),PDAplatenum);
				PDAcolCount = GUI.TextField(new Rect(swidth/8.2580645f,sheight/2.0689655f,swidth/14.22222f,sheight/20.5714f),PDAcolCount);
				if (GUI.Button (new Rect (swidth/17.0666667f,sheight/1.568627f,swidth/12.8f,sheight/18f), "")) { // this is the submit button
					//go to end splash screen
					TSAfinal = Mathf.CeilToInt(getbac.finalcalc(TSAnums[int.Parse (TSAplatenum)-1],int.Parse (TSAcolCount)));
					PDAfinal = Mathf.CeilToInt(getbac.finalcalc(PDAnums[int.Parse (PDAplatenum)-1],int.Parse (PDAcolCount)));
					print ("TSA "+TSAfinal+" PDA "+PDAfinal);
					displayResults = true;
				}
				GUI.EndGroup();
				GUI.skin = videoGUI;
				if(GUI.Button(btnBox,"")){
					movie5.Play();
					movieBox = new Rect(0, 0, swidth, sheight);
					GUI.DrawTexture(movieBox,movie5);
					vidLength = movie5.duration;
					movie5.Play();
					playing = true;
				}
				GUI.skin = endMenu;
				if(displayResults){
					GUI.Box (new Rect(0,0,swidth,sheight),"");
					endMenu.GetStyle("invisbox").fontSize = Mathf.CeilToInt(sheight/17.142857f);
					//GUI.Box(new Rect(swidth/2-100,0,200,80),"<size=36>End Results</size>"); //title
					//GUI.Box(new Rect(swidth/2-300,81,200,50),"TSA"); //TSA
					GUI.Box(new Rect(swidth/3.20f,sheight/2.23f,swidth/25.6f,sheight/14.4f),TSAplatenum,endMenu.GetStyle("invisbox")); //TSA plate
					GUI.Box(new Rect(swidth/3.20f,sheight/1.70f,swidth/25.6f,sheight/14.4f),TSAcolCount,endMenu.GetStyle("invisbox")); //TSA count
					GUI.Box(new Rect(swidth/4.20f,sheight/1.28f,swidth/25.6f,sheight/14.4f),TSAfinal.ToString(),endMenu.GetStyle("invisbox")); //TSA Result
					//GUI.Box(new Rect(swidth/2+100,81,200,50),"PDA"); //PDA
					GUI.Box(new Rect(swidth/1.34f,sheight/2.23f,swidth/25.6f,sheight/14.4f),PDAplatenum,endMenu.GetStyle("invisbox")); //PDA plate
					GUI.Box(new Rect(swidth/1.34f,sheight/1.70f,swidth/25.6f,sheight/14.4f),PDAcolCount,endMenu.GetStyle("invisbox")); //PDA count
					GUI.Box(new Rect(swidth/1.52f,sheight/1.28f,swidth/25.6f,sheight/14.4f),PDAfinal.ToString(),endMenu.GetStyle("invisbox")); //PDA result
					if(GUI.Button (new Rect(swidth/2.16949f,sheight/1.09256f,swidth/12.8f,sheight/12f),"",endMenu.GetStyle("restart"))){
						fillpipe.reset();
						Application.LoadLevel("Main");
					}
				}
			}
		}
		
		if(playing == false){
			GUI.skin = nextBtnS;
			if(curStep != 5){
				if(GUI.Button(skipBtn,"")){ //check for next step
					if(curStep == 1 && repeat.checksteps()){
						curStep = 2;
						playing = true;
						bot2circ.renderer.enabled = true;
						bot3circ.renderer.enabled = true;
						fillpipe.changeStep(2);
						movieBox = new Rect(0, 0, swidth, sheight);
					}else if(curStep == 2 && repeat.checksteps()){
						curStep = 3;
						playing = true;
						bot1circ.renderer.enabled = false;
						bot2circ.renderer.enabled = false;
						bot3circ.renderer.enabled = false;
						fillpipe.changeStep(3);
						movieBox = new Rect(0, 0, swidth, sheight);
					}else if(curStep == 3 && repeat.checksteps()){
						curStep = 4;
						playing = true;
						GameObject.Find ("pipette").transform.FindChild("pipeHead").renderer.material = PipeHead;
						GameObject.Find ("pipette_2").transform.FindChild("pipeHead").renderer.material = PipeHead;
						GameObject.Find("Bag_pipettes1").SetActive(false);
						GameObject.Find("Bag_pipettes2").SetActive(false);
						bot1circ.renderer.enabled = true;
						bot2circ.renderer.enabled = true;
						bot3circ.renderer.enabled = false;
						aug1_2.transform.position = aug1_1.transform.position;
						aug2_2.transform.position = aug2_1.transform.position;
						aug3_2.transform.position = aug3_1.transform.position;
						aug4_2.transform.position = aug4_1.transform.position;
						TSA.SetActive(false);
						fillpipe.changeStep(4);
						movieBox = new Rect(0, 0, swidth, sheight);
					}else if(curStep == 4 && repeat.checksteps()){
						curStep = 5;
						playing = true;
						bot1.SetActive(false);
						bot2.SetActive(false);
						bot3.SetActive(false);
						getbac.setfinalMats(aug1_1.transform.Find("Agar_mat").gameObject,1,TSAnums[0]);
						getbac.setfinalMats(aug2_1.transform.Find("Agar_mat").gameObject,1,TSAnums[1]);
						getbac.setfinalMats(aug3_1.transform.Find("Agar_mat").gameObject,1,TSAnums[2]);
						getbac.setfinalMats(aug4_1.transform.Find("Agar_mat").gameObject,1,TSAnums[3]);
						getbac.setfinalMats(aug1_2.transform.Find("Agar_mat").gameObject,2,PDAnums[0]);
						getbac.setfinalMats(aug2_2.transform.Find("Agar_mat").gameObject,2,PDAnums[1]);
						getbac.setfinalMats(aug3_2.transform.Find("Agar_mat").gameObject,2,PDAnums[2]);
						getbac.setfinalMats(aug4_2.transform.Find("Agar_mat").gameObject,2,PDAnums[3]);
						GameObject.Find ("pipette").SetActive(false);
						GameObject.Find ("pipette_2").SetActive(false);
						GameObject.Find ("pipeCollider").SetActive(false);
						GameObject.Find ("beaker").SetActive(false);
						GameObject.Find ("hockeystick").SetActive(false);
						GameObject.Find ("alch_burner").SetActive(false);
						GameObject.Find ("measure_Pop").SetActive(false);
						GameObject.Find ("hockeystickdummy1").SetActive(false);
						GameObject.Find ("hockeystickdummy2").SetActive(false);
						GameObject.Find ("hockeystickdummy3").SetActive(false);
						GameObject.Find ("pipetteBag").SetActive(false);
						fillIndicate.turnoff();
						TSA.SetActive (true);
						PDA.SetActive(true);
						PDA.transform.localPosition = new Vector3(39f,0,0);
						fillpipe.changeStep(5);
						bot1circ.renderer.enabled = false;
						bot2circ.renderer.enabled = false;
						bot3circ.renderer.enabled = false;
						movieBox = new Rect(0, 0, swidth, sheight);
					}
				}
			}
		}
		
	}
	//recieve number to update
	public void updatenumbers(int augnum, float value){
		print ("curstep: "+curStep);
		if(curStep == 2 && augnum == 1){
			TSAnums[0] = value;
			TSA1text = convertNumberToDisplay(value);
		}
		if(curStep == 2 && augnum == 2){
			TSAnums[1] = value;
			TSA2text = convertNumberToDisplay(value);
		}
		if(curStep == 2 && augnum == 3){
			TSAnums[2] = value;
			TSA3text = convertNumberToDisplay(value);
		}
		if(curStep == 2 && augnum == 4){
			TSAnums[3] = value;
			TSA4text = convertNumberToDisplay(value);
		}
		if(curStep == 4 && augnum == 1){
			PDAnums[0] = value;
			PDA1text = convertNumberToDisplay(value);
		}
		if(curStep == 4 && augnum == 2){
			PDAnums[1] = value;
			PDA2text = convertNumberToDisplay(value);
		}
		if(curStep == 4 && augnum == 3){
			PDAnums[2] = value;
			PDA3text = convertNumberToDisplay(value);
		}
		if(curStep == 4 && augnum == 4){
			PDAnums[3] = value;
			PDA4text = convertNumberToDisplay(value);
		}
	}
	
	private string convertNumberToDisplay(float val){
		int modnum = 10;
		print("before " +modnum);
		if(val == 1f){
			return  ("1");
		}else{
			while(((float)(val*modnum)/1f) != 1f){
				modnum *= 10;
			}
			print ("after " +modnum);
		}
		return  ("1/"+modnum.ToString());
	}
	
	IEnumerator waitforvid(){
		if(stopVideo){
			yield return new WaitForSeconds(0);
		}else
			yield return new WaitForSeconds(vidLength);
		playing = false;
		stopVideo = false;
		movie1.Stop();
		movie2.Stop();
		movie3.Stop();
		movie4.Stop();
		movie5.Stop();
		movieBox = new Rect(swidth/1.17356f, sheight/1.25556f, swidth/7.092967f, sheight/5.192857f);
	}
}


using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin menu;
	public GUISkin videoGUI;
	public MovieTexture movie1;
	public AudioSource aud1;
	private float vidLength;
	public GUISkin skipBtnS;
	private bool stopVideo = false;
	private bool playing = false;
	private Rect skipBtn = new Rect(Screen.width/2.2636172f,Screen.height/1.07138f,Screen.width/8.533333333f,Screen.height/12f);
	private Rect movieBox = new Rect(Screen.width/8, 30, 960, 540); //video 480 x 270
	private float progress = 0f;
	private Vector2 pos = new Vector2(Screen.width/2.1f,Screen.height/1.2f);
	private Vector2 size = new Vector2(200,20);
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;
	private AsyncOperation async;

	private bool loading = false;

	void Awake(){
		aud1.enabled = false;
	}


	void OnGUI(){
		GUI.skin = menu;

		if(playing){
			aud1.enabled = true;
			GUI.Box (new Rect(0,0,Screen.width,Screen.height),"",videoGUI.GetStyle("blackBox"));
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
		}else{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if(loading == false){
				if(GUI.Button (new Rect(Screen.width/2.4288425f,Screen.height/2.26415f,Screen.width/5.6637f,Screen.height/7.65957f),"",menu.GetStyle("start"))){
					Application.LoadLevelAsync("Bins");
				}
				GUI.color = Color.black;
				GUI.Label(new Rect(Screen.width/2.3f,Screen.height/1.414285f,150,75),"Click the Demo Button to see how to play!",menu.GetStyle("label"));
				GUI.color = Color.white;
				if(GUI.Button (new Rect(Screen.width/2.4288425f,Screen.height/1.714285f,Screen.width/5.6637f,Screen.height/7.65957f),"",menu.GetStyle("demo"))){
					playing = true;
				}
			}
		}

	}

	IEnumerator waitforvid(){
		if(stopVideo){
			yield return new WaitForSeconds(0);
		}else
			yield return new WaitForSeconds(vidLength);
		playing = false;
		stopVideo = false;
		movie1.Stop();
	}
}

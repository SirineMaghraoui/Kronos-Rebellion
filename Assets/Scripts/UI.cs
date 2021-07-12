using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour {
	public static string language="english";
	public int height;
	public int width;
	public string quality;


	public  int menu ;
	public static string current;
	bool disactivate;
	public GameObject mainMenu;
	public GameObject playMenu;
	public GameObject pauseMenu;
	public GameObject quitMenu;
	public GameObject optionsMenu;

	public GameObject arLang;
	public GameObject frLang;
	public GameObject enLang;

	public GameObject firstOptionLang;
	public GameObject secOptionLang;
	public GameObject thirdOptionLang;

	public GameObject rightBlueArrowLang;
	public GameObject rightGreyArrowLang;

	public GameObject leftBlueArrowLang;
	public GameObject leftGreyArrowLang;

	public GameObject res1024_768;
	public GameObject res1280_768;
	public GameObject res1366_768;

	public GameObject firstOptionRes;
	public GameObject secOptionRes;
	public GameObject thirdOptionRes;

	public GameObject rightBlueArrowRes;
	public GameObject rightGreyArrowRes;

	public GameObject leftBlueArrowRes;
	public GameObject leftGreyArrowRes;

	public GameObject low;
	public GameObject medium;
	public GameObject high;

	public GameObject faible;
	public GameObject moyenne;
	public GameObject haute;

	public GameObject dha3ifa;
	public GameObject motawasita;
	public GameObject mortafi3a;

	public GameObject firstOptionGraph;
	public GameObject secOptionGraph;
	public GameObject thirdOptionGraph;

	public GameObject rightBlueArrowGraph;
	public GameObject rightGreyArrowGraph;

	public GameObject leftBlueArrowGraph;
	public GameObject leftGreyArrowGraph;

	Animator anim_main;
	Animator anim_pause;
	Animator anim_play;
	Animator anim_options;
	Animator anim_quit;
	string l;
	int w;
	string g;


	void Start(){
		l = language;
		w = width;
		g = quality;
		// load language
		//load resolution
		//load quality
		presets();	
		anim_main = mainMenu.GetComponent<Animator> ();
		anim_play = playMenu.GetComponent<Animator> ();
		anim_options = optionsMenu.GetComponent<Animator> ();
		anim_pause = pauseMenu.GetComponent<Animator> ();
		anim_quit = quitMenu.GetComponent<Animator> ();
		if (menu == 1) {
			mainMenu.SetActive (true);
			current="main";
			anim_main.SetInteger ("ok",1);

		} else if (menu == 2) {
			pauseMenu.SetActive (true);
			current="pause";
			anim_pause.SetInteger ("ok",1);
		}
	}

	void FixedUpdate(){
		//main
		if (anim_main.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="play") {
			mainMenu.SetActive (false);
		}
		if (anim_main.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="options") {
			mainMenu.SetActive (false);
		}
		if (anim_main.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="quit") {
			mainMenu.SetActive (false);
		}

		if (anim_main.GetCurrentAnimatorStateInfo (0).IsName ("main_fade_in") && disactivate==true) {
			playMenu.SetActive (false);
			optionsMenu.SetActive (false);
			quitMenu.SetActive (false);
			disactivate = false;
		}


		//pause

		if (anim_pause.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="main") {
			pauseMenu.SetActive (false);
		}

		if (anim_pause.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="options") {
			pauseMenu.SetActive (false);
		}

		if (anim_pause.GetCurrentAnimatorStateInfo (0).IsName ("empty") && current=="quit") {
			pauseMenu.SetActive (false);
		}

		if (anim_pause.GetCurrentAnimatorStateInfo (0).IsName ("pause_fade_in") && disactivate==true) {
			optionsMenu.SetActive (false);
			quitMenu.SetActive (false);
			disactivate = false;
		}

		//play
		if(anim_play.GetCurrentAnimatorStateInfo(0).IsName("empty")&& current=="NG"){
			// START NEW GAME
		}

		if(anim_play.GetCurrentAnimatorStateInfo(0).IsName("empty")&& current=="CG"){
			// LOAD GAME
		}

	}
	// main	
	public void play(){
		anim_main.SetInteger ("ok",-1);
		current="play";
		playMenu.SetActive (true);
		anim_play.SetInteger("ok",1);
	}

	public void optionsFromMain(){
		anim_main.SetInteger ("ok",-1);
		current = "options";
		optionsMenu.SetActive (true);
		anim_options.SetInteger("ok",1);

	}

	public void quitFromMain(){	
		anim_main.SetInteger ("ok",-1);	
		current = "quit";
		quitMenu.SetActive (true);
		anim_quit.SetInteger("ok",1);
	}

	//pause
	public void resume(){
		anim_pause.SetInteger ("ok",-1);
		current="RG";
	}

	public void optionsFromPause(){
		anim_pause.SetInteger ("ok",-1);
		current = "options";
		optionsMenu.SetActive (true);
		anim_options.SetInteger("ok",1);
	} 
	public void toMainMenu(){
		anim_pause.SetInteger ("ok",-1);
		menu = 1;
		current = "main";
		mainMenu.SetActive (true);
		anim_main.SetInteger("ok",1);
	}

	public void quitFromPause(){
		anim_pause.SetInteger ("ok",-1);
		current = "quit";
		quitMenu.SetActive (true);
		anim_quit.SetInteger("ok",1);
	}
	//play
	public  void newGame(){
		menu = 0;
		anim_play.SetInteger ("ok",-1);
		current = "NG";
	}

	public  void continueGame(){
		menu = 0;
		anim_play.SetInteger ("ok",-1);
		current = "CG";
	}
	public  void apply(){
		//save lang+qual+son+res
	}
	public void back(){
		if (menu == 1) {
			if (current == "play") {
				anim_play.SetInteger ("ok", -1);
				current = "main";
				mainMenu.SetActive (true);
				anim_main.SetInteger ("ok", 1);
			} else if (current == "options") {
				anim_options.SetInteger ("ok", -1);
				current = "main";
				mainMenu.SetActive (true);
				anim_main.SetInteger ("ok", 1);
			}
		} else if (menu == 2) {
			anim_options.SetInteger ("ok",-1);
			current = "pause";
			pauseMenu.SetActive (true);
			anim_pause.SetInteger("ok",1);
		}
		disactivate = true;
	}



	public  void yes(){
		Application.Quit ();
	}

	public  void no(){
		if (menu == 1) {
			anim_quit.SetInteger ("ok",-1);
			current = "main";
			mainMenu.SetActive (true);
			anim_main.SetInteger("ok",1);
		} else if (menu == 2) {
			anim_quit.SetInteger ("ok",-1);
			current = "pause";
			pauseMenu.SetActive (true);
			anim_pause.SetInteger("ok",1);
		}
		disactivate =true;
	}
		
	void presets (){
		// language
		if (language == "english") {
			enLang.SetActive (true);
			firstOptionLang.SetActive (true);
			leftGreyArrowLang.SetActive (true);
			rightBlueArrowLang.SetActive (true);
		} else if (language == "francais") {
			frLang.SetActive (true);
			secOptionLang.SetActive (true);
			leftBlueArrowLang.SetActive (true);
			rightBlueArrowLang.SetActive (true);
		} else {
			arLang.SetActive (true);
			thirdOptionLang.SetActive (true);
			leftBlueArrowLang.SetActive (true);
			rightGreyArrowLang.SetActive (true);
		}

		//resolution
		if (width == 1024) {
			res1024_768.SetActive (true);
			firstOptionRes.SetActive (true);
			leftGreyArrowRes.SetActive (true);
			rightBlueArrowRes.SetActive (true);
		} else if (width == 1280) {
			res1280_768.SetActive (true);
			secOptionRes.SetActive (true);
			leftBlueArrowRes.SetActive (true);
			rightBlueArrowRes.SetActive (true);
		} else {
			res1366_768.SetActive (true);
			thirdOptionRes.SetActive (true);
			leftBlueArrowRes.SetActive (true);
			rightGreyArrowRes.SetActive (true);
		}

		//quality
		if (quality == "low") {
			if (language == "english") {
				low.SetActive (true);
			} else if (language == "francais") {
				faible.SetActive (true);
			} else {
				dha3ifa.SetActive (true);
			}
			firstOptionGraph.SetActive (true);
			leftGreyArrowGraph.SetActive (true);
			rightBlueArrowGraph.SetActive (true);

		} else if (quality == "medium") {
			if (language == "english") {
				medium.SetActive (true);
			} else if (language == "francais") {
				moyenne.SetActive (true);
			} else {
				motawasita.SetActive (true);
			}

			secOptionGraph.SetActive (true);
			leftBlueArrowGraph.SetActive (true);
			rightBlueArrowGraph.SetActive (true);

		} else {
			if (language == "english") {
				high.SetActive (true);
			} else if (language == "francais") {
				haute.SetActive (true);
			} else {
				mortafi3a.SetActive (true);	
			}

			thirdOptionGraph.SetActive (true);
			leftBlueArrowGraph.SetActive (true);
			rightGreyArrowGraph.SetActive (true);
		}

	}



	public void manageLangRight(){
		if (l == "english") {
			l="francais";
			enLang.SetActive (false);
			frLang.SetActive (true);
			firstOptionLang.SetActive (false);
			secOptionLang.SetActive (true);
			leftBlueArrowLang.SetActive (true);
			leftGreyArrowLang.SetActive (false);
		} else if (l == "francais") {
			l="arabic";
			frLang.SetActive (false);
			arLang.SetActive (true);
			secOptionLang.SetActive (false);
			thirdOptionLang.SetActive (true);
			rightBlueArrowLang.SetActive (false);
			rightGreyArrowLang.SetActive (true);
		}
	}

	public void manageLangLeft(){
		if (l == "arabic") {
			l="francais";
			arLang.SetActive (false);
			frLang.SetActive (true);
			thirdOptionLang.SetActive (false);
			secOptionLang.SetActive (true);
			rightGreyArrowLang.SetActive (false);
			rightBlueArrowLang.SetActive (true);
		} else if (l == "francais") {
			l="english";
			frLang.SetActive (false);
			enLang.SetActive (true);
			secOptionLang.SetActive (false);
			firstOptionLang.SetActive (true);
			leftBlueArrowLang.SetActive (false);
			leftGreyArrowLang.SetActive (true);
		}
	}

	public void manageResRight(){
		if (w == 1024) {
			w=1280;
			res1024_768.SetActive (false);
			res1280_768.SetActive (true);
			firstOptionRes.SetActive (false);
			secOptionRes.SetActive (true);
			leftBlueArrowRes.SetActive (true);
			leftGreyArrowRes.SetActive (false);
		} else if (w == 1280) {
			w=1366;
			res1280_768.SetActive (false);
			res1366_768.SetActive (true);
			secOptionRes.SetActive (false);
			thirdOptionRes.SetActive (true);
			rightBlueArrowRes.SetActive (false);
			rightGreyArrowRes.SetActive (true);
		}
	}

	public void manageResLeft(){
		if (w == 1366) {
			w=1280;
			res1366_768.SetActive (false);
			res1280_768.SetActive (true);
			thirdOptionRes.SetActive (false);
			secOptionRes.SetActive (true);
			rightGreyArrowRes.SetActive (false);
			rightBlueArrowRes.SetActive (true);
		} else if (w == 1280) {
			w=1024;
			res1280_768.SetActive (false);
			res1024_768.SetActive (true);
			secOptionRes.SetActive (false);
			firstOptionRes.SetActive (true);
			leftBlueArrowRes.SetActive (false);
			leftGreyArrowRes.SetActive (true);
		}
	}

	public void manageQualRight(){
		if (g == "low") {
			g = "medium";

			if (language == "english") {
				low.SetActive (false);
				medium.SetActive (true);
			} else if (language == "francais") {
				faible.SetActive (false);
				moyenne.SetActive (true);
			} else {
				dha3ifa.SetActive (false);
				motawasita.SetActive (true);
			}

			firstOptionGraph.SetActive (false);
			secOptionGraph.SetActive (true);
			leftBlueArrowGraph.SetActive (true);
			leftGreyArrowGraph.SetActive (false);
		} else if (g == "medium") {
			g="high";

			if (language == "english") {
				medium.SetActive (false);
				high.SetActive (true);
			} else if (language == "francais") {
				moyenne.SetActive (false);
				haute.SetActive (true);
			} else {
				motawasita.SetActive (false);
				mortafi3a.SetActive (true);
			}

			secOptionGraph.SetActive (false);
			thirdOptionGraph.SetActive (true);
			rightBlueArrowGraph.SetActive (false);
			rightGreyArrowGraph.SetActive (true);
		}
	}

	public void manageQualLeft(){
		if (g == "high") {
			g="medium";

			if (language == "english") {
				high.SetActive (false);
				medium.SetActive (true);
			} else if (language == "francais") {
				haute.SetActive (false);
				moyenne.SetActive (true);
			} else {
				mortafi3a.SetActive (false);
				motawasita.SetActive (true);
			}

			thirdOptionGraph.SetActive (false);
			secOptionGraph.SetActive (true);
			rightGreyArrowGraph.SetActive (false);
			rightBlueArrowGraph.SetActive (true);
		} else if (g == "medium") {
			g="low";

			if (language == "english") {
				medium.SetActive (false);
				low.SetActive (true);
			} else if (language == "francais") {
				moyenne.SetActive (false);
				faible.SetActive (true);
			} else {
				motawasita.SetActive (false);
				dha3ifa.SetActive (true);
			}

			secOptionGraph.SetActive (false);
			firstOptionGraph.SetActive (true);
			leftBlueArrowGraph.SetActive (false);
			leftGreyArrowGraph.SetActive (true);
		}
	}

}

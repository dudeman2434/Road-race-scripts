using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Death : MonoBehaviour {
	public string main_menu_level;
	// Use this for initialization
	public void Restart_game() {
		FindObjectOfType<Game_manager>().Reset();
	}
	public void Quit_to_main(){
		if(Advertisement.IsReady()){
			Advertisement.Show();
		}
		Application.LoadLevel(main_menu_level);
		
		
	}
}

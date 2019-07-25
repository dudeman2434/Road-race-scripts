using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	public string main_menu_level;
	public GameObject pause_menu;
	public GameObject[] buttons;
	public void Pause_game(){
		Time.timeScale=0f;
		pause_menu.SetActive(true);
		for(int x=0;x<buttons.Length;x++){
			buttons[x].SetActive(false);
		}
		
	}
	public void Resume_game(){
		Time.timeScale=1f;
		pause_menu.SetActive(false);
		for(int x=0;x<buttons.Length;x++){
			buttons[x].SetActive(true);
		}
	}
	public void Restart_game() {
		Time.timeScale=1f;
		pause_menu.SetActive(false);
		for(int x=0;x<buttons.Length;x++){
			buttons[x].SetActive(false);
		}
		FindObjectOfType<Game_manager>().Reset();
	}
	public void Quit_to_main(){
		Time.timeScale=1f;
		Application.LoadLevel(main_menu_level);
	}
}
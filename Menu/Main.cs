using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public string play_game_level;
	public string about_game;

	public void Play_game(){
		Application.LoadLevel(play_game_level);
	}
	public void About_game(){
		Application.LoadLevel(about_game);
	}
	public void Quit_game(){
		Application.Quit();
	}
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_manager : MonoBehaviour {
	public Transform Platform_generator;
	private Vector3 platform_start_point;
	public Player_movement the_player;
	private Vector3 player_start_point;
	private Platform_destroyer[] platform_list;
	private Score_manager the_score_manager;
	public Death the_death_screen;
	public GameObject[] buttons;
	// Use this for initialization
	void Start () {
		platform_start_point=Platform_generator.position;
		player_start_point=the_player.transform.position;
		the_score_manager=FindObjectOfType<Score_manager>();
		the_score_manager.score_increasing=true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart_Game(){
		the_score_manager.score_increasing=false;
		the_player.gameObject.SetActive(false);
		the_death_screen.gameObject.SetActive(true);
		for(int x=0;x<buttons.Length;x++){
			buttons[x].SetActive(false);
		}
		//StartCoroutine("RestartGameCo");
	}

	public void Reset(){
		the_death_screen.gameObject.SetActive(false);
		platform_list=FindObjectsOfType<Platform_destroyer>();
		for(int i=0;i<platform_list.Length;i++){
			platform_list[i].gameObject.SetActive(true);
		}
		the_player.transform.position=player_start_point;

		Platform_generator.position=platform_start_point;
		the_player.gameObject.SetActive(true);
		the_score_manager.score_count=0;
		the_score_manager.score_increasing=true;
		for(int x=0;x<buttons.Length;x++){
			buttons[x].SetActive(true);
		}
	}
	/* public IEnumerator RestartGameCo(){
		the_score_manager.score_increasing=false;
		the_player.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		platform_list=FindObjectsOfType<Platform_destroyer>();
		for(int i=0;i<platform_list.Length;i++){
			platform_list[i].gameObject.SetActive(true);
		}
		the_player.transform.position=player_start_point;

		Platform_generator.position=platform_start_point;
		the_player.gameObject.SetActive(true);
		the_score_manager.score_count=0;
		the_score_manager.score_increasing=true;
	}*/
}

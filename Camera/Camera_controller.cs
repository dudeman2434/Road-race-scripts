using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {
	public Player_movement the_player;
	private Vector3 player_pos;
	private Vector3 last_player_pos;
	private float distance_to_move;
	// Use this for initialization
	void Start () {
		the_player=FindObjectOfType<Player_movement>();
		last_player_pos=the_player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance_to_move=the_player.transform.position.y-last_player_pos.y;
		transform.position=new Vector3(transform.position.x,transform.position.y+distance_to_move,transform.position.z);
		last_player_pos=the_player.transform.position;
	}
}

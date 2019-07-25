using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Player_side_moves : MonoBehaviour {
	[SerializeField]Transform player;
	[SerializeField]Direction dir;
	
	void OnMouseDown(){
		Vector3 pos=player.position;
		switch(dir){
			case Direction.UP:
				pos+=Vector3.up;
				break;
			case Direction.DOWN:
				pos+=Vector3.down;
				break;
		}
	}
	

	public enum Direction{
		UP,
		DOWN
	}
}

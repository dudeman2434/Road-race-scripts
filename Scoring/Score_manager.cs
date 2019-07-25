using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_manager : MonoBehaviour {
	public Text scoreText;
	public Text high_score_text;
	public float score_count;
	public float high_score_count;
	public float points_per_sec;
	public bool score_increasing;
	public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {

		if(PlayerPrefs.HasKey("High Score")){
			high_score_count=PlayerPrefs.GetFloat("High Score");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(score_increasing){
			score_count+=points_per_sec+(rigidbody.position.y)/2;
		}
		if(score_count>high_score_count){
			high_score_count=score_count;
			PlayerPrefs.SetFloat("High Score: ",high_score_count);
		}
		scoreText.text="Score: " + Mathf.Round(score_count);
		high_score_text.text="High Score: "+ high_score_count;
	}
	public void Add_Score(int  point_to_add){
		score_count+=point_to_add;
	}
}

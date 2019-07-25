using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_points : MonoBehaviour {
	public int score_to_give;
	private Score_manager the_score_manager;
	private AudioSource cash_sound;

	// Use this for initialization
	void Start () {
		the_score_manager=FindObjectOfType<Score_manager>();
		cash_sound=GameObject.Find("Cash_sound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.name=="Player"){
			the_score_manager.Add_Score(score_to_give);
			gameObject.SetActive(false);
			if(cash_sound.isPlaying){
				cash_sound.Stop();
				cash_sound.Play();
			}
			else{
				cash_sound.Play();
			}
			cash_sound.Play();
		}
	}
}

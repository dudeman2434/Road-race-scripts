using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_destroyer : MonoBehaviour {
	
	public GameObject Platform_destruction_point;

	// Use this for initialization
	void Start () {
		Platform_destruction_point= GameObject.Find("Platform_destruction_point");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y<Platform_destruction_point.transform.position.y){
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}
}

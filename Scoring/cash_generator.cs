using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cash_generator : MonoBehaviour {
	public Object_pool cash_pool;
	private float distance_between_cash_f,distance_between_cash_s;
	public void spawn_cash(Vector3 start_position){
		distance_between_cash_f=Random.Range(0,5);
		distance_between_cash_s=Random.Range(0f,0.9f);
		GameObject cash1=cash_pool.Get_pooled_object();
		cash1.transform.position=start_position;
		cash1.SetActive(true);

		GameObject cash2=cash_pool.Get_pooled_object();
		cash2.transform.position=new Vector3(start_position.x-distance_between_cash_s,start_position.y-distance_between_cash_f,0.9f);
		cash2.SetActive(true);
		cash1.SetActive(false);

		GameObject cash3=cash_pool.Get_pooled_object();
		cash3.transform.position=new Vector3(start_position.x+distance_between_cash_s,start_position.y+distance_between_cash_f,0.9f);
		cash3.SetActive(true);
	}
}

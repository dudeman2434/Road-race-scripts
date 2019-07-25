





















































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pool : MonoBehaviour {

	public GameObject pooled_object;
	public int pooled_amount;
	public List<GameObject> pooled_objects;
	float life_loc;

	// Use this for initialization
	void Start () {
		for(int x=0;x<pooled_objects.Count;x++){
			pooled_objects= new List<GameObject>();
			for(int i=0; i<pooled_amount; i++){
				GameObject obj =(GameObject)Instantiate(pooled_object);
				obj.SetActive(false);
				pooled_objects.Add(obj);
			}
		}
	}
	public GameObject Get_pooled_object(){
		for (int i = 0; i < pooled_objects.Count; i++)
		{
			if(!pooled_objects[i].activeInHierarchy){
				return pooled_objects[i];
			} 
		}
		GameObject obj=(GameObject)Instantiate(pooled_object);
		obj.SetActive(false);
		pooled_objects.Add(obj);
		for(int x=0;x<pooled_objects.Count;x++){
			life_loc=pooled_objects[x].GetComponent<Enemy_movement>().life;
			if(life_loc<0.5){
				pooled_objects[x].SetActive(false);
			}
			else if(life_loc>=0.5){
				pooled_objects[x].SetActive(true);
			}
	}
	return obj;
}
}



















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_pool : MonoBehaviour {

	public int pooled_amount;
	public List<GameObject> enemy;
	List<GameObject> pooled_objects;

	// Use this for initialization
	void Start () {
		pooled_objects= new List<GameObject>();
		for(int x=0;x<enemy.Count;x++){
			for(int i=0; i<pooled_amount; i++){
				GameObject obj =(GameObject)Instantiate(enemy[x]);
				obj.SetActive(false);
				pooled_objects.Add(obj);
				}
			}
	}
	public GameObject Get_pooled_object(){
		for(int x=0;x<enemy.Count;x++){
			for (int i = 0; i < pooled_objects.Count; i++){
				if(!pooled_objects[i].activeInHierarchy){
				return pooled_objects[i];
			} 
		}
		}
		GameObject obj=(GameObject)Instantiate(enemy);
		obj.SetActive(false);
		pooled_objects.Add(obj);
		return obj;
	}
} */
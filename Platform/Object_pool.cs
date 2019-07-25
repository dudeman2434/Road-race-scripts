using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_pool : MonoBehaviour {

	public GameObject pooled_object;
	public int pooled_amount;
	List<GameObject> pooled_objects;

	// Use this for initialization
	void Start () {
		pooled_objects= new List<GameObject>();

		for(int i=0; i<pooled_amount; i++){
			GameObject obj =(GameObject)Instantiate(pooled_object);
			obj.SetActive(false);
			pooled_objects.Add(obj);
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
		return obj;
	}
}
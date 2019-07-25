using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_generator : MonoBehaviour {
	public GameObject the_platform;
	public Transform generation_point;
	public float distance_between;
	private float platform_Width;
	public float distance_between_min;
	public float distance_between_max;
	public Object_pool[] the_object_pools;
	float life_loc;
	//public GameObject[] the_platforms;
	public int platform_Selector;
	private float[] platform_Widths;
	public cash_generator the_cash_generator;
	public float random_coin_threshold;
	public float random_ditch_threshold,random_enemy_threshold;
	public Object_pool ditch_pool,enemy_pool_car_1,enemy_pool_car_2;
	public List<GameObject> enemy;
	public bool spawn(Object_pool enemy_pool_car){
		if(Random.Range(0f,100f)<random_enemy_threshold){
				GameObject new_enemy=enemy_pool_car.Get_pooled_object();
				float enemyx_position=Random.Range(-platform_Widths[platform_Selector]/2+0.2f,platform_Widths[platform_Selector]/2-0.2f);
				Vector3 enemy_position=new Vector3(enemyx_position,0f,0f);
				new_enemy.transform.position=transform.position+enemy_position;
				new_enemy.transform.rotation=transform.rotation;
				new_enemy.SetActive(true);
			}
			return true;
	}
	// Use this for initialization
	void Start () {
		//platform_Width=the_platform.GetComponent<BoxCollider>().size.y;
		
		platform_Widths=new float[the_object_pools.Length];
		for(int i=0;i<the_object_pools.Length;i++){
			platform_Widths[i]=the_object_pools[i].pooled_object.GetComponent<BoxCollider>().size.y;
		}
		the_cash_generator=FindObjectOfType<cash_generator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.y<generation_point.position.y){
			distance_between=Random.Range(distance_between_min,distance_between_max);
			platform_Selector=Random.Range(0,the_object_pools.Length);

			//transform.position=new Vector3(0,transform.position.y+(platform_Widths[platform_Selector])/2+distance_between,0);undo
			transform.position=new Vector3(0,transform.position.y+3.00f,transform.position.z);
			//Instantiate (/*the_platform*/ the_object_pools[platform_Selector],transform.position,transform.rotation);
			GameObject new_platform=the_object_pools[platform_Selector].Get_pooled_object();
			new_platform.transform.position=transform.position;
			new_platform.transform.rotation=transform.rotation;
			new_platform.SetActive(true);
			if(Random.Range(0f,100f)<random_coin_threshold){
			the_cash_generator.spawn_cash(new Vector3(transform.position.x,transform.position.y+3f,transform.position.z));
			}
			if(Random.Range(0f,100f)<random_ditch_threshold){
				GameObject new_ditch=ditch_pool.Get_pooled_object();
				float ditchx_position=Random.Range(-platform_Widths[platform_Selector]/2+0.2f,platform_Widths[platform_Selector]/2-0.2f);
				Vector3 ditch_position=new Vector3(ditchx_position,0f,0f);
				new_ditch.transform.position=transform.position+ditch_position;
				new_ditch.transform.rotation=transform.rotation;
				new_ditch.SetActive(true);
			}
			spawn(enemy_pool_car_1);
			spawn(enemy_pool_car_2);
			/*for(int i=0;i<enemy.Count;i++){
			life_loc=gameObject.GetComponent<Enemy_movement>().life;
			if(life_loc<0.5){
				enemy[i].SetActive(false);
			}
			else if(life_loc>=0.5){
				enemy[i].SetActive(true);
			}
		} */
			/*if(Random.Range(0f,100f)<random_enemy_threshold){
				GameObject new_enemy=enemy_pool.Get_pooled_object();
				float enemyx_position=Random.Range(-platform_Widths[platform_Selector]/2+0.2f,platform_Widths[platform_Selector]/2-0.2f);
				Vector3 enemy_position=new Vector3(enemyx_position,0f,0f);
				new_enemy.transform.position=transform.position+enemy_position;
				new_enemy.transform.rotation=transform.rotation;
				if(new_enemy.transform.position.z==0.8439228){
					new_enemy.SetActive(true);
				}
				
			}*/

			//transform.position=new Vector3(0,transform.position.y+(platform_Widths[platform_Selector])/2,0);undo
			transform.position=new Vector3(0,transform.position.y+3.00f,transform.position.z);
		
		
		}
	}
}

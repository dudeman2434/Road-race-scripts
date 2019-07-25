using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_movement : MonoBehaviour{
	public Rigidbody myRigidbody;
	//private Animation anim;
	public float life=2;
	public GameObject life_loc;
	public float car_Acc;
	public float move_speed;
	private float move_speed_store;
	public float speed_multiplier;
	public float speed_increase_milestone;
	public float speed_increase_milestone_store;
	private float speed_milestone_count;
	private float speed_milestone_count_store;
	public bool left,right,jump,left1,right1,enemy_grounded;
	public Platform_generator generator;
	//public Collider go_through;

	int dir;
	protected Animator myAnimator;

	

	public void move_left(){
		left=true;
		right1=false;
		return;
	}

	public void move_right(){
		right=true; 
		left1=false;
		return;
	}
	public void move_jump(){
		jump=true;
		return;
	}
	public void stop_move_left(){
		left=false;
		left1=false;
		right1=false;

		return;
	}

	public void stop_move_right(){
		right=false;
		left1=false;
		right1=false;
		return;
	}
	public void stop_move_jump(){
		jump=false;
		return;
	}
	void Start(){
		//life_loc=GetComponent<GameObject>();
		speed_milestone_count=speed_increase_milestone;
		move_speed_store=move_speed;
		speed_milestone_count_store=speed_milestone_count;
		speed_increase_milestone_store=speed_increase_milestone;
		enemy_grounded=true;
		life=2;
	}
	void revive_enemy(){
			if(life<0){
				life=2;
		}
	}
	// Update is called once per frame
	public void FixedUpdate () {

		if(enemy_grounded){
			dir=Random.Range(0,4);
			if(dir%2==1){
			left=true;
			right=false;
		}
		else if(dir%2==0){
			right=true;
			left=false;
		}
		myRigidbody.velocity= new Vector3(0,move_speed,0);
		if(transform.position.x>speed_milestone_count){
			speed_milestone_count+=speed_increase_milestone;
			speed_increase_milestone=speed_increase_milestone+speed_multiplier;
			move_speed=move_speed*speed_multiplier;
		}
		if(Input.GetKey("d") || right){
			myRigidbody.AddForce(car_Acc*Time.deltaTime,0,0);//right
			right1=true;
			left1=false;
		}
		if(Input.GetKey("a") || left){
			myRigidbody.AddForce(-car_Acc*Time.deltaTime,0,0);//left
			left1=true;
			right1=false;
			}		}
				dir=Random.Range(0,4);
			if(dir%2==1){
			left=true;
			right=false;
		}
		else if(dir%2==0){
			right=true;
			left=false;
		}
		myRigidbody.velocity= new Vector3(0,move_speed,0);
		if(transform.position.x>speed_milestone_count){
			speed_milestone_count+=speed_increase_milestone;
			speed_increase_milestone=speed_increase_milestone+speed_multiplier;
			move_speed=move_speed*speed_multiplier;
		}
		if(Input.GetKey("d") || right){
			myRigidbody.AddForce(car_Acc*Time.deltaTime,0,0);//right
			right1=true;
			left1=false;
		}
		if(Input.GetKey("a") || left){
			myRigidbody.AddForce(-car_Acc*Time.deltaTime,0,0);//left
			left1=true;
			right1=false;
			}
		//myAnimator.SetFloat("life",life);
		}
	public void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag=="death" ||collision.gameObject.tag=="Player" ||collision.gameObject.tag=="Enemy"){
			life-=1;
			move_speed=move_speed_store;
			
			speed_milestone_count=speed_milestone_count_store;
			speed_increase_milestone=speed_increase_milestone_store;
			if(life>=0){
				life_loc.SetActive(true);
				if(left1==true){
					myRigidbody.AddForce(45000*Time.deltaTime,0,0);
					left1=false;
				}
				if(right1==true){
					myRigidbody.AddForce(-45000*Time.deltaTime,0,0);
					right1=false;
				}

			}
			if(life<=0.5){
				//anim.Play("Enemy_explosion");
				//life_loc.SetActive(false);
				Invoke("revive_enemy",3);

				}
		}
	if(collision.gameObject.tag=="Ground"){
		enemy_grounded=true;
	}
  }
	/*public void OnCollisionStay(Collision collision){
		if(collision.gameObject.name=="Ground") { grounded = true;}
		if(collision.gameObject.name!="Ground") { grounded = true;}
		
    }*/
 
    public void OnCollisionExit(Collision collision){
      if (collision.gameObject.name=="Ground") { }
    }
}

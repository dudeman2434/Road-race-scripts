using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_movement : MonoBehaviour{
	public Rigidbody myRigidbody;
	public float life=3;
	public float car_Acc=200;
	public float jump_Force=150;
	public bool grounded;
	public float move_speed;
	private float move_speed_store;
	public float speed_multiplier;
	public float speed_increase_milestone;
	public float speed_increase_milestone_store;
	private float speed_milestone_count;
	private float speed_milestone_count_store;
	public Game_manager game_Manager;

	public float jump_time;
	public float jump_time_counter;
	public bool left,right,jump,left1,right1;
	private Animator myAnimator;

	public AudioSource jump_sound;
	public AudioSource death_sound;
	public GameObject[] hearts;
	

	public void OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag=="death" || collision.gameObject.tag=="Enemy"){
			life-=1;
			move_speed=move_speed_store;
			
			speed_milestone_count=speed_milestone_count_store;
			speed_increase_milestone=speed_increase_milestone_store;
			death_sound.Play();
			grounded=true;
			if(life>=0){
				if(left1==true){
					myRigidbody.AddForce(45000*Time.deltaTime,0,0);
					left1=false;
				}
				if(right1==true){
					myRigidbody.AddForce(-45000*Time.deltaTime,0,0);
					right1=false;
				}
			}
			if(life<0){
				life=3;
				game_Manager.Restart_Game();
			}
		}
		else { grounded = true; jump_time_counter=0;}
    }
	/*public void OnCollisionStay(Collision collision){
		if(collision.gameObject.name=="Ground") { grounded = true;}
		if(collision.gameObject.name!="Ground") { grounded = true;}
		
    }*/
 
    public void OnCollisionExit(Collision collision){
        if (collision.gameObject.name=="Ground") { grounded = false;}
    }

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
		right=false;
		left=false;
		jump=false;
		hearts[0].SetActive(true);
		hearts[1].SetActive(true);
		hearts[2].SetActive(true);
		myRigidbody=GetComponent<Rigidbody>();
		speed_milestone_count=speed_increase_milestone;
		myAnimator=GetComponent<Animator>();
		jump_time_counter=jump_time;
		move_speed_store=move_speed;
		speed_milestone_count_store=speed_milestone_count;
		speed_increase_milestone_store=speed_increase_milestone;
		
		grounded=true;
	}
	// Update is called once per frame
	public void FixedUpdate () {
		if(life==3){
			hearts[0].SetActive(true);
			hearts[1].SetActive(true);
			hearts[2].SetActive(true);
		}
		else if(life<3){
			if(life==2){
				hearts[0].SetActive(false);
			}
			else if(life==1){
				hearts[1].SetActive(false);
			}
			else if(life==0){
				hearts[2].SetActive(false);
			}
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
			left=false;
		}
		if(Input.GetKey("a") || left){
			myRigidbody.AddForce(-car_Acc*Time.deltaTime,0,0);//left
			left1=true;
			right1=false;
			right=false;
		}
		if((Input.GetKey("space") ||jump )&& grounded){
			myRigidbody.AddForce(0,0,-jump_Force*Time.deltaTime);//jump
			grounded=false;
			jump_sound.Play();		
			jump_time_counter+=1;
		}

		else if((!grounded)&& jump_time_counter==0){
			jump_time_counter+=1;
		}
		/*if(Input.GetKey("space") ||jump){
			if(jump_time_counter>0){
				myRigidbody.AddForce(0,0,-jump_Force*Time.deltaTime);//jump
				jump_time-=Time.deltaTime;
			}
		}
		if(Input.GetKey("space") ||jump){
			jump_time_counter=0;
		}
		if(grounded){
			jump_time_counter=jump_time;
		}*/
		myAnimator.SetBool("grounded",grounded);
		myAnimator.SetBool("jump",jump);
		myAnimator.SetFloat("life",life);
	//	myAnimator.SetBool("inp2",inp2);
	//	myAnimator.SetBool("inp3",inp3);
	}

}



/*	public void move_right(int value){
		if (value == 1)
        {
            right = true;
        }
        else
        {
            right = false;
        }
	}

	public void move_left(int value){
		if (value == 1)
        {
            left = true;
        }
        else
        {
            left = false;
        }
	}

		if(Input.GetKey("d") || left){
			myRigidbody.AddForce(car_Acc*Time.deltaTime,0,0);//right
		}
		if(Input.GetKey("a") || right){
			myRigidbody.AddForce(-car_Acc*Time.deltaTime,0,0);//left
		}
 */
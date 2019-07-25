using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platorm_manager : MonoBehaviour {
	[SerializeField]
	private int max_platforms=10;
	
	[SerializeField]
	private GameObject[] blocks;

	[SerializeField]
	private GameObject lastblock;

	[HideInInspector]
	public GameObject car_landed_block;
	void Start () {
		for(int i=0;i<max_platforms;i++){
			Invoke("Create_new_platform",i*0.1f);
		}
	}

	void Create_new_platform(){
		Vector3 pos=Vector3.zero;

		while(true){
			int rand=Random.Range(0,100);

			if(rand<80){
				pos=new Vector3( lastblock.transform.localPosition.x,1f,lastblock.transform.localPosition.z+1f);
				if(Physics.Raycast(pos,Vector3.down,1.5f)&&
				Physics.Raycast(new Vector3(pos.x,pos.y,pos.z+1f),Vector3.down,1.5f))
					break;
			
			}
			else if (rand<100 && rand>=80){
				pos=new Vector3( lastblock.transform.localPosition.x,1f,lastblock.transform.localPosition.z+1f);
				if(Physics.Raycast(pos,Vector3.down,1.5f)&&
				Physics.Raycast(new Vector3(pos.x,pos.y,pos.z+1f),Vector3.down,1.5f))
					break;
			}
			/*else if (rand<90){
				pos=new Vector3(lastblock.transform.localPosition.x-1f,1f,lastblock.transform.localPosition.z);
				if(Physics.Raycast(pos,Vector3.down,1.5f)&&
				Physics.Raycast(new Vector3(pos.x-1f,pos.y,pos.z),Vector3.down,1.5f))
					break;

			}*/


		}

		int num=Random.Range(0,100)>0?0:1;
		GameObject temp=Instantiate(blocks[num]) as GameObject;
		temp.transform.localPosition=new Vector3(pos.x,0,pos.z);
		temp.transform.parent=transform;
		temp.name="road_all1";
		lastblock=temp;


	}
}

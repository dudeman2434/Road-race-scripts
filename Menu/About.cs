using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class About : MonoBehaviour {

	// Use this for initialization
public string main_menu;
public void Back(){
	Application.LoadLevel(main_menu);
}
}

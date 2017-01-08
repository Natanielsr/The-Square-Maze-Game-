﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviour : ObjBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * movSpeed;
		var y = Input.GetAxis ("Vertical") * Time.deltaTime * movSpeed;

		transform.Translate (x, y, 0);
	}
}

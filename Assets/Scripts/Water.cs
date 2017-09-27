using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	private Transform trans;
    
	void Start() {
		trans = transform;
    }
    
	void LateUpdate() {
		if (trans.position.y <= 1)
			trans.position = new Vector3(trans.position.x, Screen.height * 2 - 8, trans.position.z);
		
		trans.position = new Vector3(trans.position.x, trans.position.y - scrollSpeed * Time.deltaTime, trans.position.z);
  	}
}

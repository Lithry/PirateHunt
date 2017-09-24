using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	private bool isInside;
	private RectTransform rtra;
	private RectTransform pRtra;
	private Vector3 localSpacePoint;
	private Vector3[] corners = new Vector3[4];
    
	void Start() {
		rtra = GetComponent<RectTransform>();
		pRtra = GetComponentInParent<RectTransform>();
		rtra.GetWorldCorners(corners);
    }
    
	void LateUpdate() {
		if (transform.position.y <= 1)
			transform.position = new Vector3(transform.position.x, Screen.height * 2 - 8, transform.position.z);
		
		transform.position = new Vector3(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime, transform.position.z);
  	}
}

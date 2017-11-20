using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	public GameObject objetivePanel;
	public Image troops;
	public Image ships;
	public Image wood;
	public Image gold;
	public Image forward;
	private float timer;
	private int destroyAt;

	void Awake () {
		timer = 0.0f;
		destroyAt = 0;
		troops.color = Color.white;
		ships.color = Color.white;
		wood.color = Color.white;
		gold.color = Color.white;
		forward.color = Color.white;
	}

	void Update(){
		if (!objetivePanel.activeSelf){
			timer += Time.deltaTime;

			if (timer > 0.5f){
				if (troops.color == Color.white){
					troops.color = Color.red;
					ships.color = Color.red;
					wood.color = Color.red;
					gold.color = Color.red;
					forward.color = Color.red;
				}
				else{
					troops.color = Color.white;
					ships.color = Color.white;
					wood.color = Color.white;
					gold.color = Color.white;
					forward.color = Color.white;
					destroyAt++;
				}

				timer = 0.0f;
			}

			if (destroyAt == 3)
				Destroy(gameObject);
		}
	}

}

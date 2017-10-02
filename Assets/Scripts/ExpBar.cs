using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour {
	public Image bar;
	public GameObject gameOverPanel;
	private int maxExp;

	void Start () {
		gameOverPanel.SetActive(false);
		bar.fillAmount = 0;
		maxExp = 800;
	}
	
	void Update () {
		bar.fillAmount = CalculateAmount(ResourcesManager.instance.GetExp());
		
		if (bar.fillAmount >= 1)
			gameOverPanel.SetActive(true);
	}

	private float CalculateAmount(int exp){
		return ((exp * 100) / maxExp) * 0.01f;
	}
}

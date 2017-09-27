using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {
	private Text dificulttDisplay;
	private Text enemyCountDisplay;
	private Button button;
	private int id;
	private PoolObject po;


	void Awake () {
		button = GetComponentInChildren<Button>();
        button.onClick.AddListener(delegate() { UIManager.instance.AceptQuest(id); });
		po = GetComponent<PoolObject>();
		Text[] texts;
		texts = GetComponentsInChildren<Text>();

		foreach(Text text in texts){
			if (text.name == "DificultDisplay"){
				dificulttDisplay = text;
			}
			else if (text.name == "EnemyCountDisplay"){
				enemyCountDisplay = text;
			}
		}
	}
	
	public void SetTexts(int id, int dificulti, int enemyCount){
		this.id = id;
		dificulttDisplay.text = dificulti.ToString();
		enemyCountDisplay.text = enemyCount.ToString();
	}

	public int GetId(){
		return id;
	}

	public void Destroy(Pool pool){
		pool.Recycl(po);
	}
}

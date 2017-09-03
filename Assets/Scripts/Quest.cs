using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {
	private Text dificulttDisplay;
	private Text enemyCountDisplay;
	private Button button;
	private Sprite normal;
	private Sprite selected;
	private int id;


	void Awake () {
		button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate() { UIManager.instance.QuestSelected(id); });
		normal = UIManager.instance.QuestNormalButton();
		selected = UIManager.instance.QuestSelectedButton();
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
	public void ChangeImageNormal(){
		button.image.sprite = normal;
	}

	public void ChangeImageSelected(){
		button.image.sprite = selected;
	}

	public void Destroy(){
		Destroy(gameObject);
	}
}

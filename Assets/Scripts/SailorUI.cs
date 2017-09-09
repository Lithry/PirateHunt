using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailorUI : MonoBehaviour {
	private Text description;
	private Text cost;
	private Button hireButton;
	private int id;

	private int honorCost;
	private int fearCost;
	private int idleCost;
	private int goldCost;

	void Awake () {
		hireButton = GetComponentInChildren<Button>();
		hireButton.onClick.AddListener(delegate() { UIManager.instance.HireSailor(id); });
		Text[] texts;
		texts = GetComponentsInChildren<Text>();

		foreach(Text text in texts){
			if (text.name == "DescriptionText"){
				description = text;
			}
			else if (text.name == "CostText"){
				cost = text;
			}
		}
	}
	
	public void SetId(int id){
		this.id = id;
	}

	public int GetId(){
		return id;
	}

	public void SetDescription(string des){
		description.text = des;
	}

	public void SetCost(int honor, int fear, int idle, int gold){
		honorCost = honor;
		fearCost = fear;
		idleCost = idle;
		goldCost = gold;
		
		cost.text = "Honor: " + honorCost.ToString() + " | Miedo: " + fearCost.ToString() + " | Pereza: " + idleCost.ToString() + "\nOro: " + goldCost.ToString();
	}

	public void CheckIfCanHire(){
		if ((honorCost > ResourcesManager.instance.GetHonor()) || (fearCost > ResourcesManager.instance.GetFear()) || (idleCost > ResourcesManager.instance.GetIdle()) || (goldCost > ResourcesManager.instance.GetGold()))
			hireButton.interactable = false;
		else
			hireButton.interactable = true;
	}

	public void Destroy(){
		Destroy(gameObject);
	}
}

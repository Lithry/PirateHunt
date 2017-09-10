using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailorUI : MonoBehaviour {
	private Text description;
	private Text cost;
	private Button button;
	private Text buttonText;
	private int id;

	private int honorCost;
	private int fearCost;
	private int idleCost;
	private int goldCost;

	void Awake () {
		button = GetComponentInChildren<Button>();
		buttonText = button.GetComponentInChildren<Text>();
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
	
	public void SetButtonToHire(){
		button.onClick.AddListener(delegate() { UIManager.instance.HireSailor(id); });
		buttonText.text = "Contratar";
		CheckIfCanHire();
	}

	public void SetButtonToAdministrate(){
		button.onClick.AddListener(delegate() { UIManager.instance.MoveSailorInCrew(id); });
		buttonText.text = "Mover";
		button.interactable = true;
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

	public void SetCostNull(){
		cost.text = "";
	}

	public void CheckIfCanHire(){
		if ((honorCost > ResourcesManager.instance.GetHonor()) || (fearCost > ResourcesManager.instance.GetFear()) || (idleCost > ResourcesManager.instance.GetIdle()) || (goldCost > ResourcesManager.instance.GetGold()))
			button.interactable = false;
		else
			button.interactable = true;
	}

	public void Destroy(){
		Destroy(gameObject);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailorUI : MonoBehaviour {
	public Text description;
	public Text cost;
	public Button buttonHire;
	public Button buttonMoveToReserv;
	public Button buttonMoveToActive;
	private RectTransform buttonTransform;
	private Text buttonMoveText;
	public Image portrait;
	private RectTransform trans;
	private PoolObject po;

	private int id;

	private int honorCost;
	private int fearCost;
	private int idleCost;
	private int goldCost;

	void Awake () {
		trans = gameObject.GetComponent<RectTransform>();
		//buttonHire.onClick.AddListener(delegate() { UIManager.instance.HireSailor(id); });
		//buttonMoveToReserv.onClick.AddListener(delegate() { UIManager.instance.SailorToReserv(id); });
		//buttonMoveToActive.onClick.AddListener(delegate() { UIManager.instance.SailorToActive(id); });
		po = GetComponent<PoolObject>();
	}
	
	public void SetButtonToHire(){
		buttonMoveToReserv.gameObject.SetActive(false);
		buttonMoveToActive.gameObject.SetActive(false);
		buttonHire.gameObject.SetActive(true);
		CheckIfCanHire();
	}

	public void SetButtonToMoveReservActive(){
		buttonMoveToReserv.gameObject.SetActive(false);
		buttonHire.gameObject.SetActive(false);
		buttonMoveToActive.gameObject.SetActive(true);
	
	}

	public void SetButtonToMoveActiveReserv(){
		buttonMoveToActive.gameObject.SetActive(false);
		buttonHire.gameObject.SetActive(false);
		buttonMoveToReserv.gameObject.SetActive(true);

	}

	public void SetParentAndSize(ref GameObject parent, Vector2 size, Vector2 anchorMin, Vector2 anchorMax, Vector3 pos){
		gameObject.transform.SetParent(parent.transform);
		gameObject.transform.localPosition = pos;
		trans.sizeDelta = size;
	}

	public void SetId(int id){
		this.id = id;
	}

	public int GetId(){
		return id;
	}

	public void SetPortrait(Sprite port){
		portrait.sprite = port;
		portrait.preserveAspect = true;
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
			buttonHire.interactable = false;
		else
			buttonHire.interactable = true;
	}

	public void Destroy(Pool pool){
		pool.Recycl(po);
	}
}

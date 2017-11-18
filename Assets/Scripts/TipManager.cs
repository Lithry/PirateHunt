using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour {
	public Text woodForShipCost;
	// Use this for initialization
	void Awake () {
		woodForShipCost.text = ShipsCost.WoodCost.ToString();	
	}
}

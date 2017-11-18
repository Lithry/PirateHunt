using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipManager : MonoBehaviour {
	public Text woodForShipCost;
	public Text troopsPerShip;
	// Use this for initialization
	void Awake () {
		woodForShipCost.text = ShipsCost.WoodCost.ToString();
		troopsPerShip.text = TroopsSlots.TroopsForShip.ToString();	
	}
}

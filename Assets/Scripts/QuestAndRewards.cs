using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAndRewards : MonoBehaviour {
	static public QuestAndRewards instance;
	private QuestManager.QuestData aceptedQuest;
	private int honor;
	private int fear;
	private int idle;
	private int gold;

	void Start () {
		instance = this;
	}

	public void SetQuest(int id){
		aceptedQuest = QuestManager.instance.GetQuest(id);
	}
}

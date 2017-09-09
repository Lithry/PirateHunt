using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAndRewards : MonoBehaviour {
	static public QuestAndRewards instance;
	private QuestManager.QuestData aceptedQuest;
	private int catchs;
	private int kills;
	private int misses;

	void Start () {
		instance = this;
	}

	public void SetQuest(int id){
		aceptedQuest = QuestManager.instance.GetQuest(id);
	}

	public QuestManager.QuestData GetQuestData(){
		if (aceptedQuest.id != 0){
			return aceptedQuest;
		}
		else{
			QuestManager.QuestData miss = new QuestManager.QuestData(0, 0, 0);
			return miss;
		}
	}

	public void RestartValues(){
		catchs = 0;
		kills = 0;
		misses = 0;
	}

	public int GetCatch(){
		return catchs;
	}

	public void AddCatch(int value){
		catchs += value;
	}

	public int GetKills(){
		return kills;
	}

	public void AddKilled(int value){
		kills += value;
	}

	public int GetAway(){
		return misses;
	}

	public void AddAway(int value){
		misses += value;
	}

	public void QuestCompleted(){
		ResourcesManager.instance.AddHonor(catchs * 2);
		ResourcesManager.instance.AddFear(kills * 2);
		ResourcesManager.instance.AddIdle(misses * 2);
		ResourcesManager.instance.AddGold((catchs + (int)(kills / 2)) * 5);
	}
}

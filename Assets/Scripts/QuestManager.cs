using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {
	static public QuestManager instance;
	public struct QuestData{
		public int id;
		public int dificult;
		public int numEnemis;

		public QuestData(int id, int dificult, int enemies){
			this.id = id;
			this.dificult = dificult;
			this.numEnemis = enemies;
		}
	}

    private List<QuestData> quests = new List<QuestData>();

    void Awake () {
		instance = this;
		
		QuestData q = new QuestData(1, 1,1);
		quests.Add(q);
		QuestData q2 = new QuestData(2, 2,2);
		quests.Add(q2);
	}

	public List<QuestData> GetQuests() {
        return quests;
    }

	public QuestData GetQuest(int id){
		for (int i = 0; i < quests.Count; i++){
			if (quests[i].id == id){
				return quests[i];
			}
		}
		QuestData miss = new QuestData(0, 0, 0);
		return miss;
	}
}

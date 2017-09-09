using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject questPanel;
	public GameObject questPrefab;
	public GameObject questContainer;
	private List<Quest> questList = new List<Quest>();
	public GameObject tavernPanel;
	public GameObject sailorPrefab;
	public GameObject sailorContainer;
	private List<SailorUI> sailorsOnUI = new List<SailorUI>();
	public GameObject cityUI;
	public GameObject combatUI;
	public Text combatLog;
	public Text questRewardText;
	public GameObject combatOptionPanel;
	public GameObject completedQuestPanel;
	
	void Start () {
		instance = this;
		questPanel.SetActive(false);
		tavernPanel.SetActive(false);
		completedQuestPanel.SetActive(false);
		combatOptionPanel.SetActive(false);
		combatUI.SetActive(false);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			Application.Quit();
		}
	}

	// QUEST OPTIONS ===================================================================

	public void QuestPanelOpen(){
		if (!questPanel.active){
			TavernPanelClose();
			List<QuestManager.QuestData> q;
			q = QuestManager.instance.GetQuests();
			questContainer.transform.localPosition = new Vector3(0, 0, 0);		
			for (int i = 0; i < q.Count; i++){
				GameObject nQuest = Instantiate(questPrefab);
				nQuest.transform.SetParent(questContainer.transform);
				nQuest.transform.localPosition = new Vector3(0, -(100 * i), 0);
				RectTransform trans = nQuest.GetComponent<RectTransform>();
				trans.sizeDelta = new Vector2(0, 95);
				Quest que = nQuest.GetComponent<Quest>();
				que.SetTexts(q[i].id, q[i].dificult, q[i].numEnemis);

				questList.Add(que);
			}
			RectTransform queContainer = questContainer.GetComponent<RectTransform>();
			queContainer.sizeDelta = new Vector2(0, 100 * questList.Count);
			questPanel.SetActive(true);
		}
	}

	public void QuestPanelClose(){
		foreach (Quest que in questList){
			que.Destroy();
		}
		questList.Clear();
		questPanel.SetActive(false);
	}

	public void AceptQuest(int id){
		foreach (Quest que in questList){
			if (id == que.GetId()){
				QuestAndRewards.instance.SetQuest(id);
				QuestAndRewards.instance.RestartValues();
			}
		}
		QuestPanelClose();
		StartCoroutine(ChangeInstanceToCombat());
	}

	public void TavernPanelOpen(){
		if (!tavernPanel.active){
			QuestPanelClose();
			List<Sailor> sailors = AvalivleSailors.instance.GetAvalivleSailors();
			for(int i = 0; i < sailors.Count; i++){
				GameObject nSailor = Instantiate(sailorPrefab);
				nSailor.transform.SetParent(sailorContainer.transform);
				nSailor.transform.localPosition = new Vector3(0, -(100 * i), 0);
				
				RectTransform trans = nSailor.GetComponent<RectTransform>();
				trans.sizeDelta = new Vector2(0, 95);
				
				SailorUI sailorUI = nSailor.GetComponent<SailorUI>();
				sailorUI.SetId(sailors[i].GetId());
				sailorUI.SetCost(sailors[i].GetHonorRequired(), sailors[i].GetFearRequired(), sailors[i].GetIdleRequired(), sailors[i].GetGoldRequired());
				sailorUI.CheckIfCanHire();

				sailorsOnUI.Add(sailorUI);
			}
			RectTransform saContainer = sailorContainer.GetComponent<RectTransform>();
			saContainer.sizeDelta = new Vector2(0, 100 * sailors.Count);
			tavernPanel.SetActive(true);
		}
	}

	public void TavernPanelClose(){
		foreach(SailorUI sailor in sailorsOnUI){
			sailor.Destroy();
		}
		sailorsOnUI.Clear();
		tavernPanel.SetActive(false);
	}

	public void HireSailor(int id){
		foreach (SailorUI sailor in sailorsOnUI){
			if (id == sailor.GetId()){
				AvalivleSailors.instance.HireSailor(id);
				sailorsOnUI.Remove(sailor);
				sailor.Destroy();
				RearrangeSailorsOnUI();
				break;
			}
		}
		
	}

	private void RearrangeSailorsOnUI(){
		for (int i = 0; i < sailorsOnUI.Count; i++){
			sailorsOnUI[i].gameObject.transform.localPosition = new Vector3(0, -(100 * i), 0);
		}
	}

	IEnumerator ChangeInstanceToCombat()
    {
        float fadeTime = FadeTransition.instance.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        cityUI.SetActive(false);
		combatUI.SetActive(true);
		combatOptionPanel.SetActive(true);
		FadeTransition.instance.BeginFade(-1);

		combatLog.text = "Has encontrado " + QuestAndRewards.instance.GetQuestData().numEnemis.ToString() + " barcos piratas\nQue haras:";
		
    }

	// =================================================================================
	// COMBAT OPTIONS ==================================================================

	public void Catch(){
		QuestAndRewards.instance.AddCatch(QuestAndRewards.instance.GetQuestData().numEnemis);
		QuestAndRewards.instance.QuestCompleted();
		combatOptionPanel.SetActive(false);
		
		questRewardText.text = "Has Recibido:\nHonor: " + QuestAndRewards.instance.GetCatch() * 2 + 
		" | Miedo: " +  QuestAndRewards.instance.GetKills() * 2 + " | Pereza: " + QuestAndRewards.instance.GetAway() * 2 + 
		"\nOro: " + ((QuestAndRewards.instance.GetCatch() + (int)(QuestAndRewards.instance.GetKills() / 2)) * 5).ToString();

		completedQuestPanel.SetActive(true);
	}

	public void Kill(){
		QuestAndRewards.instance.AddKilled(QuestAndRewards.instance.GetQuestData().numEnemis);
		QuestAndRewards.instance.QuestCompleted();
		combatOptionPanel.SetActive(false);
		
		questRewardText.text = "Has Recibido:\nHonor: " + QuestAndRewards.instance.GetCatch() * 2 + 
		" | Miedo: " +  QuestAndRewards.instance.GetKills() * 2 + " | Pereza: " + QuestAndRewards.instance.GetAway() * 2 + 
		"\nOro: " + ((QuestAndRewards.instance.GetCatch() + (int)(QuestAndRewards.instance.GetKills() / 2)) * 5).ToString();
		
		completedQuestPanel.SetActive(true);
	}

	public void Idle(){
		QuestAndRewards.instance.AddAway(QuestAndRewards.instance.GetQuestData().numEnemis);
		QuestAndRewards.instance.QuestCompleted();
		combatOptionPanel.SetActive(false);
		
		questRewardText.text = "Has Recibido:\nHonor: " + QuestAndRewards.instance.GetCatch() * 2 + 
		" | Miedo: " +  QuestAndRewards.instance.GetKills() * 2 + " | Pereza: " + QuestAndRewards.instance.GetAway() * 2 + 
		"\nOro: " + ((QuestAndRewards.instance.GetCatch() + (int)(QuestAndRewards.instance.GetKills() / 2)) * 5).ToString();
		
		completedQuestPanel.SetActive(true);
	}

	public void ReturnToCity(){
		StartCoroutine(ChangeInstanceToCity());
	}

	IEnumerator ChangeInstanceToCity()
    {
        float fadeTime = FadeTransition.instance.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
		completedQuestPanel.SetActive(false);
		combatUI.SetActive(false);
        cityUI.SetActive(true);
		FadeTransition.instance.BeginFade(-1);		
    }
}

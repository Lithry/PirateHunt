﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public GameObject crewPanel;
	public GameObject sailorActiveContainer;
	public GameObject sailorReservContainer;
	private List<SailorUI> activeSailorsOnUI = new List<SailorUI>();
	private List<SailorUI> reservSailorsOnUI = new List<SailorUI>();
	public GameObject cityUI;
	public GameObject combatUI;
	public Text combatLog;
	public Text questRewardText;
	public GameObject combatOptionPanel;
	public GameObject completedQuestPanel;
	public GameObject questUIPoolManager;
	private Pool questUIPool;
	private PoolObject nQuest;
	public GameObject sailorUIPoolManager;
	private Pool sailorUIPool;
	private PoolObject nSailor;
	
	void Start () {
		instance = this;
		questUIPool = questUIPoolManager.GetComponent<Pool>();
		sailorUIPool = sailorUIPoolManager.GetComponent<Pool>();
		questPanel.SetActive(false);
		tavernPanel.SetActive(false);
		crewPanel.SetActive(false);
		completedQuestPanel.SetActive(false);
		combatOptionPanel.SetActive(false);
		combatUI.SetActive(false);
	}

	// QUEST OPTIONS ===================================================================

	public void QuestPanelOpen(){
		if (!questPanel.activeSelf){
			TavernPanelClose();
			CrewPanelClose();
			List<QuestManager.QuestData> q;
			q = QuestManager.instance.GetQuests();
			questContainer.transform.localPosition = new Vector3(0, 0, 0);		
			for (int i = 0; i < q.Count; i++){
				nQuest = questUIPool.Spawn();
				nQuest.gameObject.transform.SetParent(questContainer.transform);
				nQuest.gameObject.transform.localPosition = new Vector3(0, -(100 * i), 0);
				RectTransform trans = nQuest.gameObject.GetComponent<RectTransform>();
				trans.sizeDelta = new Vector2(0, 95);
				Quest que = nQuest.GetComponent<Quest>();
				que.SetTexts(q[i].id, q[i].dificult, q[i].numEnemis);

				questList.Add(que);
				
				nQuest = null;
			}
			RectTransform queContainer = questContainer.GetComponent<RectTransform>();
			queContainer.sizeDelta = new Vector2(0, 100 * questList.Count);
			questPanel.SetActive(true);
		}
	}

	public void QuestPanelClose(){
		foreach (Quest que in questList){
			que.Destroy(questUIPool);
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
		if (!tavernPanel.activeSelf){
			QuestPanelClose();
			CrewPanelClose();
			List<Sailor> sailors = AvalivleSailors.instance.GetAvalivleSailors();
			for(int i = 0; i < sailors.Count; i++){
				nSailor = sailorUIPool.Spawn();
				
				SailorUI sailorUI = nSailor.gameObject.GetComponent<SailorUI>();
				sailorUI.SetParentAndSize(ref sailorContainer, new Vector2(0, 95), new Vector2(0.05f, 1), new Vector2(0.95f, 1), new Vector3(0, -(100 * i), 0));
				sailorUI.SetId(sailors[i].GetId());
				sailorUI.SetPortrait(sailors[i].GetPortrait());
				sailorUI.SetCost(sailors[i].GetHonorRequired(), sailors[i].GetFearRequired(), sailors[i].GetIdleRequired(), sailors[i].GetGoldRequired());
				sailorUI.SetButtonToHire();

				sailorsOnUI.Add(sailorUI);

				nSailor = null;
			}
			RectTransform saContainer = sailorContainer.GetComponent<RectTransform>();
			saContainer.sizeDelta = new Vector2(0, 100 * sailors.Count);
			tavernPanel.SetActive(true);
		}
	}

	public void TavernPanelClose(){
		foreach(SailorUI sailor in sailorsOnUI){
			sailor.Destroy(sailorUIPool);
		}
		sailorsOnUI.Clear();
		tavernPanel.SetActive(false);
	}

	public void HireSailor(int id){
		foreach (SailorUI sailor in sailorsOnUI){
			if (id == sailor.GetId()){
				AvalivleSailors.instance.HireSailor(id);
				sailorsOnUI.Remove(sailor);
				sailor.Destroy(sailorUIPool);
				RearrangeSailorsOnUI();
				break;
			}
		}
	}

	private void RearrangeSailorsOnUI(){
		for (int i = 0; i < sailorsOnUI.Count; i++){
			sailorsOnUI[i].gameObject.transform.localPosition = new Vector3(0, -(100 * i), 0);
			sailorsOnUI[i].CheckIfCanHire();
		}
	}

	public void CrewPanelOpen(){
		if (!crewPanel.activeSelf){
			QuestPanelClose();
			TavernPanelClose();
			List<Sailor> sailorsReserv = CrewManager.instance.GetSailorsInReserv();
			for (int i = 0; i < sailorsReserv.Count; i++){
				nSailor = sailorUIPool.Spawn();

				SailorUI sailorUI = nSailor.gameObject.GetComponent<SailorUI>();
				sailorUI.SetParentAndSize(ref sailorReservContainer, new Vector2(0, 55), new Vector2(0.05f, 1), new Vector2(0.95f, 1), new Vector3(0, -(60 * i), 0));
				sailorUI.SetId(sailorsReserv[i].GetId());
				sailorUI.SetPortrait(sailorsReserv[i].GetPortrait());
				sailorUI.SetCostNull();
				sailorUI.SetButtonToMoveReservActive();

				reservSailorsOnUI.Add(sailorUI);
				
				nSailor = null;
			}

			List<Sailor> sailorsActive = CrewManager.instance.GetSailorsActives();
			for (int i = 0; i < sailorsActive.Count; i++){
				nSailor = sailorUIPool.Spawn();

				SailorUI sailorUI = nSailor.gameObject.GetComponent<SailorUI>();
				sailorUI.SetParentAndSize(ref sailorActiveContainer, new Vector2(0, 55), new Vector2(0.05f, 1), new Vector2(0.95f, 1), new Vector3(0, -(60 * i), 0));
				sailorUI.SetId(sailorsActive[i].GetId());
				sailorUI.SetPortrait(sailorsActive[i].GetPortrait());
				sailorUI.SetCostNull();
				sailorUI.SetButtonToMoveActiveReserv();

				activeSailorsOnUI.Add(sailorUI);

				nSailor = null;
			}
			crewPanel.SetActive(true);
		}
	}

	public void CrewPanelClose(){
		foreach(SailorUI sailor in reservSailorsOnUI){
			sailor.Destroy(sailorUIPool);
		}
		reservSailorsOnUI.Clear();
		foreach(SailorUI sailor in activeSailorsOnUI){
			sailor.Destroy(sailorUIPool);
		}
		activeSailorsOnUI.Clear();
		crewPanel.SetActive(false);
	}

	public void SailorToReserv(int id){
		foreach (SailorUI sailor in activeSailorsOnUI){
			if (id == sailor.GetId()){
				reservSailorsOnUI.Add(sailor);
				activeSailorsOnUI.Remove(sailor);
				sailor.transform.SetParent(sailorReservContainer.transform);
				CrewManager.instance.MoveToReserv(id);
				sailor.SetButtonToMoveReservActive();
				RearrangeSailorsOnPortUI();
				break;
			}
		}
	}

	public void SailorToActive(int id){
		foreach (SailorUI sailor in reservSailorsOnUI){
			if (id == sailor.GetId()){
				activeSailorsOnUI.Add(sailor);
				reservSailorsOnUI.Remove(sailor);
				sailor.transform.SetParent(sailorActiveContainer.transform);
				CrewManager.instance.MoveToActive(id);
				sailor.SetButtonToMoveActiveReserv();
				RearrangeSailorsOnPortUI();
				break;
			}
		}
	}

	private void RearrangeSailorsOnPortUI(){
		for (int i = 0; i < reservSailorsOnUI.Count; i++){
			reservSailorsOnUI[i].SetParentAndSize(ref sailorReservContainer, new Vector2(0, 55), new Vector2(0.05f, 1), new Vector2(0.95f, 1), new Vector3(0, -(60 * i), 0));
		}
		for (int i = 0; i < activeSailorsOnUI.Count; i++){
			activeSailorsOnUI[i].SetParentAndSize(ref sailorActiveContainer, new Vector2(0, 55), new Vector2(0.05f, 1), new Vector2(0.95f, 1), new Vector3(0, -(60 * i), 0));
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
		QuestAndRewards.instance.AddExp(QuestAndRewards.instance.GetQuestData().numEnemis * 10);
		QuestAndRewards.instance.QuestCompleted();
		combatOptionPanel.SetActive(false);
		
		questRewardText.text = "Has Recibido:\nHonor: " + QuestAndRewards.instance.GetCatch() * 2 + 
		" | Miedo: " +  QuestAndRewards.instance.GetKills() * 2 + " | Pereza: " + QuestAndRewards.instance.GetAway() * 2 + 
		"\nOro: " + ((QuestAndRewards.instance.GetCatch() + (int)(QuestAndRewards.instance.GetKills() / 2)) * 5).ToString();

		completedQuestPanel.SetActive(true);
	}

	public void Kill(){
		QuestAndRewards.instance.AddKilled(QuestAndRewards.instance.GetQuestData().numEnemis);
		QuestAndRewards.instance.AddExp(QuestAndRewards.instance.GetQuestData().numEnemis * 10);
		QuestAndRewards.instance.QuestCompleted();
		combatOptionPanel.SetActive(false);
		
		questRewardText.text = "Has Recibido:\nHonor: " + QuestAndRewards.instance.GetCatch() * 2 + 
		" | Miedo: " +  QuestAndRewards.instance.GetKills() * 2 + " | Pereza: " + QuestAndRewards.instance.GetAway() * 2 + 
		"\nOro: " + ((QuestAndRewards.instance.GetCatch() + (int)(QuestAndRewards.instance.GetKills() / 2)) * 5).ToString();
		
		completedQuestPanel.SetActive(true);
	}

	public void Idle(){
		QuestAndRewards.instance.AddAway(QuestAndRewards.instance.GetQuestData().numEnemis);
		QuestAndRewards.instance.AddExp(QuestAndRewards.instance.GetQuestData().numEnemis * 6);
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

	// =================================================================================
	// GAMEOVER OPTIONS ================================================================

	public void Restart(){
		SceneManager.LoadScene("Pirate Hunt");
	}

	public void Quit(){
		Application.Quit();
	}
}

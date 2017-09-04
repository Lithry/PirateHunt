﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	static public UIManager instance;
	public GameObject questPrefab;
	public GameObject questPanel;
	public GameObject questAceptButton;
	public GameObject questContainer;
	public Sprite questNormalButton;
	public Sprite questSelectedButton;
	private List<Quest> questList = new List<Quest>();
	private int questSelectedId;
	public GameObject cityUI;
	public GameObject combatUI;
	public Text combatLog;
	public Text questRewardText;
	public GameObject combatOptionPanel;
	public GameObject completedQuestPanel;
	
	void Start () {
		instance = this;
		questPanel.SetActive(false);
		questAceptButton.SetActive(false);
		completedQuestPanel.SetActive(false);
		combatOptionPanel.SetActive(false);
		combatUI.SetActive(false);
		questSelectedId = 0;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)){
			Application.Quit();
		}
	}

	// QUEST OPTIONS ===================================================================

	public void QuestPanelOpen(){
		if (!questPanel.active){
			questPanel.SetActive(true);
			List<QuestManager.QuestData> q;
			q = QuestManager.instance.GetQuests();
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
		}
	}

	public void QuestPanelClose(){
		foreach (Quest que in questList){
			que.Destroy();
		}
		questList.Clear();
		questAceptButton.SetActive(false);
		questPanel.SetActive(false);
	}

	public void QuestSelected(int id){
		questSelectedId = id;
		foreach (Quest que in questList){
			if (questSelectedId == que.GetId())
				que.ChangeImageSelected();
			else
				que.ChangeImageNormal();
		}
		questAceptButton.SetActive(true);
	}

	public void AceptQuest(){
		foreach (Quest que in questList){
			if (questSelectedId == que.GetId()){
				QuestAndRewards.instance.SetQuest(questSelectedId);
				QuestAndRewards.instance.RestartValues();
			}
		}
		QuestPanelClose();
		StartCoroutine(ChangeInstanceToCombat());
	}

	public Sprite QuestNormalButton(){
		return questNormalButton;
	}

	public Sprite QuestSelectedButton(){
		return questSelectedButton;
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

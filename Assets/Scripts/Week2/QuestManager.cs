using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    GameObject questManager = new GameObject("QuestManager");
                    instance = questManager.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = Instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != null) { Destroy(gameObject); }
    }

    // [Q3] 구현사항 3
    public List<QuestDataSO> Quests;
    public Text questText;
    public string questinfo;

    private void Start()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            QuestDataSO quest = Quests[i];
            questinfo += $"Quest {i + 1} - {quest.QuestName} (최소 레벨 {quest.QuestRequiredLevel})\n";
        }

        questText.text = questinfo;
    }
}
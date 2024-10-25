using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
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

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != null) { Destroy(gameObject); }
    }

    // [Q3] �������� 3
    public List<QuestDataSO> Quests;
    public Text questText;
    public string questinfo;

    private void Start()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            QuestDataSO quest = Quests[i];
            questinfo += $"Quest {i + 1} - {quest.QuestName} (�ּ� ���� {quest.QuestRequiredLevel})\n";
        }

        questText.text = questinfo;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class QuestDataSO : MonoBehaviour
{
    public string QuestName;                // ����Ʈ �̸�
    public int QuestRequiredLevel;          // ����Ʈ �ּҷ���
    public int QuestNPC;                    // ����Ʈ NPC id (int)
    public List<int> QuestPrerequisites;    // ���� ����Ʈ id ����Ʈ
}

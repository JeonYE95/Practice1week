using System.Collections.Generic;
using UnityEngine;

public class QuestDataSO : MonoBehaviour
{
    public string QuestName;                // 퀘스트 이름
    public int QuestRequiredLevel;          // 퀘스트 최소레벨
    public int QuestNPC;                    // 퀘스트 NPC id (int)
    public List<int> QuestPrerequisites;    // 선행 퀘스트 id 리스트
}

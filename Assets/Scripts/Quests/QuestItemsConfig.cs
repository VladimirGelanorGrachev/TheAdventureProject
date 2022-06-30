using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="QuestItemsConfig", fileName ="Quests/QuestItemsConfig")]
public class QuestItemsConfig : ScriptableObject
{
    [SerializeField]
    private int _questId;

    [SerializeField]
    private List<int> _questItemCollection;

    public int QuestId => _questId;
    public List<int> QuestItemCollection => _questItemCollection;
}

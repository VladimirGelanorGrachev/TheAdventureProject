using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestConfigurator : MonoBehaviour
{
    [SerializeField]
    private QuestStoryConfig[] _questStoryConfigs;

    [SerializeField]
    private QuestObjectView[] _questObjects;

    [SerializeField]
    private QuestObjectView _singleQuestView;

    private Quest _singleQuest;
    private List<IQuestStory> _questStorys;

    private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>()
    {
        { QuestType.Switch, () => new SwitchQuestModel() }
    };

    private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>
    {
        { QuestStoryType.Common, questCollection => new QuestStory(questCollection) },
    };

    private void Start()
    {
        _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel());
        _singleQuest.Reset();

        _questStorys = new List<IQuestStory>();

        foreach(var questStoryConfig in _questStoryConfigs)
            _questStorys.Add(CrateQuestStory(questStoryConfig));
    }

    private IQuestStory CrateQuestStory(QuestStoryConfig questStoryConfig)
    {
        var quests = new List<IQuest>();

        foreach (var questConfig in questStoryConfig.Quests)
        {
            var quest = CreateQuest(questConfig);

            if (quest == null)
                continue;

            quests.Add((IQuest)quest);
        }
        return _questStoryFactories[questStoryConfig.QuestStoryType].Invoke(quests);         
    }

    private object CreateQuest(QuestConfig questConfig)
    {
        var questId = questConfig.Id;
        var questView = _questObjects.FirstOrDefault(value => value.Id == questId);

        if(questView == null)
            return null;

        if(_questFactories.TryGetValue(questConfig.QuestType, out var factory))
        {
            var questModel = factory.Invoke();
            return new Quest(questView, questModel);
        }

        return null;
    }

    private void OnDestroy()
    {
        _singleQuest.Dispose();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class ResettableQuestStory : IQuestStory
{
    private readonly List<IQuest> _questsCollection;
    private int _currentIndex;

    public ResettableQuestStory(List<IQuest> questCollection)
    {
        _questsCollection = questCollection ?? throw new ArgumentNullException(nameof(questCollection));
        Subscribe();
        ResetQuest();
    }       

    private void Subscribe()
    {
        foreach (var quest in _questsCollection)
        {
            quest.Completed += OnQuestCompleted;
        }
    }
    

    private void UnSubscribe()
    {
        foreach (var quest in _questsCollection)
        {
            quest.Completed -= OnQuestCompleted;
        }
    }

    private void OnQuestCompleted(IQuest quest)
    {
        var index = _questsCollection.IndexOf(quest);

        if (_currentIndex == index)
        {
            _currentIndex++;
            if (IsDone) Debug.Log("Well done!");
        }
        else
        {
            ResetQuest();
        }
    }

    private void ResetQuest()
    {
        _currentIndex = 0;
        foreach (var quest in _questsCollection)
        {
            quest.Reset();
        }
    }

    public bool IsDone => _questsCollection.All(value => value.IsCompleted);

    public void Dispose()
    {
        UnSubscribe();        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class ResettableQuestStory : IQuestStory
{
    private readonly List<IQuest> _questsCollection;
    private int _currentIndex;

    public bool IsDone => _questsCollection.All(value => value.IsCompleted);

    public ResettableQuestStory(List<IQuest> questCollection)
    {
        _questsCollection = questCollection;
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

    public void Dispose()
    {
        UnSubscribe();        
    }
}

using System.Collections.Generic;
using UnityEngine;

internal class ProtectedZone
{
    private readonly List<IProtector> _protectors;
    private readonly LevelObjectTrigger _view;

    public ProtectedZone(LevelObjectTrigger view, List<IProtector> protectors)
    {
        _view = view;
        _protectors = protectors;
    }

    public void Init()
    {
        _view.TriggerEnter += OnContact;
        _view.TriggerExit += OnExit;
    }

    public void Deinit()
    {
        _view.TriggerEnter -= OnContact;
        _view.TriggerExit -= OnExit;
    }

    private void OnContact(GameObject gameObject)
    {
        foreach (var protector in _protectors)
            protector.StartProtection(gameObject);
    }

    private void OnExit(GameObject gameObject)
    {
        foreach (var protector in _protectors)
            protector.FinishProtection(gameObject);
    }
}
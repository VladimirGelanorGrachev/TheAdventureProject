using UnityEngine;

internal interface IProtector
{
    void StartProtection(GameObject invader);
    void FinishProtection(GameObject invader);
}
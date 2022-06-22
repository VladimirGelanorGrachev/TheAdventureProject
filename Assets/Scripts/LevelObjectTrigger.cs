using System;
using UnityEngine;

public class LevelObjectTrigger : MonoBehaviour
{
    public Action<GameObject> TriggerEnter;
    public Action<GameObject> TriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerEnter?.Invoke(other.gameObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerExit?.Invoke(other.gameObject);
    }
}

using UnityEngine;

public class Finish : MonoBehaviour
{   
    
    void Update()
    {
        if (CompareTag("Player"))
        {
            Debug.Log("IsVictory");
        }
    }
}

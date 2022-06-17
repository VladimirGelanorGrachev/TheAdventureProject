using UnityEngine;

public class IsDeath
{      
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("IsDeath");
        }
    }
    public void Update()
    {        
    }
}

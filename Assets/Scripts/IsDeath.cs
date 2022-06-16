using UnityEngine;

public class IsDeath
{
    private CharacterView _characterView;
    private float Health = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IsDeath"))
        {
            Debug.Log("IsDeath");
        }
    }
    public void Update()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTerst : MonoBehaviour
{    

    private void OnCollisionEnter2d(Collision2D collision2D)
    {
        if (collision2D.transform.name == "Player")
        {
            StartCoroutine(StuckInTheMud(collision2D));
        }
    }
    public IEnumerator StuckInTheMud(Collision2D victim)
    {
        victim.rigidbody.isKinematic = true;
        yield return new WaitForSeconds(5f);
        victim.rigidbody.isKinematic = false;
    }
}

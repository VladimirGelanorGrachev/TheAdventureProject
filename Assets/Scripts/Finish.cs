using UnityEngine;

public class Finish
{      
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    bool _onTrigger;

    [SerializeField]
    private TriggerView _finish;

    //private void Start()
    //{
    //    _player = GameObject.Find("Player");
    //}
    //void Update()
    //{     
    //    if (_onTrigger == true)
    //    {            
    //        OnTriggerEnter(_player);
    //    }
    //}

    //public void OnTriggerEnter(GameObject Player)
    //{       
    //    _player = Player;        
    //    if (_player != null)
    //    {            
    //        Debug.Log("IsVictory");
    //    }
    //}

    public Finish(GameObject Player, bool OnTrigger)
    {
        _player = Player;
        _onTrigger = OnTrigger;


    }
}

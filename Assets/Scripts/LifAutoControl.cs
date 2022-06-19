using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifAutoControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _lift;

    [SerializeField]
    private SliderJoint2D _sliderJoint;  
       
    void Start()
    {
        _lift = GameObject.Find("Lift");
        
    }
    
    void Update()
    {
        
    }
}



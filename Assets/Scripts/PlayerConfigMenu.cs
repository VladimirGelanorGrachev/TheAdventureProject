using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigMenu", menuName = "Configs/PlayerConfig")]
public class PlayerConfigMenu : ScriptableObject
{
    [Header("Settings")]
    [SerializeField]
    private float _walkSpeed = 1;

    [SerializeField]
    private float _animationsSpeed = 3;

    [SerializeField]
    private float _jumpStartSpeed = 2;

    [SerializeField]
    private float _movingTresh = 0.1f;

    [SerializeField]
    private float _flyTresh = 0.3f;

    [SerializeField]
    private float _groundLevel = 0.1f;

    [SerializeField]
    private float _acceleration = -10f;


    
    public float WalkSpeed => _walkSpeed;
    public float AnimationsSpeed => _animationsSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MovingTresh => _movingTresh;
    public float FlyTresh => _flyTresh;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;   
}

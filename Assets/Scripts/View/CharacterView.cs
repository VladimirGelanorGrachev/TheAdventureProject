using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
     private SpriteRenderer spriteRenderer;

    [SerializeField]
    private PlayerConfigMenu _playerConfig;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private Collider2D _collider;

    [SerializeField]
    private bool _isDeath = false;

    [SerializeField]
    private bool _isTrigger = false;

     public SpriteRenderer SpriteRenderer => spriteRenderer;

    public PlayerConfigMenu PlayerConfig => _playerConfig;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;
}

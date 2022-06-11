using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
     private SpriteRenderer spriteRenderer;

    [SerializeField]
    private PlayerConfigMenu _playerConfig;

     public SpriteRenderer SpriteRenderer => spriteRenderer;

    public PlayerConfigMenu PlayerConfig => _playerConfig;
}

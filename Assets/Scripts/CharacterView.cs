using UnityEngine;

public class CharacterView : MonoBehaviour
{
 [SerializeField]
 private SpriteRenderer spriteRenderer;

 public SpriteRenderer SpriteRenderer => spriteRenderer;
}

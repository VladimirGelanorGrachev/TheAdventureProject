using UnityEngine;
public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private SpriteAnimationsConfig _spriteAnimatiionsConfig;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    private SpriteAnimator _spriteAnimator;

    public SpriteRenderer SpriteRenderer => spriteRenderer;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void EnemyTrack()
    {
        _spriteAnimator = new SpriteAnimator(_spriteAnimatiionsConfig);
        _spriteAnimator.StartAnimation(SpriteRenderer, Track.run, true, 10);
    }

    public void Update()
    {
       EnemyTrack();
    }
}
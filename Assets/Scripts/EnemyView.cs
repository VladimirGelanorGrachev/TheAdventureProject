using UnityEngine;
public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private SpriteAnimationsConfig _spriteAnimatiionsConfig;

    private SpriteAnimator _spriteAnimator;

    public SpriteRenderer SpriteRenderer => spriteRenderer;


    private void EnemyTrack()
    {
        _spriteAnimator = new SpriteAnimator(_spriteAnimatiionsConfig);
        _spriteAnimator.StartAnimation(SpriteRenderer, Track.Run, true, 10);
    }

    public void Update()
    {
       EnemyTrack();
    }
}
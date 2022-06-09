using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private SpriteRenderer _background;
    [SerializeField]
    private CharacterView _characterView;
    [SerializeField]
    private SpriteAnimationsConfig _spriteAnimatiionsConfig;
    [SerializeField]
    private EnemyView _enemyView;
    

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera,_background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimatiionsConfig);
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.Walk, true, 10);        
    }
    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _enemyView.Update();
    }
    private void FixedUpdate()
    {
        
    }
    private void OnDestroy()
    {
        
    }
}
using Pathfinding;
using System.Collections.Generic;
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

    [SerializeField]
    private CannonView _cannonView;

    [SerializeField]
    private List<BulletView> _bullets;

    //[SerializeField]
    //private List<TriggerView> _triggers;

    [SerializeField]
    private AIConfig _simplePatrolAIConfig;

    [Header("Protector AI")]
    [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
    [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
    [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
    [SerializeField] private Transform[] _protectorWaypoints;

    private SimplePatrolAI _simplePatrolAI;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroPhysicsWalker _mainHeroWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;

    private ProtectorAI _protectorAI;
    private ProtectedZone _protectedZone;
    //private Finish _finishTrigger;
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera,_background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimatiionsConfig);
        _mainHeroWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);
        //_finishTrigger = new Finish(,);

        _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
        _protectorAI.Init();

        _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector> { _protectorAI });
        _protectedZone.Init();
    }
    private void Update()
    {        
        _paralaxManager.Update();
        _spriteAnimator.Update();        
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();        
        _enemyView.Update();        
    }
    private void FixedUpdate()
    {
        _mainHeroWalker.FixedUpdate();
    }
    private void OnDestroy()
    {
        _protectorAI.Deinit();
        _protectedZone.Deinit();
    }
}
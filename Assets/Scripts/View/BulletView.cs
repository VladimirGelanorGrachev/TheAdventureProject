using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [Header("Settings")]
    
    private float _radius = 0.3f;
    
    private float _groundLevel = 0;
    
    private float _acceleration = -10;

    public float Radius => _radius;

    public float GroundLevel => _groundLevel;

    public float Acceleration => _acceleration;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}

using UnityEngine;

public class Bullet
{
    private BulletView _bulletView;
    private Vector3 _velocity;
    
    public Bullet(BulletView bulletView)
    {
        _bulletView = bulletView;
        _bulletView.SetVisible(false);
    }

    public void Update()
    {
        if (IsGrounded())
        {
            SetVelocity(_velocity.Change(y: -_velocity.y));
            _bulletView.transform.position = _bulletView.transform.position.Change(y: _bulletView.GroundLevel + _bulletView.Radius);
        }
        else
        {
            SetVelocity(_velocity + Vector3.up * _bulletView.Acceleration * Time.deltaTime);
            _bulletView.transform.position += _velocity * Time.deltaTime;
        }
    }

    public void Throw(Vector3 position, Vector3 velocity)
    {
        _bulletView.transform.position = position;
        SetVelocity(velocity);
        _bulletView.SetVisible(true);
    }

    private void SetVelocity(Vector3 velocity)
    {
        _velocity = velocity;
        
        var angle = Vector3.Angle(Vector3.left, _velocity);
        var axis = Vector3.Cross(Vector3.left, _velocity);
        _bulletView.transform.rotation = Quaternion.AngleAxis(angle, axis);

    }

    private bool IsGrounded()
    {
        return _bulletView.transform.position.y <= _bulletView.GroundLevel + _bulletView.Radius && _velocity.y <= 0;
    }
}

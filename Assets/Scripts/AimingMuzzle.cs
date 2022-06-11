using UnityEngine;

public class AimingMuzzle
{
    private Transform _muzzleTransform;
    private Transform _aimTransform;

    public AimingMuzzle(Transform muzzleTransform, Transform aimTransform)
    {
        _muzzleTransform = muzzleTransform;
        _aimTransform = aimTransform;
    }

    public void Update()
    {
        var dir = _aimTransform.position - _muzzleTransform.position;
        var angle = Vector3.Angle(-Vector3.left, dir);
        var axis = Vector3.Cross(-Vector3.left, dir);
        
        _muzzleTransform.rotation = Quaternion.AngleAxis(angle, axis);
    }
}

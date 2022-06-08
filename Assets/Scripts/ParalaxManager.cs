using UnityEngine;

public class ParalaxManager
{
    private const float Coef = 0.3f;

    private Camera _camera;
    private Transform _backTransform;
    private Vector3 _backStartPosition;
    private Vector3 _cameraStartPosition;

    public ParalaxManager(Camera camera, Transform backTransform)
    {
        _camera = camera;
        _backTransform = backTransform;
        _backStartPosition = backTransform.position;
        _cameraStartPosition = camera.transform.position;
    }
    public void Update()
    {
        _backTransform.position = _backStartPosition + (_camera.transform.position - _cameraStartPosition) * Coef;
    }
}

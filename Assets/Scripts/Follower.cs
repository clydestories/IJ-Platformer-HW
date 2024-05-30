using UnityEngine;

public class Follower : MonoBehaviour
{
    private const float CameraZPosition = -10;

    [SerializeField] private Transform _target;
    [SerializeField] private bool _isCamera;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, _isCamera ? CameraZPosition : _target.position.y + _offset.z);
    }
}
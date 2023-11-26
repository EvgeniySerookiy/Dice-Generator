using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    private float _currentTime;
    private void Update()
    {
        _currentTime += Time.deltaTime;
        var position = Vector3.Lerp(_start.position, _end.position, _currentTime);
        var scale = Vector3.Lerp(_start.localScale, _end.lossyScale, _currentTime);
        var rotation = Quaternion.Lerp(_start.rotation, _end.rotation, _currentTime);
        transform.position = position;
        transform.localScale = scale;
        transform.rotation = rotation;
    }
}

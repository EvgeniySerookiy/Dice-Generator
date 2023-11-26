using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration = 2f;
    
    [SerializeField]
    private float _pauseRecoloring = 2f;
    
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;

    private float _currentTime;
    private float _pauseTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
        _pauseTime = _pauseRecoloring;
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
    }

    private void Update()
    {
        if (_pauseTime > 0f)
        {
            _pauseTime -= Time.deltaTime;
            return;
        }
        
        _currentTime += Time.deltaTime;
        
        var progress = _currentTime / _recoloringDuration;

        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
        
        if (_currentTime >= _recoloringDuration)
        {
            _currentTime = 0f;
            _pauseTime = _pauseRecoloring;
            GenerateNextColor();
        }
    }
}

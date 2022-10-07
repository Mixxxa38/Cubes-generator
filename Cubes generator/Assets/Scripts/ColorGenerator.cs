using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ColorGenerator : MonoBehaviour
{
    [SerializeField] 
    private float _recoloringTime = 1f;

    [SerializeField] 
    private float _colorChangeTime = 2f;
    
    private Color _startColor;
    
    private Color _nextColor;

    private Renderer _renderer;

    private float _currentTime;

    private float _cooldown;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        
        GenerateNextColor();
    }
  
    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        
        _nextColor = Random.ColorHSV(0f, 1f, 0.9f, 1f, 1, 1);
    }

    private void Update()
    {
        _cooldown += Time.deltaTime;
        
        if (_cooldown <= _colorChangeTime)
        {
            return;
        }
        
        _currentTime += Time.deltaTime;

        var progress = _currentTime / _recoloringTime;
        
        var currentColor =  Color.Lerp(_startColor, _nextColor, progress);

        _renderer.material.color = currentColor;

        if (_currentTime > _recoloringTime)
        {
            _cooldown = 0f;
            
            _currentTime = 0f;
            
            GenerateNextColor();
        }
    }
}

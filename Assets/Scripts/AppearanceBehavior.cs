using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ApperanceBehaviour : MonoBehaviour
{
    // Сериализуем наш объект
    [SerializeField] private GameObject _cube;
    private void Update()
    {
        // При нажатии на пробел будут рандомно генерироваться кубики не быходя 
        // за указанные рамки
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cube);
            newCube.transform.position = new Vector3(Random.Range(-10, 10), 15, 5);
        }
    }
}
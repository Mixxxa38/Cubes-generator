using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _cube;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          var newCube = Instantiate(_cube);
          newCube.transform.position = new Vector3(Random.Range(-30, 30), 20,Random.Range(-30, 30));
        }   
    }
}

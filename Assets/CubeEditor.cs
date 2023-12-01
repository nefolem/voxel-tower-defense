using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;
    TextMesh lebel;
    // Update is called once per frame
    void Update()
    {        
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.y = 0f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = snapPos;

        lebel = GetComponentInChildren<TextMesh>();
        lebel.text = snapPos.x/gridSize + "," + snapPos.z/gridSize;
    }
}

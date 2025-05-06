using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomColor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the renderer component
        Renderer renderer = GetComponent<Renderer>();
        
        if (renderer != null)
        {
            // Create a random color
            Color randomColor = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            
            // Apply the random color to the material
            renderer.material.color = randomColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

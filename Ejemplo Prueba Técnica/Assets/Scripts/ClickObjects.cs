using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ClickObjects : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        // Start the destruction process
        StartCoroutine(DestroyWithDelay());
    }
    
    private IEnumerator DestroyWithDelay()
    {
        // You could add effects here like scaling down or fading
        
        // Wait for the specified delay
        yield return new WaitForSeconds(destroyDelay);
        
        // Destroy the game object
        Destroy(gameObject);
    }
}

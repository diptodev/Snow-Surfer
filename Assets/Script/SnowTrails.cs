using System;
using UnityEngine;

public class SnowTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrails;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex=LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer==layerIndex)
        {
            snowTrails.Play();
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
         int layerIndex=LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer==layerIndex)
        {
            snowTrails.Stop();
        }
        
    }
}

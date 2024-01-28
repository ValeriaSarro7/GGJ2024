using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    public Material[] materials;

    void Start()
    {
         Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && materials.Length > 0)
        {
            int randomIndex = Random.Range(0, materials.Length);
            renderer.material = materials[randomIndex];
        }
    }

}

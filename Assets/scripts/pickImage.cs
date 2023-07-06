using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickImage : MonoBehaviour
{
    public List<GameObject> images;
    void Start()
    {
        images[Random.Range(0, images.Count)].SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forFlatsOnObjects : MonoBehaviour
{
    public GameObject mainObject;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - mainObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mainObject.transform.position + offset;
    }
}

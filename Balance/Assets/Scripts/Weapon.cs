using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Button button;
    public GameObject flat;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
    }

    void TaskOnClick()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        var posZ = (float)ForObjectOnFlat.Instance.valueZForObjects[1];
        var posY = (float)ForObjectOnFlat.Instance.valueYForObjects[1];
        var flatPos = flat.transform.position;
        Vector3 movement = new Vector3((float)flatPos.x, posY - 0.1f, posZ);
        transform.position = movement;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

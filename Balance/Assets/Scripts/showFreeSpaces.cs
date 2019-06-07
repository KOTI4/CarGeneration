using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oldFlats : MonoBehaviour
{
    public Button button;
    public GameObject flat;
    private Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => TaskOnClick());
        scale = transform.localScale;
    }

    void TaskOnClick()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var flatPos = flat.GetComponent<Transform>().position;
        var posZ = (float)ForObjectOnFlat.Instance.startArray[0].CenterCoorZ;
        var posY = (float)ForObjectOnFlat.Instance.startArray[0].CenterCoorY;
        var newWidht = (float)ForObjectOnFlat.Instance.startArray[0].widhtZ;
        Vector3 movement = new Vector3((float)flatPos.x, posY + 0.15f, posZ);
        transform.localScale = new Vector3(scale.x, scale.y, newWidht);
        transform.position = movement;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

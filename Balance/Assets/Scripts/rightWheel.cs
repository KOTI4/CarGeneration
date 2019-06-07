using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightWheel : MonoBehaviour
{
    public Button button;
    public int number;
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
        var posX = (float)ForObjectOnFlat.Instance.kolesa[number].positionXforRight;
        var posZ = (float)ForObjectOnFlat.Instance.kolesa[number].positionZ;
        var posY = (float)ForObjectOnFlat.Instance.kolesa[number].positionY;
        Vector3 movement = new Vector3(posX, posY, posZ);
        transform.position = movement;
    }
}

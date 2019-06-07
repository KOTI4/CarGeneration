using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponNew : MonoBehaviour
{
    public static WeaponNew Instance { get; private set; }
    public Button button;
   
    public GameObject flat;
    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
    }
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
        var flatPos = flat.transform.position;
        var posX = 0.0f;

        posX = (float)flatPos.x;
       


        var posZ = (float)ForObjectOnFlat.Instance.valueZForObjects[2];
        var posY = (float)ForObjectOnFlat.Instance.valueYForObjects[2];
        
        Vector3 movement = new Vector3(posX, posY-0.44f, posZ);
        transform.position = movement;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

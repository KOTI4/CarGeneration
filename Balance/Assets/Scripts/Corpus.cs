using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corpus : MonoBehaviour
{
    public static Corpus Instance { get; private set; }
    public Button button;
    public GameObject flat;
    public GameObject[] ownFlats;
   
    public float pos;
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
        var flatPos = flat.GetComponent<Transform>().position;
        pos = ForObjectOnFlat.Instance.valueZ;
        Vector3 movement = new Vector3((float)flatPos.x, (float)flatPos.y+0.06f, pos);
        transform.position = movement;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

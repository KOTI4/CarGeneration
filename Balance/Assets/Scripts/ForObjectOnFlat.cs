using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForObjectOnFlat : MonoBehaviour
{
    public static ForObjectOnFlat Instance { get; private set; }
    public Button button;
    public GameObject detail;
    public GameObject weapon_detail;
    public GameObject weapon_detail_2;
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    public float[] valueZForObjects;
    public float[] valueYForObjects;
    public float valueZ;
    public GameObject[] corpusFlats;
    //public float valueZ_1;
    //public float valueZ_2;
    //public float valueY_1;
    //public float valueY_2;
    public int numberFlat;

    public float[] tryPosArea;
    public float[] trySizeArea;
    public float tryPosFlat2;
    public float tryPosflat;


    private float randomPos;
    public  Wheels[] kolesa;
    private ObjectOnFlat[] Details;
    private ObjectOnFlat CorpusThere;
    private ObjectOnFlat Weapon;
    private ObjectOnFlat Weapon2;
    public SpaceForObjectAbove StartFlat;
    public List<SpaceForObjectAbove> startArray;

    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(() => TaskOnClick());

        var flatPos = transform.position;
        var flatCenter = GetComponent<BoxCollider>().center;
        var flatSize = transform.localScale;
        StartFlat = new SpaceForObjectAbove(flatPos.z, flatPos.y, flatSize.z * 2);
        startArray = new List<SpaceForObjectAbove>() { StartFlat };
        //var flatsOnCorpus = new GameObject[] { Corpus.Instance.ownFlats[0], Corpus.Instance.ownFlats[1] };
        CorpusThere = new ObjectOnFlat(detail, -0.5f, corpusFlats, randomPos);
        Weapon = new ObjectOnFlat(weapon_detail, -0.065f, new GameObject[] { }, 20);
        Weapon2 = new ObjectOnFlat(weapon_detail_2, 0.2f, new GameObject[] { }, 20);
        Details = new ObjectOnFlat[] { CorpusThere, Weapon, Weapon2 };
        kolesa = new Wheels[leftWheels.Length];
        for (int i = 0; i < leftWheels.Length; i++)
        {
            kolesa[i] = new Wheels(leftWheels[i], rightWheels[i],
                leftWheels[i].transform.position.y,
                leftWheels[i].transform.position.x,
                rightWheels[i].transform.position.x,
                leftWheels[i].transform.position.z);
        }

    }
    void TaskOnClick()
    {


        var rnd = new System.Random();
        startArray = new List<SpaceForObjectAbove>() { StartFlat };
        //var findPos = false;
        //var randPosArr = rnd.Next(startArray.Count - 1);
        //while (findPos)
        //{
        //    if (startArray[randPosArr].widhtZ >= CorpusThere.widhtZ)
        //        findPos = true;
        //    else
        //    {
        //        startArray.Remove(startArray[randPosArr]);
        //        randPosArr = rnd.Next(startArray.Count - 1);
        //    }



        //}
        if (CorpusThere.CanFindFlat(startArray))
        {
            var randPosArr = CorpusThere.FindFlatInArray(startArray);
            randomPos = CorpusThere.FindPositionOnFlat(startArray[randPosArr]);
            valueZForObjects[0] = randomPos;
            CorpusThere = new ObjectOnFlat(detail, -0.5f, corpusFlats, randomPos);
            var newSpacesInstead = StartFlat.FindNewSpaces(randomPos, CorpusThere);
            startArray.Remove(startArray[randPosArr]);
            foreach (var space in newSpacesInstead)
                startArray.Add(space);
        }
        else
            valueZForObjects[0] = 60;



        if (Weapon.CanFindFlat(startArray))
        {
            var randPosArr_1 = Weapon.FindFlatInArray(startArray);

            var randPos_1 = Weapon.FindPositionOnFlat(startArray[randPosArr_1]);
            //Weapon = new ObjectOnFlat(detail, 0.0f, new GameObject[] { }, randPos_2);
            valueZForObjects[1] = randPos_1;
            valueYForObjects[1] = (float)startArray[randPosArr_1].CenterCoorY;
            var newSpacesInstead = startArray[randPosArr_1].FindNewSpaces(randPos_1, Weapon);
            startArray.Remove(startArray[randPosArr_1]);
            foreach (var space in newSpacesInstead)
                startArray.Add(space);
        }
        else
            valueZForObjects[1] = 60;



        if (Weapon2.CanFindFlat(startArray))
        {
            var randPosArr_2 = Weapon2.FindFlatInArray(startArray);
            numberFlat = randPosArr_2;
            var randPos_2 = Weapon2.FindPositionOnFlat(startArray[randPosArr_2]);
            valueZForObjects[2] = randPos_2;
            valueYForObjects[2] = (float)startArray[randPosArr_2].CenterCoorY;
        }
        else
            valueZForObjects[2] = 60;





        //var flatPos = transform.position;
        //var flatCenter = GetComponent<BoxCollider>().center;
        //var flatSize = transform.localScale;
        //var flatRotation = GetComponent<Transform>().rotation;
        //var randomIntPos = rnd.Next((int)startArray[randPosArr].CenterCoorZ - (int)startArray[randPosArr].widhtZ / 2,
        //    (int)startArray[randPosArr].CenterCoorZ + (int)startArray[randPosArr].widhtZ / 2);
        //var randomDob = rnd.NextDouble();
        var NewCenter = FindNewCenter(StartFlat, Details);
        var border1 = StartFlat.CenterCoorZ - StartFlat.widhtZ / 2;
        var border2 = StartFlat.CenterCoorZ + StartFlat.widhtZ / 2;
        var posForFirstWheels = (float)border1 + kolesa[0].FindPosOutNewCenter(NewCenter, StartFlat) + (float)rnd.NextDouble();
        var posForSecondtWheels = (float)border2 - kolesa[0].FindPosOutNewCenter(NewCenter, StartFlat) - (float)rnd.NextDouble();

        kolesa[0] = new Wheels(leftWheels[0], rightWheels[0],
            leftWheels[0].transform.position.y,
            leftWheels[0].transform.position.x,
            rightWheels[0].transform.position.x,
            posForFirstWheels);
        kolesa[1] = new Wheels(leftWheels[1], rightWheels[1],
            leftWheels[1].transform.position.y,
            leftWheels[1].transform.position.x,
            rightWheels[1].transform.position.x,
            posForSecondtWheels);






        tryPosFlat2 = (float)CorpusThere.SpacesAbove[0].CenterCoorZ;
        tryPosflat = (float)CorpusThere.SpacesAbove[1].CenterCoorZ;

        for (int i = 0; i < startArray.Count; i++)
        {
            tryPosArea[i] = (float)startArray[i].CenterCoorZ;
        }
        for (int i = 0; i < startArray.Count; i++)
        {
            trySizeArea[i] = (float)startArray[i].widhtZ;
        }
        //tryPosOf = (float)startArray[0].CenterCoorZ;

        valueZ = /*(float)System.Math.Cos(flatRotation.z * System.Math.PI / 180) **/ randomPos;


    }

    // Update is called once per frame
    void Update()
    {



    }

    public float FindNewCenter(SpaceForObjectAbove startFlat, ObjectOnFlat[] details)
    {
        var summPos = 0.0f;
        foreach (var detail in details)
            summPos += detail.objectOnFlat.transform.position.z;
        return summPos / details.Length;
    }
}

public class ObjectOnFlat
{
    public GameObject objectOnFlat;
    public float widhtZ;
    public float outOfRealCenter;
    //public double height;
    public SpaceForObjectAbove[] SpacesAbove;

    public ObjectOnFlat(GameObject ourObject, float outCenter, GameObject[] flats, float posZ)
    {
        objectOnFlat = ourObject;
        //widhtX = gameObject.GetComponent<BoxCollider>().size.x;
        widhtZ = ourObject.GetComponent<BoxCollider>().size.z;
        outOfRealCenter = outCenter;
        //height = heightOfSpace;
        //var Space = new SpaceForObjectAbove(gameObject.GetComponent<Transform>().position.z,
        //    gameObject.GetComponent<Transform>().position.y + heightOfSpace, gameObject.GetComponent<BoxCollider>().size.z);
        //SpacesAbove = new SpaceForObjectAbove[1] { Space };




        var vectorFromCenterZ = new float[flats.Length];
        for (int i = 0; i < flats.Length; i++)
        {
            vectorFromCenterZ[i] = ourObject.transform.position.z - flats[i].transform.position.z;
        }
        //var vectorFromCenterY = new float[flats.Length];
        //for (int i = 0; i < flats.Length; i++)
        //{
        //    vectorFromCenterY[i] = ourObject.transform.position.y - flats[i].transform.position.y;
        //}


        var timeArray = new SpaceForObjectAbove[flats.Length];
        for (int i = 0; i < flats.Length; i++)
        {
            timeArray[i] = new SpaceForObjectAbove(
                posZ - vectorFromCenterZ[i],
                flats[i].transform.position.y,
                flats[i].transform.localScale.z);
        }
        SpacesAbove = timeArray;

    }

    public bool CanFindFlat(List<SpaceForObjectAbove> areasForObject)
    {
        bool otvet = false;
        for (int i = 0; i < areasForObject.Count; i++)
            if (areasForObject[i].widhtZ >= widhtZ)
                otvet = true;
        return otvet;
    }

    public int FindFlatInArray(List<SpaceForObjectAbove> areasForObject)
    {
        var rnd = new System.Random();

        var notfindPos = true;
        var randPosArr = rnd.Next(areasForObject.Count);
        while (notfindPos)
        {
            if (areasForObject[randPosArr].widhtZ >= widhtZ)
                notfindPos = false;
            else
            {
                if (areasForObject.Count != 1)
                {
                    areasForObject.Remove(areasForObject[randPosArr]);
                    randPosArr = rnd.Next(areasForObject.Count - 1);
                }


            }
        }
        return randPosArr;
    }
    public float FindPositionOnFlat(SpaceForObjectAbove flat)
    {
        var rnd = new System.Random();
        int minBorder = (int)flat.CenterCoorZ - (int)flat.widhtZ / 2;
        int maxBorder = (int)flat.CenterCoorZ + (int)flat.widhtZ / 2;
        int halfOfObject = (int)System.Math.Floor(widhtZ / 2);
        double difference = System.Math.Abs(widhtZ / 2 - halfOfObject);
        var randomIntPos = rnd.Next(minBorder + halfOfObject, maxBorder - halfOfObject + 1);
        //var difference = System.Math.Abs(minBorder - (flat.CenterCoorZ - flat.widhtZ / 2));
        //var randomIntPos = rnd.Next((int)flat.CenterCoorZ - (int)flat.widhtZ / 2,
        //   (int)flat.CenterCoorZ + (int)flat.widhtZ / 2);
        var randomDob = rnd.NextDouble();
        if (randomDob < difference)
            randomDob = randomDob + difference;
        if (randomIntPos > flat.CenterCoorZ)
            return (float)((double)randomIntPos - randomDob / 2);
        else
            return (float)((double)randomIntPos + randomDob / 2);
        //if (randomIntPos < flat.CenterCoorZ)
        //    return (float)(randomIntPos /* (randomDob - 1 + difference)*/);
        //else
        //    return (float)(randomIntPos /* randomDob - difference*/);
    }

}

public class SpaceForObjectAbove
{
    public double CenterCoorZ;
    public double CenterCoorY;
    public double widhtZ;
    public SpaceForObjectAbove(double coorZ, double coorY, double widhtZ)
    {
        CenterCoorZ = coorZ;
        CenterCoorY = coorY;

        this.widhtZ = widhtZ;

    }

    public List<SpaceForObjectAbove> FindNewSpaces(float objectPositionZ, ObjectOnFlat ourObject)
    {
        var newSpaces = new List<SpaceForObjectAbove>();



        var spaceBorder1 = CenterCoorZ - widhtZ / 2;
        var objectBorder1 = objectPositionZ + ourObject.outOfRealCenter - ourObject.widhtZ / 2;

        if (objectBorder1 > spaceBorder1)
            newSpaces.Add(new SpaceForObjectAbove(
                objectBorder1 - (objectBorder1 - spaceBorder1) / 2,
                CenterCoorY,
                objectBorder1 - spaceBorder1));



        var spaceBorder2 = CenterCoorZ + widhtZ / 2;
        var objectBorder2 = objectPositionZ + ourObject.outOfRealCenter + ourObject.widhtZ / 2;

        if (objectBorder2 < spaceBorder2)
            newSpaces.Add(new SpaceForObjectAbove(
                objectBorder2 + (spaceBorder2 - objectBorder2) / 2,
                CenterCoorY,
                spaceBorder2 - objectBorder2));

        if (ourObject.SpacesAbove.Length != 1)
            foreach (var spaceOfObject in ourObject.SpacesAbove)
                newSpaces.Add(spaceOfObject);




        return newSpaces;
    }


}
public class Wheels
{
    GameObject rightWheel;
    GameObject leftWheel;
    public float positionY;
    public float positionZ;
    public float positionXforLeft;
    public float positionXforRight;

    public Wheels(GameObject lWheel, GameObject rWheel, float posY, float posXleft, float posXright, float posZ)
    {
        rightWheel = rWheel;
        leftWheel = lWheel;
        positionY = posY;
        positionZ = posZ;
        positionXforLeft = posXleft;
        positionXforRight = posXright;

    }

    public float FindPosOutNewCenter(float newCenter, SpaceForObjectAbove startFlat)
    {
        var rnd = new System.Random();
        var minLenOutBorder = 0.0f;
        var border1 = startFlat.CenterCoorZ - startFlat.widhtZ / 2;
        var border2 = startFlat.CenterCoorZ + startFlat.widhtZ / 2;
        if (border2 - newCenter > newCenter - border1)
            minLenOutBorder = newCenter - (float)border1;
        else minLenOutBorder = (float)border2 - newCenter;
        minLenOutBorder = (float)System.Math.Floor((double)minLenOutBorder);
        return (float)rnd.Next((int)minLenOutBorder);
    }



}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour
{

    public GameObject cartPrefab;
    public Transform cartParent;
    public Transform cartSpawnPoint;

    public Transform cameraPivot;
    public float cameraMoveSpeed = 10f;

    public int numberOfCarts = 25;

    public GameObject cloudPrefab;
    public GameObject wordPrefab;

    public Transform cartsParent;
    public Transform couldsParent;

    Transform[] bases;

    int baseNum;

    bool[] posMap;


    private Transform[] cloudsList;
    private Transform[] cartList;
    private Vector3[] randomPosition;



    private float cartSpaceing = 13.4f;//-0.134f;
    private bool doCenter = false;
    private int reachedIndex = 0;

    private Vector3 newCamPosition;
    private Vector3 baseCamPosition;

    //private float threeCartOffset = 4.4f;

    private List<Transform> cartsList;
    // Start is called before the first frame update
    void Start()
    {
        randomPosition = new Vector3[numberOfCarts];
        posMap = new bool[numberOfCarts];
        cloudsList = new Transform[numberOfCarts];
        cartList = new Transform[numberOfCarts];
        cartsList = new List<Transform>();
        //m_CartColors = new M_CartColors();
        numberOfCarts = 25;//get this number from api that gives the hadeeth
              SpawnCarts(); 
        InitBases();
        createClouds();
        
        InitCameraPosition();
        baseCamPosition = cameraPivot.position;
 



    }


    void createClouds()
    {
        for (int i = 0; i < numberOfCarts; i++)
        {
            GameObject go = Instantiate(cloudPrefab, couldsParent);
            GameObject Text = Instantiate(wordPrefab, go.transform);
            Text.name = (i + 1).ToString();
            go.transform.position = new Vector3(bases[i].position.x, bases[i].position.y + 16, bases[i].position.z+4);
            Text.transform.position = new Vector3(go.transform.position.x-2, go.transform.position.y+ 2, go.transform.position.z);// go.transform.position;

            cloudsList[i] = go.transform;
        }

    }
    void InitBases()
    {
        baseNum = cartsParent.childCount;
        Debug.Log("carts " + baseNum);
        bases = new Transform[baseNum];
        int i = 0;
        foreach (Transform child in cartsParent)
        {
            bases[i++] = child;
            Debug.Log(i + " x: " + child.position.x + " y: " + child.position.y + " z: " + child.position.z);
        }

    }

    void FillMatsForChildren(ref GameObject go)
    {/*
        Material cart = go.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material;
        cart = M_CartColors.carts[0].darkMat;

        */
        Transform cart = go.transform.GetChild(0);
        int rand = Random.Range(0, M_CartColors.listLen);
        int i = 0;
        /*
        for(int j = 0; j < 3; j++)
        {
            if (i == 0)//dark
            {
                mats[j].color = M_CartColors.carts[rand].dark;
            }
            else if (i == 1)//mid
            {
                mats[j].color = M_CartColors.carts[rand].mid;
            }
            else//light
            {
                mats[j].color = M_CartColors.carts[rand].light;
            }
            
        }
        */
        foreach(Transform child in cart)
        {

            foreach (Transform comp in child)
            {
                Material compMat = comp.GetComponent<Renderer>().material;

        if (i == 0)//dark
            {
                    //Debug.Log(M_CartColors.carts[0].dark);
                compMat.color = M_CartColors.carts[rand].dark;
                    // compMat.SetColor("_BaseColor", Color.red);
                }
            else if (i == 1)//mid
            {
                compMat.color = M_CartColors.carts[rand].mid;
            }
            else//light
            {
                compMat.color = M_CartColors.carts[rand].light;
            }
                    
            }
            i++;
        }
    }

    void SpawnCarts()
    {
        Vector3 preGO = cartSpawnPoint.position;
        for(int i = 0; i < numberOfCarts; i++)
        {

            GameObject go = Instantiate(cartPrefab, cartParent);
            

            FillMatsForChildren(ref go);

            go.name = (i + 1).ToString();

            go.transform.position = preGO;
            cartList[i] = go.transform;
            cartsList.Add(go.transform);
            preGO = new Vector3(preGO.x,preGO.y,preGO.z+cartSpaceing);
        }
        //cartsList.Reverse();
    }

   Vector3 CenterCamera(List<Transform> transformCarts)
    {
        int len = transformCarts.Count;
        float avgZ = 0;
        for (int i = 0; i < len; i++)
        {
            avgZ+=transformCarts[i].position.z;
            Debug.Log(avgZ);
        }
        avgZ /= len;
        if (len == 1)
        {

        }else if(len == 2)
        {

        }
        else
        {
            //avgZ -= threeCartOffset;
        }
        doCenter = true;
        return new Vector3(cameraPivot.position.x, cameraPivot.position.y, avgZ);
    }

    void RandomizePuzzle(int start,int end)
    {
        int i = start;
        int cnt = 0;
        while (i < end)
        {
            int rand = Random.Range(start, end);
            if (!posMap[rand])
            {
                Debug.Log("once");
                posMap[rand] = true;
                randomPosition[i] = cloudsList[rand].position;
                i++;
            }
        }
    }

    void randomClouds(int start,int end)
    {
        RandomizePuzzle(start, end);
        //Debug.Log("start : " + start + " end : " + end);
        Transform[] pos = new Transform[end - start];
        for(int i = start; i < end; i++)
        {
            cloudsList[i].position = randomPosition[i];
        }
    }

    void InitCameraPosition()
    {
        List < Transform > newCartList = new List<Transform>();
        int cnt = 0;
        int len = cartsList.Count;
        if (reachedIndex < len)
        {

            int start = reachedIndex;
            for (int i = reachedIndex; i < len && cnt < 3; i++)
            {
                newCartList.Add(cartsList[i]);
                Debug.Log("cart added" + cartsList[i].position + " cart num : " + i);
                cnt++;
                reachedIndex = i + 1;
            }
            randomClouds(start, reachedIndex);
            newCamPosition = CenterCamera(newCartList);
            Debug.Log("position set current :" + cameraPivot.position + " new : " + newCamPosition);
        }
        else
        {
            newCamPosition = baseCamPosition;
            doCenter = true;
        }
    }


    public Transform CalculateDistances(Transform target, ref string place)
    {
        double minDist = 999999999;
        int minI = -1;
        for (int i = 0; i < baseNum; i++)
        {
            double dist = Vector3.Distance(target.transform.localPosition, bases[i].transform.localPosition);
            if (dist <= 0.05f)
            {
                minDist = dist;
                minI = i;
            }
            //bases[i].GetChild(0).gameObject.SetActive(false);
        }
        if (minI != -1)
        {
            Debug.Log("closest is " + bases[minI].name);
            place = bases[minI].name;
            return bases[minI];
            bases[minI].GetChild(0).gameObject.SetActive(true);
        }
        else
            Debug.Log("closest is none");
        return null;
    }

    void UpdateCameraPos()
    {
        if (doCenter)
        {
            cameraPivot.position = Vector3.MoveTowards(cameraPivot.position, newCamPosition, cameraMoveSpeed * Time.deltaTime);
            if (Vector3.Distance(cameraPivot.position, newCamPosition) <= 0.01f)
            {
                //InitCameraPosition();
                doCenter = false;
            }
        }
    }

    void MoveToNextSection()
    {
        InitCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPos();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToNextSection();
        }

    }
}

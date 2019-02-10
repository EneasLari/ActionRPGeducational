using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BuildCity : MonoBehaviour
{

    public GameObject[] buldings;
    private char[,] mapGrid;

    public GameObject corneRoadRtop; public char corneRoadRtopID = '<';
    public GameObject corneRoadLtop; public char corneRoadLtopID = '>';
    public GameObject corneRoadRdn; public char corneRoadRdnID= ']';
    public GameObject corneRoadLdn; public char corneRoadLdnID = '[';
    public GameObject crossRoad; public char crossRoadID = '+';
    public GameObject tafRRoad; public char tafRRoadID = '{';
    public GameObject tafLRoad; public char tafLRoadID = '}';
    public GameObject tafUpRoad; public char tafUpRoadID = '^';
    public GameObject tafDownRoad; public char tafDownRoadID = '_';
    public GameObject xRoad; public char xRoadID = '=';
    public GameObject zRoad; public char zRoadID = '|';

    public string mapTxtFileName = "fileEneas.txt";
    public int seed = 100;//UnityEngine.Random.Range(0,100);
    public int mapWidth = 30;
    public int mapHeight = 30;
    private int envObjectFootprint = 3;

    // Use this for initialization
    void Start()
    {
        mapGrid = new char[mapWidth, mapHeight];
        readDataFromFile(mapTxtFileName);
        InstantiateRoads();
        RandomBuildings();
    }


    private void RandomBuildings()
    {
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapGrid[h, w] == '#' || h == mapHeight - 1 || w == mapWidth - 1 || h == 0 || w == 0) {
                    int result = (int)(Mathf.PerlinNoise(w / 10f + seed, h / 10f + seed) * 22);
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    if (h == mapHeight-1 || w == mapWidth-1 || h==0 || w==0) {
                        GameObject inst = Instantiate(buldings[9], pos, Quaternion.identity);
                        inst.transform.localScale = new Vector3(envObjectFootprint + .15f, inst.transform.localScale.y, envObjectFootprint + .15f);
                    }
                    else if (result < 3)
                    {
                        Instantiate(buldings[0], pos, Quaternion.identity);
                    }
                    else if (result < 4)
                    {
                        Instantiate(buldings[1], pos, Quaternion.identity);
                    }
                    else if (result < 6)
                    {
                        Instantiate(buldings[2], pos, Quaternion.identity);
                    }
                    else if (result < 8)
                    {
                        Instantiate(buldings[3], pos, Quaternion.identity);
                    }
                    else if (result < 10)
                    {
                        Instantiate(buldings[4], pos, Quaternion.identity);
                    }
                    else if (result < 12)//pezodromos
                    {
                        GameObject inst = Instantiate(buldings[5], pos, Quaternion.identity);
                        inst.transform.localScale = new Vector3(envObjectFootprint + .15f, inst.transform.localScale.y, envObjectFootprint + .15f);
                    }
                    else if (result < 14)
                    {
                        Instantiate(buldings[6], pos, Quaternion.identity);
                    }
                    else if (result < 16)
                    {
                        Vector3 pos2 = new Vector3(w * envObjectFootprint, 0.28f, h * envObjectFootprint);//for the trees only
                        GameObject inst = Instantiate(buldings[7], pos2, Quaternion.identity);
                        inst.transform.localScale = new Vector3(envObjectFootprint, inst.transform.localScale.y, envObjectFootprint);
                    }
                    else if (result < 22)
                    {
                        Instantiate(buldings[8], pos, Quaternion.identity);
                    }
                }
            }
        }
    }
    private void InstantiateRoads()
    {
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                if (mapGrid[h, w] == corneRoadRtopID)
                {
                    //croner road from down to right
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(corneRoadRtop, pos, corneRoadRtop.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == corneRoadLtopID)
                {
                    //corner road from down to left
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(corneRoadLtop, pos, corneRoadLtop.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == corneRoadRdnID)
                {
                    //corner road from up to left
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(corneRoadRdn, pos, corneRoadRdn.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == corneRoadLdnID)
                {
                    //corner road from up to right
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(corneRoadLdn, pos, corneRoadLdn.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x*envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == crossRoadID)
                {
                    //crossroad
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(crossRoad, pos, corneRoadRtop.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == tafRRoadID)
                {
                    //taf road to right
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(tafRRoad, pos, tafRRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == tafLRoadID)
                {
                    //taf road to left
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(tafLRoad, pos, tafLRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == tafUpRoadID)
                {
                    //taf road to up z axis
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(tafUpRoad, pos, tafUpRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == tafDownRoadID)
                {
                    //taf road to up z axis
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(tafDownRoad, pos, tafDownRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }

                if (mapGrid[h, w] == xRoadID)
                {
                    //road parallel to x axis
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(xRoad, pos, xRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }
                if (mapGrid[h, w] == zRoadID)
                {
                    //road parallel to z axis
                    Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                    GameObject inst = Instantiate(zRoad, pos, zRoad.transform.rotation);
                    inst.transform.localScale = new Vector3(inst.transform.localScale.x * envObjectFootprint, inst.transform.localScale.y, inst.transform.localScale.z * envObjectFootprint);
                }

               

            }
        }
    }

    private void readDataFromFile(string fileName) {
        try
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                int h = 0; int w = 0;
                while (!streamReader.EndOfStream && h<mapHeight)
                {
                    string line = streamReader.ReadLine();
                    foreach (char ch in line) {
                        if (ch != ' ' && ch!='\t') {
                            if (w < mapWidth) {
                                mapGrid[mapHeight-h-1, w] = ch;
                                w++;
                            }          
                        }
                    }
                    w = 0;
                    h++;
                }
                streamReader.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log("The process failed: {0}"+ e.ToString());
        }
       
    }

    
}

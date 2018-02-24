using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BuildCity : MonoBehaviour {

    //public GameObject[] buldings;
    private int[,] mapGrid;
    public GameObject corneRoadRtop;//1
    public GameObject corneRoadLtop;//2
    public GameObject corneRoadRdn;//3
    public GameObject corneRoadLdn;//4
    public GameObject xRoad;//5
    public GameObject zRoad;//6
    public GameObject crossRoad;//7
    public GameObject tafRRoad;//8
    public GameObject tafLRoad;//9
    public GameObject tafUpRoad;//10
    public GameObject tafDownRoad;//11
    private int numofRoads = 7;
    public int mapWidth = 30;
    public int mapHeight = 30;
    private int area;
    public float RoadsDensity = 10;
    [Range(0, 100)]
    private int envObjectFootprint = 2;


    // Use this for initialization
    void Start() {
        mapGrid = new int[mapWidth,mapHeight];
        for (int h = 0; h < mapHeight; h++) {
            for (int w = 0; w < mapWidth; w++) {
                //Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                //int n = Random.Range(0, buldings.Length);
                //Instantiate(buldings[n], pos, Quaternion.identity);
            }
        }

        LoadRoadsFromText("fileEneas.txt");
        InstantiateRoads();
    }


    private void InstantiateRoads() { 
            for (int h = 0; h < mapHeight; h++)
            {
                for (int w = 0; w < mapWidth; w++)
                {
                    if (mapGrid[h, w] == 1)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(corneRoadRtop, pos, corneRoadRtop.transform.rotation);
                    }
                    if (mapGrid[h, w] == 2)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(corneRoadLtop, pos, corneRoadLtop.transform.rotation);
                    }
                    if (mapGrid[h, w] == 3)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(corneRoadRdn, pos, corneRoadRdn.transform.rotation);
                    }
                    if (mapGrid[h, w] == 4)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(corneRoadLdn, pos, corneRoadLdn.transform.rotation);
                    }
                    if (mapGrid[h,w]==5) {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(xRoad, pos,xRoad.transform.rotation);
                    }
                    if (mapGrid[h, w] == 6)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(zRoad, pos, zRoad.transform.rotation);
                    }

                    if (mapGrid[h, w] == 7)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(crossRoad, pos, corneRoadRtop.transform.rotation);
                    }
                    if (mapGrid[h, w] == 8)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(tafRRoad, pos, tafRRoad.transform.rotation);
                    }
                    if (mapGrid[h, w] == 9)
                    {
                        Vector3 pos = new Vector3(w * envObjectFootprint, 0.5f, h * envObjectFootprint);
                        Instantiate(tafLRoad, pos, tafLRoad.transform.rotation);
                    }
                }
            }  
    }

    private bool LoadRoadsFromText(string fileName)
    {
        StreamReader inpStream = new StreamReader(fileName);
        int h = 0; int w=0;
        while (!inpStream.EndOfStream && h < mapHeight)
        {
            string line = inpStream.ReadLine();
            string[] entries = line.Split(' ');
            while (w<mapWidth && w<entries.Length) {
                print(entries[w]);
                mapGrid[mapHeight-h-1, w] = System.Int32.Parse(entries[w]);
                w++;
            }
            w = 0;
            h++;

             
        }

        inpStream.Close();
        return true;
    }


    private void BuildGrid() {
        int x = Random.Range(0, mapWidth);
        int z = Random.Range(0, mapHeight);
        int roadintersection = 8;// Random.Range(8,12);
        int cornerRoad = Random.Range(1, 5);

        mapGrid[z, x] = roadintersection;
        if (roadintersection==8) {//An einai T pou koitaei deksia,proekteine ta akra
            int tempx = x+1;
            int tempz = z;
            while (tempx < mapWidth) {

                if (mapGrid[tempz, tempx] == 6)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else if (mapGrid[tempz, tempx] == 5)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else {
                    mapGrid[tempz, tempx] = 5;
                }
                
                tempx++;
            }
            tempx = x;
            tempz++;
            while (tempz < mapHeight)
            {
                if (mapGrid[tempz, tempx] == 5)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else if (mapGrid[tempz, tempx] == 6)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else
                {
                    mapGrid[tempz, tempx] = 6;
                }
                tempz++;
            }
            tempz = z-1;
            while (tempz > 0)
            {
                if (mapGrid[tempz, tempx] == 5)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else if (mapGrid[tempz, tempx] == 6)
                {
                    mapGrid[tempz, tempx] = 7;
                }
                else
                {
                    mapGrid[tempz, tempx] = 6;
                }
                tempz--;
            }
        }

    }
}

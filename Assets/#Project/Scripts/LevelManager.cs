using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //les 3 dont on a besoin pour la save par ex

[Serializable]
public class GameData
{
    public int AshColor;
    public int[] CubesColor;
    public float[] ashPosition = new float[3];
}
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public void Save()
    {
        FileStream file = File.Create(Application.persistentDataPath + "/data.dat");
        try
        {
            BinaryFormatter  bf = new BinaryFormatter();

            GameData data = new GameData();
            AshBehaviour ash = FindObjectOfType<AshBehaviour>();
            data.AshColor = ash.colorIndex;
            data.ashPosition[0] = ash.transform.position.x;
            data.ashPosition[1] = ash.transform.position.y;
            data.ashPosition[2] = ash.transform.position.y;

            CubeBehaviour[] cubes = FindObjectsOfType<CubeBehaviour>();
            data.CubesColor = new int[cubes.Length];
            for (int i=0; i < cubes.Length; i++)
            {
                data.CubesColor[i] = cubes[i].colorIndex;
            }

            bf.Serialize(file, data);
        }
        finally
        {
            file.Close();
        }
    }
    void Start()
    {
        if (instance == null)
        {
            instance = this; //instance == LevelManager
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Save();
            Application.Quit();
        }
    }

    public void Initialize(GameData data=null)
    {
        GameData

        AshBehaviour ash = FindObjectOfType<AshBehaviour>().Initialize();

        CubeBehaviour[] cubes = FindObjectsOfType<CubeBehaviour>();
        for(int i=0; i < cubes.Length; i++)
        {
            cubes[i].Initialize();
        }
    }
}

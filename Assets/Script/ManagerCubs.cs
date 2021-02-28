using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerChess : MonoBehaviour
{
    public List<GameObject> PoolPoints;
    public GameObject Cub;
    int[,] arr;
    int[,,] arr3D;
    public int StartCoordinata_X;
    public int StartCoordinata_Z;
    public int StartCoordinata_Y;
    float step_ZBlack;
    float step_XBlack;
    float step_ZWhite;
    float step_XWhite;
    float step3D_XBlack;
    float step3D_YBlack;
    float step3D_ZBlask;
    float step3D_XWhite;
    float step3D_YWhite;
    float step3D_ZWhite;
    public int Shirina_x;
    public int Visota_z;
    public int Hlibina_y;

    void Start()
    {
        arr = new int[Shirina_x, Visota_z];
        arr3D = new int[Shirina_x, Hlibina_y, Visota_z];
        PoolPoints = new List<GameObject>();
        for (int i = 0; i < Shirina_x * Visota_z * Hlibina_y; i++)
        {
            GameObject CloneCub = Instantiate(Cub);
            CloneCub.transform.position = new Vector3(-100, -100, -100);
            PoolPoints.Add(CloneCub);

        }

        step_ZBlack = Cub.transform.localScale.z;
        step_XBlack = Cub.transform.localScale.x;
        step_ZWhite = Cub.transform.localScale.z;
        step_XWhite = Cub.transform.localScale.x;
        step3D_XBlack = Cub.transform.localScale.x;
        step3D_YBlack = Cub.transform.localScale.y;
        step3D_ZBlask = Cub.transform.localScale.z;
        step3D_XWhite = Cub.transform.localScale.x;
        step3D_YWhite = Cub.transform.localScale.y;
        step3D_ZWhite = Cub.transform.localScale.z;
    }
    void Update()
    {

    }
    void SetCubes()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                arr[i, j] = 0;

            }
        }
    }
    void SetCubeChessDesk()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if ((j % 2 == 0 && i % 2 == 0) || (j % 2 != 0 && i % 2 != 0))
                {
                    arr[i, j] = 1;
                }

                else
                {
                    arr[i, j] = 0;
                }
            }
        }
    }
    void SetCubeChessDesk3D()
    {
        for (int x = 0; x < Shirina_x; x++)
        {
            for (int y = 0; y < Hlibina_y; y++)
            {
                for (int z = 0; z < Visota_z; z++)
                {
                    if ((x % 2 == 0 && y % 2 == 0 && z % 2 == 0) || (x % 2 != 0 && y % 2 != 0 && z % 2 == 0) || (x % 2 == 0 && y % 2 != 0 && z % 2 != 0) || (x % 2 != 0 && y % 2 == 0 && z % 2 != 0))
                    {
                        arr3D[x, y, z] = 1;
                    }
                    else
                    {
                        arr3D[x, y, z] = 0;
                    }
                }
            }
        }

    }
    void SetCubePart1()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if (i >= Shirina_x / 2 && j >= Visota_z / 2)
                {
                    arr[i, j] = 1;
                }


                else
                {
                    arr[i, j] = 0;
                }
            }
        }
    }
    void SetCubePart2()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if (i < Shirina_x / 2 && j >= Visota_z / 2)
                {
                    arr[i, j] = 1;
                }


                else
                {
                    arr[i, j] = 0;
                }
            }
        }
    }
    void SetCubePart3()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if (i < Shirina_x / 2 && j < Visota_z / 2)
                {
                    arr[i, j] = 1;
                }


                else
                {
                    arr[i, j] = 0;
                }
            }
        }
    }
    void SetCubePart4()
    {
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if (i >= Shirina_x / 2 && j < Visota_z / 2)
                {
                    arr[i, j] = 1;
                }


                else
                {
                    arr[i, j] = 0;
                }
            }
        }
    }
    void PrintCubes()
    {
        foreach (GameObject cube in PoolPoints)
        {
            cube.transform.position = new Vector3(-100, -100, -100);
        }
        int k = 0;
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if (arr[i, j] == 1)
                {
                    GameObject Cub = PoolPoints[k];
                    Cub.transform.position = new Vector3(i * step_XBlack + StartCoordinata_X, 0, j * step_ZBlack + StartCoordinata_Z);
                    Cub.GetComponent<MeshRenderer>().material.color = Color.black;


                }
                else
                {
                    GameObject Cub = PoolPoints[k];
                    Cub.transform.position = new Vector3(i * step_XWhite + StartCoordinata_X, 0, j * step_ZWhite + StartCoordinata_Z);
                    Cub.GetComponent<MeshRenderer>().material.color = Color.white;

                }
                k++;
            }
        }
    }
    void PrintCubesCarcas()
    {
        foreach (GameObject cube in PoolPoints)
        {
            cube.transform.position = new Vector3(-100, -100, -100);
        }
        int k = 0;
        for (int i = 0; i < Shirina_x; i++)
        {
            for (int j = 0; j < Visota_z; j++)
            {
                if ((arr[i, j] == 1) && (i == 0 || j == 0 || i == Shirina_x - 1 || j == Visota_z - 1))
                {
                    GameObject Cub = PoolPoints[k];
                    Cub.transform.position = new Vector3(i * step_XBlack + StartCoordinata_X, 0, j * step_ZBlack + StartCoordinata_Z);
                    Cub.GetComponent<MeshRenderer>().material.color = Color.black;


                }
                if ((arr[i, j] == 0) && (i == 0 || j == 0 || i == Shirina_x - 1 || j == Visota_z - 1))
                {
                    GameObject Cub = PoolPoints[k];
                    Cub.transform.position = new Vector3(i * step_XWhite + StartCoordinata_X, 0, j * step_ZWhite + StartCoordinata_Z);
                    Cub.GetComponent<MeshRenderer>().material.color = Color.white;

                }
                k++;
            }
        }
    }
    void PrintCubes3D()
    {
        foreach (GameObject cube in PoolPoints)
        {
            cube.transform.position = new Vector3(-100, -100, -100);
        }
        int k = 0;
        for (int x = 0; x < Shirina_x; x++)
        {
            for (int y = 0; y < Hlibina_y; y++)
            {
                for (int z = 0; z < Visota_z; z++)
                {

                    if (arr3D[x, y, z] == 1)
                    {
                        GameObject Cub = PoolPoints[k];
                        Cub.transform.position = new Vector3(x * step3D_XBlack + StartCoordinata_X, y * step3D_YBlack + StartCoordinata_Y, z * step3D_ZBlask + StartCoordinata_Z);
                        Cub.GetComponent<MeshRenderer>().material.color = Color.black;
                    }
                    else
                    {
                        GameObject Cub = PoolPoints[k];
                        Cub.transform.position = new Vector3(x * step3D_XWhite + StartCoordinata_X, y * step3D_YWhite + StartCoordinata_Y, z * step3D_ZWhite + StartCoordinata_Z);
                        Cub.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    k++;
                }
            }
        }

    }
    void PrintCubesCarcas3D()
    {
        foreach (GameObject cube in PoolPoints)
        {
            cube.transform.position = new Vector3(-100, -100, -100);
        }
        int k = 0;
        for (int x = 0; x < Shirina_x; x++)
        {
            for (int y = 0; y < Hlibina_y; y++)
            {
                for (int z = 0; z < Visota_z; z++)
                {
                    if ((arr3D[x, y, z] == 1) && (z == 0 && x == Shirina_x - 1 || z == 0 && y == Hlibina_y - 1 || z == Visota_z - 1 && x == Shirina_x - 1 || z == Visota_z - 1 && y == Hlibina_y - 1
                        || x == 0 && y == Hlibina_y - 1 || x == 0 && z == Visota_z - 1 || x == Shirina_x - 1 && z == Visota_z - 1 || x == Shirina_x - 1 && y == Hlibina_y - 1
                        || y == 0 && z == Visota_z - 1 || y == 0 && x == Shirina_x - 1 || y == Hlibina_y - 1 && z == Visota_z - 1 || y == Hlibina_y - 1 && x == Shirina_x - 1
                        || x == 0 && y == 0 || x == 0 && z == 0 || y == 0 && z == 0))
                    {
                        GameObject Cub = PoolPoints[k];
                        Cub.transform.position = new Vector3(x * step3D_XBlack + StartCoordinata_X, y * step3D_YBlack + StartCoordinata_Y, z * step3D_ZBlask + StartCoordinata_Z);
                        Cub.GetComponent<MeshRenderer>().material.color = Color.black;
                    }
                    if ((arr3D[x, y, z] == 0) && (z == 0 && x == Shirina_x - 1 || z == 0 && y == Hlibina_y - 1 || z == Visota_z - 1 && x == Shirina_x - 1 || z == Visota_z - 1 && y == Hlibina_y - 1
                        || x == 0 && y == Hlibina_y - 1 || x == 0 && z == Visota_z - 1 || x == Shirina_x - 1 && z == Visota_z - 1 || x == Shirina_x - 1 && y == Hlibina_y - 1
                        || y == 0 && z == Visota_z - 1 || y == 0 && x == Shirina_x - 1 || y == Hlibina_y - 1 && z == Visota_z - 1 || y == Hlibina_y - 1 && x == Shirina_x - 1
                        || x == 0 && y == 0 || x == 0 && z == 0 || y == 0 && z == 0))
                    {
                        GameObject Cub = PoolPoints[k];
                        Cub.transform.position = new Vector3(x * step3D_XWhite + StartCoordinata_X, y * step3D_YWhite + StartCoordinata_Y, z * step3D_ZWhite + StartCoordinata_Z);
                        Cub.GetComponent<MeshRenderer>().material.color = Color.white;
                    }
                    k++;

                }
            }
        }

    }


    public void CubikiProsto()
    {
        SetCubes();
        PrintCubes();
    }
    public void CubikiChessDesk()
    {
        SetCubeChessDesk();
        PrintCubes();
    }
    public void CubikiChessDesk3D()
    {
        SetCubeChessDesk3D();
        PrintCubes3D();
    }
    public void CubikiBlackPart1()
    {
        SetCubePart1();
        PrintCubes();
    }
    public void CubikiBlackPart2()
    {
        SetCubePart2();
        PrintCubes();
    }
    public void CubikiBlackPart3()
    {
        SetCubePart3();
        PrintCubes();
    }
    public void CubikiBlackPart4()
    {
        SetCubePart4();
        PrintCubes();
    }
    public void CubikiChessCarcas()
    {
        SetCubeChessDesk();
        PrintCubesCarcas();
    }
    public void CubikiChessCarcas3D()
    {
        SetCubeChessDesk3D();
        PrintCubesCarcas3D();
    }
}







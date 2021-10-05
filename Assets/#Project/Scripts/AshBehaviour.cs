using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class AshBehaviour : MonoBehaviour
{
    public Material[] materials;
    private NavMeshAgent agent;
    private CubeBehaviour cubeDestination;

    public int colorIndex;
    public bool loaded = false;



    public void Initialize()
    {
        if (materials == null || materials.Length < 4)
        {
            Debug.LogError("This component need 4 materials", gameObject);
        }
        else
        {
            if (!loaded) 
                colorIndex = UnityEngine.Random.Range(0, 3);
            GetComponent<Renderer>().material = materials[colorIndex];
        }


        agent = GetComponent<NavMeshAgent>(); //ne pas oublier d'appeller agent au start!!

    }

    public void SetDestination(CubeBehaviour cube)
    {
        agent.SetDestination(cube.transform.position);
        cubeDestination = cube;
    }

    private void ChangeColors()
    {
        int exchange = colorIndex;
        colorIndex = cubeDestination.colorIndex;
        cubeDestination.colorIndex = exchange;

        GetComponent<Renderer>().material = materials[colorIndex];
        cubeDestination.GetComponent<Renderer>().material = materials[cubeDestination.colorIndex]; //un simple changement de variables de A � B passant par C (qui est mat)

    }

    void Update()
    {
        if (cubeDestination != null)
        {
            if (Vector3.Distance(cubeDestination.transform.position, transform.position) < 0.5f)
            {
                ChangeColors();
                cubeDestination = null;
            }

        }
    }








}

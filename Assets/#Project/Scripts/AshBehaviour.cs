using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class AshBehaviour : MonoBehaviour
{
    public GameObject ashObject;
    public Material greenMaterial;
    public Material purpleMaterial;
    public Material blueMaterial;
    private int rando;

    public List<Transform> targets = new List<Transform>();
    private int index = -1;
    private NavMeshAgent agent;

    public UnityEvent whenKeyIsPressed;


    void Start()
    {
        rando = Random.Range(0, 3);
        Randomisation();


        Debug.Log(rando);

        agent = GetComponent<NavMeshAgent>();
        NextDestination();

    }

    void Update()
    {

        NextDestination();


        if (Input.anyKeyDown)
        {
            whenKeyIsPressed?.Invoke();
        }
    }

    public void NextDestination()
    {
        index = (index + 1);
        agent.SetDestination(targets[index].position);
    }


    void Randomisation()
    {
        if (rando == 0)
        {
            ashObject.GetComponent<Renderer>().material = greenMaterial;

        }
        if (rando == 1)
        {
            ashObject.GetComponent<Renderer>().material = purpleMaterial;

        }
        if (rando == 2)
        { ashObject.GetComponent<Renderer>().material = blueMaterial; }
    }



}

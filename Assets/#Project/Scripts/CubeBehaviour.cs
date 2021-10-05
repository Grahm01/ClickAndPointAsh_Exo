using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeBehaviour : MonoBehaviour
{
    public AshBehaviour ash;
    public int colorIndex;
    public bool loaded = false;

    // Start is called before the first frame update
    public void Initialize()
    {   if (!loaded)
            colorIndex = Random.Range(0, 4);

        if (ash == null)
        {
            ash = FindObjectOfType<AshBehaviour>();

        }

        Material mat = ash.materials[colorIndex];
        GetComponent<Renderer>().material = mat;  


    }

    private void OnMouseDown()
    {
        ash.SetDestination(this);
       // Debug.Log("click");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

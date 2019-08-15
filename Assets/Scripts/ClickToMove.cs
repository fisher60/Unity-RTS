using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{

    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    public bool selected;
    
    
   

    // Use this for initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        selected = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && this.selected == true)
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelect : MonoBehaviour
{

    #region fucking variables
    [SerializeField]
    private LayerMask clickableLayer;
    private bool selected;
    private GameObject lastSelected;
    private List<GameObject> selectedObjects;
    public bool working = false;
    #endregion

    Ray ray;
    RaycastHit hit;

    void Start()
    {
        selectedObjects = new List<GameObject>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                ClickToMove clickedOn = hit.collider.GetComponent<ClickToMove>();
                //if (clickedOn.selected == false)
                //{
                    selectedObjects.Add(hit.collider.gameObject);
                    lastSelected = hit.collider.gameObject;
                    clickedOn.selected = true;
                    //Multi-select
                    if (Input.GetKey("left shift"))
                    {
                        selectedObjects.Add(hit.collider.gameObject);
                        clickedOn.selected = true;
                    }
                    else
                    {
                         
                        // Select a single object and deselect others
                        foreach (var obj in selectedObjects)
                        {
                            if (!obj.Equals(lastSelected))
                            {
                                obj.GetComponent<ClickToMove>().selected = false;
                            }
                        }
                        selectedObjects.Clear();
                        selectedObjects.Add(lastSelected);
                    }
                //}
                //else
                //{
                //    selectedObjects.Add(hit.collider.gameObject);
                //    lastSelected = hit.collider.gameObject;
                //    clickedOn.selected = true;
                //}

                //If you have multiple units selected deselect a single unit that has been clicked on
                if (clickedOn.selected == true && Input.GetKey("left ctrl"))
                {
                    selectedObjects.Remove(hit.collider.gameObject);
                    clickedOn.selected = false;
                }
            }
            DeselectOnGroundClick();
        }
    }

    public void DeselectOnGroundClick()
    {
        //Clicking the ground deselects everything
        if (selectedObjects.Count > 0 && !Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
        {
            foreach (GameObject obj in selectedObjects)
            {
                obj.GetComponent<ClickToMove>().selected = false;
                working = true;
            }
            selectedObjects.Clear();
        }
    }

    //public void SelectSingleWhenMultiSelect()
    //{
    //    if (selectedObjects.Count > 1 && Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
    //    {
    //        if (selectedObjects.Contains(hit.collider.gameObject))
    //        {
    //            foreach (GameObject obj in selectedObjects)
    //            {
    //                obj.GetComponent<ClickToMove>().selected = false;
    //                working = true;
    //            }
    //        }
    //        selectedObjects.Clear();
    //    }
    //}
}

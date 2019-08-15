using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingHandler : MonoBehaviour
{
    [SerializeField]
    private City city;
    [SerializeField]
    private UIController uiController;
    [SerializeField]
    private Building[] buildings;
    [SerializeField]
    private Board board;
    private Building selectedBuilding;
    private Building building;
    private barracksSpawn barracks;

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetMouseButton(1))
            {
                selectedBuilding = null;
            }
            if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedBuilding != null)
            {
                InteractWithBoard(0);
            }
            else if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
            {
                InteractWithBoard(0);
                selectedBuilding = null;
            }
            if (Input.GetMouseButtonDown(1))
            {
                InteractWithBoard(1);
            }
        }
    }

    void InteractWithBoard(int action)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 gridPosition = board.CalculateGridPosition(hit.point);
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (board.CheckForBuildingAtPosition(gridPosition) == null)
                {
                    if (action == 0 && city.Cash >= selectedBuilding.cost)
                    {
                        city.DepositCash(-selectedBuilding.cost);
                        uiController.UpdateCityData();
                        city.buildingCounts[selectedBuilding.id]++;
                        board.AddBuilding(selectedBuilding, gridPosition);
                    }
                }
                else if (board.CheckForBuildingAtPosition(gridPosition) != null)
                {
                    if (Input.GetKey(KeyCode.LeftShift) && action == 1)
                    {
                        city.DepositCash(board.CheckForBuildingAtPosition(gridPosition).cost / 2);
                        city.buildingCounts[board.CheckForBuildingAtPosition(gridPosition).id]--;
                        board.RemoveBuilding(gridPosition);
                        uiController.UpdateCityData();
                    }
                    else if (action == 0)
                    {
                        Debug.Log("spawn buildinghandler line 73");
                        barracks.spawn();
                    }
                }
                
            }
        }
    }
    public void EnableBuilder(int building)
    {
        selectedBuilding = buildings[building];
        Debug.Log("Selected building: " + selectedBuilding.buildingName);
    }
}

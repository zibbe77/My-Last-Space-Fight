using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipTargetSet : MonoBehaviour
{
    SelectionTracker selectionTracker;
    private void Start()
    {
        selectionTracker = Camera.main.GetComponent<SelectionTracker>();
    }
    private void Update()
    {
        CheckIfShipSelected();
    }
    public void CheckIfShipSelected()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //skapar ett target för skepen att röra sig mot
            Vector3 targetPosition = TargetSet();

            foreach (KeyValuePair<int, GameObject> pair in selectionTracker.selectedTable)
            {
                if (pair.Value.gameObject.layer == 6)
                {
                    ShipMove shipMove = pair.Value.gameObject.GetComponent<ShipMove>();
                    shipMove.MoveShip(targetPosition);
                }
            }
        }

    }
    public Vector3 TargetSet()
    {
        Vector3 targetPosition = Vector3.down;
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (plane.Raycast(ray, out float enter))
        {
            targetPosition = ray.GetPoint(enter);
        }

        return targetPosition;
    }
}

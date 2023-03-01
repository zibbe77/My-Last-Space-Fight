using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalSelection : MonoBehaviour
{
    SelectionTracker selectionTracker;
    RaycastHit hit;
    private Vector2 p1;
    private Vector3 p2;

    bool dragSelect;

    void Start()
    {
        selectionTracker = GetComponent<SelectionTracker>();
        dragSelect = false;
        print("Start");
    }
    void Update()
    {
        OnClick();
    }

    private void OnClick()
    {
        //1
        if (!Mouse.current.middleButton.isPressed) { return; }

        p1 = Mouse.current.position.ReadValue();

        //2
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            print("2");
            if ((p1 - Mouse.current.position.ReadValue()).magnitude > 40)
            {

                dragSelect = true;
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (dragSelect == false)
            {
                print("3");
                Ray ray = Camera.main.ScreenPointToRay(p1);

                if (Physics.Raycast(ray, out hit, 5000f))
                {
                    //if hit
                    print("hit");
                    if (Keyboard.current.shiftKey.IsPressed())
                    {
                        selectionTracker.SelectedThing(hit.transform.gameObject);
                    }
                    else
                    {
                        selectionTracker.SelectedThing(hit.transform.gameObject);
                        selectionTracker.DeSelectedAllThings();
                    }
                }
                else
                {
                    if (Keyboard.current.shiftKey.IsPressed())
                    {

                    }
                    else
                    {
                        selectionTracker.DeSelectedAllThings();
                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GlobalSelection : MonoBehaviour
{
    // has all the variables 
    #region variables
    SelectionTracker selectionTracker;
    RaycastHit hit;

    MeshCollider selectionBox;
    Mesh selectionMesh;

    private Vector2 p1;
    private Vector3 p2;

    //corners of selection box
    private Vector2[] corners;
    //the vertises of the meshcolider
    private Vector3[] verts;
    private Vector3[] vecs;

    bool dragSelect;

    #endregion

    //Have all the Generally stuff and uppdates evryting
    #region Generally
    void Start()
    {
        selectionTracker = GetComponent<SelectionTracker>();
        dragSelect = false;
    }
    void Update()
    {
        OnClick();
    }
    #endregion

    //has the logic that detcts clicks 
    #region onclick 
    private void OnClick()
    {
        //1
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            p1 = Mouse.current.position.ReadValue();

        }

        //2
        if (Mouse.current.leftButton.isPressed)
        {
            if ((p1 - Mouse.current.position.ReadValue()).magnitude > 40)
            {
                dragSelect = true;
            }
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (dragSelect == false)
            {
                if (EventSystem.current.IsPointerOverGameObject()) { return; }

                Ray ray = Camera.main.ScreenPointToRay(p1);

                if (Physics.Raycast(ray, out hit, 5000f))
                {
                    //if hit
                    if (Keyboard.current.shiftKey.IsPressed())
                    {
                        selectionTracker.SelectedThing(hit.transform.gameObject, true);
                    }
                    else
                    {
                        selectionTracker.DeSelectedAllThings();
                        selectionTracker.SelectedThing(hit.transform.gameObject, false);
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
            else
            {
                //This creats the select box
                verts = new Vector3[4];
                vecs = new Vector3[4];

                int i = 0;
                p2 = Mouse.current.position.ReadValue();
                corners = getBoundingBox(p1, p2);

                foreach (Vector2 corner in corners)
                {
                    Ray ray = Camera.main.ScreenPointToRay(corner);

                    if (Physics.Raycast(ray, out hit, 5000.0f, (1 << 8)))
                    {
                        verts[i] = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        vecs[i] = ray.origin - hit.point;
                        Debug.DrawLine(Camera.main.ScreenToViewportPoint(corner), hit.point, Color.red, 1.0f);
                    }
                    i++;
                }

                //generate mesh
                selectionMesh = generateSelectionMesh(verts, vecs);

                selectionBox = gameObject.AddComponent<MeshCollider>();
                selectionBox.sharedMesh = selectionMesh;
                selectionBox.convex = true;
                selectionBox.isTrigger = true;

                if (!Keyboard.current.shiftKey.IsPressed())
                {
                    selectionTracker.DeSelectedAllThings();
                }

                Destroy(selectionBox, 0.02f);
            }

            dragSelect = false;
        }
    }
    #endregion

    //creats the select box 
    #region Creat Select box
    //create a bounding box (4 corners in order) from the start and end mouse position
    Vector2[] getBoundingBox(Vector2 p1, Vector2 p2)
    {
        // Min and Max to get 2 corners of rectangle regardless of drag direction.
        var bottomLeft = Vector3.Min(p1, p2);
        var topRight = Vector3.Max(p1, p2);

        // 0 = top left; 1 = top right; 2 = bottom left; 3 = bottom right;
        Vector2[] corners =
        {
            new Vector2(bottomLeft.x, topRight.y),
            new Vector2(topRight.x, topRight.y),
            new Vector2(bottomLeft.x, bottomLeft.y),
            new Vector2(topRight.x, bottomLeft.y)
        };
        return corners;

    }
    //generate a mesh from the 4 bottom points
    Mesh generateSelectionMesh(Vector3[] corners, Vector3[] vecs)
    {
        Vector3[] verts = new Vector3[8];

        //map the tris of our cube
        int[] tris = { 0, 1, 2, 2, 1, 3, 4, 6, 0, 0, 6, 2, 6, 7, 2, 2, 7, 3, 7, 5, 3, 3, 5, 1, 5, 0, 1, 1, 4, 0, 4, 5, 6, 6, 5, 7 };

        for (int i = 0; i < 4; i++)
        {
            verts[i] = corners[i];
        }

        for (int j = 4; j < 8; j++)
        {
            verts[j] = corners[j - 4] + vecs[j - 4];
        }

        Mesh selectionMesh = new Mesh();

        selectionMesh.vertices = verts;
        selectionMesh.triangles = tris;

        return selectionMesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        selectionTracker.SelectedThing(other.gameObject, false);
    }
    #endregion

    //Interfases the Utils skrip to draw the selecson box
    #region GUI 
    private void OnGUI()
    {
        if (dragSelect == true)
        {
            var rect = Utils.GetScreenRect(p1, Mouse.current.position.ReadValue());
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.9f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.25f));
        }
    }
    #endregion
}

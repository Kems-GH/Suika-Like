using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject currentObject;

    private float xBoundDefault = 5.5f;
    private float xBound;
    private Vector3 spawnPos = new Vector3(0, 4.5f, 0);


    private void Start()
    {
        currentObject = Instantiate(prefab, spawnPos, prefab.transform.rotation);
        xBound = xBoundDefault - currentObject.transform.localScale.y/2;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Mouse Drag");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if(objPosition.x > xBound)
            objPosition.x = xBound;
        if(objPosition.x < -xBound)
            objPosition.x = -xBound;
        currentObject.transform.position = new Vector3(objPosition.x, currentObject.transform.position.y, 0);
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        currentObject.GetComponent<Rigidbody2D>().simulated = true;
        currentObject = Instantiate(prefab, spawnPos, prefab.transform.rotation);
        xBound = xBoundDefault - currentObject.transform.localScale.y / 2;
    }
    
}

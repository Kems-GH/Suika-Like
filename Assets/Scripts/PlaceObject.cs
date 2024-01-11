using System.Collections;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private GameObject currentObject;

    private float xBoundDefault = 5.5f;
    private float xBound;
    private Vector3 spawnPos = new Vector3(0, 4.5f, 0);

    private float delay = 0.5f;


    private void Start()
    {
        currentObject = Instantiate(prefab, spawnPos, prefab.transform.rotation);
        xBound = xBoundDefault - currentObject.transform.localScale.y/2;
    }

    private void OnMouseDrag()
    {
        if (GameManager.instance.gameOver || currentObject == null)
            return;
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
        if (GameManager.instance.gameOver || currentObject == null) return;
        if (DeathLine.instance.HasContact())
        {
            GameManager.instance.GameOver();
            currentObject = null;
            return;
        }
        currentObject.GetComponent<Rigidbody2D>().simulated = true;
        currentObject = null;

        StartCoroutine(SpawnNewForm());
    }
   
    private IEnumerator SpawnNewForm()
    {
        yield return new WaitForSeconds(delay);
        if(currentObject == null)
        {
            currentObject = Instantiate(prefab, spawnPos, prefab.transform.rotation);
            xBound = xBoundDefault - currentObject.transform.localScale.y / 2;
        }
    }
}

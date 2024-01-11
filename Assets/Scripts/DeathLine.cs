using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    private List<GameObject> contactObjects = new List<GameObject>();

    public static DeathLine instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contactObjects.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contactObjects.Remove(collision.gameObject);
    }

    public bool HasContact()
    {
        return contactObjects.Count > 0;
    }
}

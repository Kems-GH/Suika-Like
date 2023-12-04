using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Forme : MonoBehaviour
{
    public int level { get; private set; }

    private float scale = 0.5f;

    private void Awake()
    {
        level = Random.Range(1,4);
        scale = 0.5f * level;
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Forme") && collision.gameObject.GetComponent<Forme>().level == level)
        {
            Destroy(collision.gameObject);
            level++;
            scale += 0.5f;
            gameObject.transform.localScale = new Vector3(scale, scale, 1);
        }
    }
}

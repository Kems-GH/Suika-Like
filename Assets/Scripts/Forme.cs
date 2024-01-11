using UnityEngine;

public class Forme : MonoBehaviour
{
    public int level { get; private set; }

    private float scale = 0.5f;

    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        level = Random.Range(1, 4);
        scale = 0.5f * level;
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        TryGetComponent(out spriteRenderer);
        Refresh();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.gameOver) return;
        if (collision.collider.CompareTag("Forme") && collision.gameObject.GetComponent<Forme>().level == level)
        {
            Destroy(collision.gameObject);
            level++;
            scale += 0.5f;
            gameManager.AddScore(level * 2);
            Refresh();

        }
    }

    private void Refresh()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
        spriteRenderer.color = gameManager.colors[level - 1];
    }
}

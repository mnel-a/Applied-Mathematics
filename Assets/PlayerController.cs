using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite normalSprite;
    public Sprite dangerSprite;
    public Sprite finishSprite;

    private SpriteRenderer sr;
    private Vector3 move;
    private int dangerCount = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = normalSprite;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        move = new Vector3(h, v, 0).normalized;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    public void EnterDanger()
{
    dangerCount++;
    sr.sprite = dangerSprite;
}

public void ExitDanger()
{
    dangerCount--;

    if (dangerCount <= 0)
    {
        dangerCount = 0;
        sr.sprite = normalSprite;
    }
}

    public void SetNormal() => sr.sprite = normalSprite;
    public void SetDanger() => sr.sprite = dangerSprite;
    public void SetFinish() => sr.sprite = finishSprite;
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DangerZone : MonoBehaviour
{
    public float triggerDistance = 2f;
    public float loseDistance = 0.8f;
    public float shakeAmount = 0.08f;

    private Vector3 startPos;
    private SpriteRenderer sr;
    private Color originalColor;
    private Transform player;
    private PlayerController pc;
    private bool playerInside = false;
    private bool isShaking = false;

    void Start()
    {
        startPos = transform.position;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pc = player.GetComponent<PlayerController>();
    }
    
    void StartShake()
    {
        isShaking = true;
        sr.color = Color.red;
    }

    void StopShake()
    {
        isShaking = false;
        sr.color = originalColor;
        transform.position = startPos;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        bool isNowInside = dist < triggerDistance;

        if (isNowInside && !playerInside)
        {
            playerInside = true;
            pc.EnterDanger();
             StartShake();
        }
        else if (!isNowInside && playerInside)
        {
            playerInside = false;
            pc.ExitDanger();
            StopShake();
        }

        if (isShaking)
        {
            transform.position = startPos + (Vector3)Random.insideUnitCircle * shakeAmount;
        }

        if (dist < loseDistance)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
    }
}


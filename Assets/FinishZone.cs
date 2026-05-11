using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishZone : MonoBehaviour
{
    public float winDistance = 2f;
    public GameObject winUI;

    private Transform player;
    private PlayerController pc;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pc = player.GetComponent<PlayerController>();
        winUI.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        if(dist < winDistance)
        {
            pc.SetFinish();
            winUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}

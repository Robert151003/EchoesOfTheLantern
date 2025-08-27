using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanternController : MonoBehaviour
{
    public float lanternTimer;
    public float maxTimerValue;
    public float shadowWorldDecayMultiplyer;

    public float shardValue;
    public bool shadowWorld;

    public Slider lanternTimerValue;

    private void Awake()
    {
        lanternTimerValue.maxValue = maxTimerValue;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            shadowWorld = !shadowWorld;
        }

        if (lanternTimer > maxTimerValue)
        {
            lanternTimer = maxTimerValue;
        }

        lanternTimerValue.value = lanternTimer;
    }

    private void FixedUpdate()
    {
        if (!shadowWorld)
        {
            lanternTimer -= Time.deltaTime;
        }
        else
        {
            lanternTimer -= Time.deltaTime * shadowWorldDecayMultiplyer;
        }

        if(lanternTimer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LightShard"))
        {
            lanternTimer += shardValue;
            Destroy(other.gameObject);
        }
    }
}

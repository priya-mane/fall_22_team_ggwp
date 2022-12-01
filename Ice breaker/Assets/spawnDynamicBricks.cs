using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnDynamicBricks : MonoBehaviour
{
    private int nextTime = 0;
    private int interval = 1;
    private float minX = -4.0f;
    private float maxY = 3.0f;
    private float maxX = 4.0f;
    private float minY = -3.0f;
    public GameObject redbrickPrefab;
    public GameObject bluebrickPrefab;
    public GameObject yellowbrickPrefab;
    private int maxBricks = 10;
    
    private int coin = 1;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.crushedBricks == maxBricks)
        {
            SceneManager.LoadScene("WinScreen");
        }
        if (Time.time >= nextTime)
        {
            float randomXCoordinate = Random.Range(minX, maxX);
            float randomYCoordinate = Random.Range(minY, maxY);
            Vector2 center = new Vector2(randomXCoordinate, randomYCoordinate);
            Vector2 size = new Vector2(2.0f, 2.0f);
            
            Collider2D[] hitColliders = Physics2D.OverlapBoxAll(center, size,0.0f);
            if (hitColliders.Length == 0)
            {
                int color  = Random.Range(1, 4);
                coin = coin % 2;
                
                if (color == 1)
                {
                    Instantiate(redbrickPrefab, center, Quaternion.identity);
                    Brick script = redbrickPrefab.GetComponent<Brick>();
                    script.releaseCoin = (coin == 1);
                }
                else if (color == 2)
                {
                    Instantiate(bluebrickPrefab, center, Quaternion.identity);
                    Brick script = bluebrickPrefab.GetComponent<Brick>();
                    script.releaseCoin = (coin == 1);
                }
                else
                {
                    Instantiate(yellowbrickPrefab, center, Quaternion.identity);
                    Brick script = yellowbrickPrefab.GetComponent<Brick>();
                    script.releaseCoin = (coin == 1);
                }
                
            }
            else
            {
                // Debug.Log("bricks present ....skipping");
            }
            nextTime += interval;
        }
    }
}

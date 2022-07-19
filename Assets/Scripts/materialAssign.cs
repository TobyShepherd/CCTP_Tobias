using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialAssign : MonoBehaviour
{
    public Material red;
    public Material blue;
    public Material green;
    public bool captured = false;
    public bool activeCube = false;
    public GameObject player;
    public GameObject particleEffect;
    public int enemyCount = 0;
    public playerRandomSpawn PRS;
    public bool spawnSquare = false;
    public bool roomEntered = false;
    private int lootChance = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = red;

        enemyCount = Random.Range(0, 4);

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if(distance == 1)
        {
            //spawnSquare = true;
            enemyCount = 0;
            //GetComponent<Renderer>().material = green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (captured)
        {
            GetComponent<Renderer>().material = blue;
        }

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if(distance == 1)
        {
            activeCube = true;
        }
        else if (distance > 1)
        {
            activeCube = false;
        }

        if (activeCube)
        {
            PRS.enemyCountVar = enemyCount;
            if (Input.GetKeyDown(KeyCode.K) && enemyCount > 0)
            {
                enemyCount--;
                PRS.killCount++;
            }
            if(enemyCount == 0 && spawnSquare)
            {
                PRS.moveAllowed = true;
                captured = true;
            }
            if (!roomEntered)
            {
                PRS.roomExplored++;
                lootChance = Random.Range(0, 9);
                if (lootChance == 5 && PRS.lootPiece != 10)
                {
                    Instantiate(particleEffect, player.transform.position, Quaternion.identity);
                    PRS.lootPiece++;
                }
                roomEntered = true;
            }
        }
        else if (!activeCube)
        {
            
        }
    }
}

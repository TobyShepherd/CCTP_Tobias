using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCamps : MonoBehaviour
{
    public GameObject player;
    private int xPos = 0;
    private int zPos = 0;
    public playerRandomSpawn PRS;
    public bool discovered = false;
    public bool activeCamp = false;

    private void Awake()
    {
        xPos = Random.Range(0, 9);
        zPos = Random.Range(0, 9);

        Vector3 pos = transform.position;

        pos.x = Mathf.RoundToInt(xPos);
        pos.y = 0.01f;
        pos.z = Mathf.RoundToInt(zPos);

        transform.position = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance < 1)
        {
            activeCamp = true;
        }
        else if (distance > 1)
        {
            activeCamp = false;
        }
        if(activeCamp)
        {
            if(!discovered)
            {
                PRS.campsFound++;
                discovered = true;
            }
        }
    }
}

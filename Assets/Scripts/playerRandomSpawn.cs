using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerRandomSpawn : MonoBehaviour
{
    private int xPos = 0;
    private int zPos = 0;
    public int displayX = 0;
    public int displayZ = 0;
    public int enemyCountVar = 0;
    public int killCount = 0;
    public int roomExplored = -1;
    public int campsFound = 0;
    public int lootPiece = 0;
    public bool moveAllowed = false;
    public materialAssign MA;
    public Text xDisplay;
    public Text zDisplay;
    public Text enemyCountDisplay;
    public Text moveAllowedDisplay;
    public Text roomCountDisplay;
    public Text killCountDisplay;
    public Text playerType;
    public Text campsFoundDisplay;
    public Text lootCount;

    private void Awake()
    {
        xPos = Random.Range(0, 9);
        zPos = Random.Range(0, 9);

        displayX = xPos;
        displayZ = zPos;

        Vector3 pos = transform.position;

        pos.x = Mathf.RoundToInt(xPos);
        pos.y = 1f;
        pos.z = Mathf.RoundToInt(zPos);

        transform.position = pos;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            Vector3 pos = transform.position;
            if (displayZ < 9)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    pos.z++;
                    displayZ++;
                    moveAllowed = false;

                    transform.position = pos;
                }
            }
            if (displayZ > 0)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    pos.z--;
                    displayZ--;
                    moveAllowed = false;

                    transform.position = pos;
                }
            }
            if (displayX > 0)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    pos.x--;
                    displayX--;
                    moveAllowed = false;

                    transform.position = pos;
                }
            }
            if (displayX < 9)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    pos.x++;
                    displayX++;
                    moveAllowed = false;

                    transform.position = pos;
                }
            }
        }

        // PLAYER TYPE LOGIC

        if(roomExplored > 99)
        {
            playerType.text = "EXPLORER";
        }
        else if (lootPiece > 7)
        {
            playerType.text = "ACHIEVER";
        }
        else if (killCount > 200)
        {
            playerType.text = "KILLER";
        }
        else if (campsFound == 3)
        {
            playerType.text = "SOCIALIZER";
        }
        else if(campsFound > 0 && roomExplored < 10)
        {
            playerType.text = "SOCIALIZER";
        }
        else if(lootPiece > 1 && roomExplored < 20)
        {
            playerType.text = "ACHIEVER";
        }
        else if (killCount > (roomExplored * 1.5))
        {
            playerType.text = "KILLER";
        }
        else if (killCount < (roomExplored * 1.5))
        {
            playerType.text = "EXPLORER";
        }

        // END OF PLAYER TYPE LOGIC

        xDisplay.text = displayX.ToString();
        zDisplay.text = displayZ.ToString();
        enemyCountDisplay.text = enemyCountVar.ToString();
        roomCountDisplay.text = roomExplored.ToString();
        killCountDisplay.text = killCount.ToString();
        campsFoundDisplay.text = campsFound.ToString();
        lootCount.text = lootPiece.ToString();

        if(moveAllowed)
        {
            moveAllowedDisplay.text = "TRUE";
        }
        else
        {
            moveAllowedDisplay.text = "FALSE";
        }

    }
}

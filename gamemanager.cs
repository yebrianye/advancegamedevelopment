using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    [System.Serializable]
    public class plants
    {
        public string name;
        public int cost;
        public Color m_color;
        public GameObject obj;
        public Vector3 size;
        public Sprite icon;
    }

    public int level = 2;
    public GameObject theGrid;
    public GameObject theButton;
    public Image[] characters;
    public plants[] plant;
    public Transform[] gridSquare;


    // Start is called before the first frame update
    void Start()
    {
        for(int a = 0; a < level; a++)
        {
            Instantiate(theButton, theGrid.transform);
        }

        characters = theGrid.GetComponentsInChildren<Image>();

        for(int b = 0; b < characters.Length; b++)
        {
            characters[b].transform.Find("name").GetComponent<Text>().text = plant[b].name;
            characters[b].transform.Find("cost").GetComponent<Text>().text = plant[b].cost.ToString("$00");
            characters[b].GetComponent<Image>().sprite = plant[b].icon;
        }

        //Invoke("spawn", 0.1f);
    }

    public LayerMask floorLayer;
    public Transform flag;
    RaycastHit hit;
    Ray ray;
    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, floorLayer))
        {
            flag.transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Invoke("spawn", 0.1f);
        }
    }
    

    public void spawn()
    {
        Transform shortestPosition = null;
        float shortestDistance=100;

        for(int c = 0; c < gridSquare.Length; c++)
        {
            float currentDistance = Vector3.Distance(flag.position, gridSquare[c].position);

            if(currentDistance < shortestDistance)
            {
                shortestDistance = currentDistance;
                shortestPosition = gridSquare[c];
            }

            
            //print("shortDistance = " + shortestDistance + " currentDistance = " + currentDistance + " c = " + c + " shortest position = " + shortestPosition);
        }
        //flag.position = shortestPosition.position;
        Instantiate(flag, shortestPosition);

    }
}

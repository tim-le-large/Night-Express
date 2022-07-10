using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public float size;
    private GameObject[,] _PuzzleItems;

    public int _rows = 3;
    public int _columns = 4;

    private bool clicked = false;
    private Vector3 currentPosition;
    private Transform currentPuzzleItem;
    public int[] itemOrder = new int[12];

    Vector3 _EmptyPositon;

    void Start()
    {

        _PuzzleItems = new GameObject[_rows, _columns];
        //HashSet<int> numbers = new HashSet<int>();

        int count = 0;


        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                /*
                int imageCount = Random.Range(1, 13);
                while (numbers.Contains(imageCount))
                {
                    imageCount = Random.Range(1, 13);
                }
                numbers.Add(imageCount);
                */
                int imageCount = itemOrder[count];
                count += 1;

                if (row == _rows - 1 && column == _columns - 1)
                {
                    _EmptyPositon = new Vector3(size * column, 0, size * row);
                }
                else
                {

                    _PuzzleItems[row, column] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    _PuzzleItems[row, column].transform.parent = transform;
                    _PuzzleItems[row, column].transform.localEulerAngles = new Vector3(0, 180, 0);
                    _PuzzleItems[row, column].transform.localScale = new Vector3(size / 10f, size / 10f, size / 10f);
                    _PuzzleItems[row, column].transform.localPosition = new Vector3(size * column, 0, size * row);
                    _PuzzleItems[row, column].transform.tag = "PuzzleItem";
                    Texture2D puzzleImage = Resources.Load("newItems/" + imageCount) as Texture2D;
                    Material material = new Material(Shader.Find("Standard"));
                    material.mainTexture = (Texture)puzzleImage;
                    _PuzzleItems[row, column].GetComponent<Renderer>().material = material;

                }

            }
        }



    }


    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "PuzzleItem")
                    {
                        float difference = Mathf.Abs(hit.transform.localPosition.x - _EmptyPositon.x) + Mathf.Abs(hit.transform.localPosition.z - _EmptyPositon.z);
                        if (difference >= size - 0.1 && difference <= size + 0.1)
                        {
                            FindObjectOfType<AudioManager>().Play("Slide");
                            clicked = true;
                            currentPosition = hit.transform.localPosition;
                            currentPuzzleItem = hit.transform;
                        }

                    }
                }
            }
        }
        else
        {
            currentPuzzleItem.localPosition = Vector3.MoveTowards(currentPuzzleItem.localPosition, _EmptyPositon, 1 * Time.deltaTime);
            
            if (currentPuzzleItem.localPosition == _EmptyPositon)
            {

                _EmptyPositon = currentPosition;
                clicked = false;
            }
        }

    }
}
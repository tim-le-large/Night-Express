using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update

    public float size = 2.5f;
    private GameObject[,] _PuzzleItems;

    private int _rows = 5;
    private int _columns = 4;

    private bool clicked = false;
    private Vector3 currentPosition;
    private Transform currentPuzzleItem;


    Vector3 _EmptyPositon;

    void Start()
    {
        _PuzzleItems = new GameObject[_rows, _columns];

        HashSet<int> numbers = new HashSet<int>();

        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {

                int imageCount = Random.Range(1, 21);
                while (numbers.Contains(imageCount))
                {
                    imageCount = Random.Range(1, 21);
                }
                numbers.Add(imageCount);
                if (row == _rows - 1 && column == _columns - 1)
                {
                    _EmptyPositon = new Vector3(size * column, 0, size * row);
                }
                else
                {

                    _PuzzleItems[row, column] = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    _PuzzleItems[row, column].transform.parent = transform;
                    _PuzzleItems[row, column].transform.localEulerAngles = new Vector3(0, 180, 0);
                    _PuzzleItems[row, column].transform.localScale = new Vector3(size / 10, size / 10, size / 10);
                    _PuzzleItems[row, column].transform.localPosition = new Vector3(size * column, 0, size * row);
                    _PuzzleItems[row, column].transform.tag = "PuzzleItem";
                    Texture2D puzzleImage = Resources.Load("PuzzleItems/" + imageCount) as Texture2D;
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
                        print("Clicked on PuzzleItem");
                        print("Difference to empty PuzzleItem" + (Mathf.Abs(hit.transform.localPosition.x - _EmptyPositon.x) + Mathf.Abs(hit.transform.localPosition.z - _EmptyPositon.z)));
                        if (Mathf.Abs(hit.transform.localPosition.x - _EmptyPositon.x) + Mathf.Abs(hit.transform.localPosition.z - _EmptyPositon.z) == size)

                        {
                            print("PuzzleItem has empty Neighbour");
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
            print("move");
            currentPuzzleItem.localPosition = Vector3.MoveTowards(currentPuzzleItem.localPosition, _EmptyPositon, 1 * Time.deltaTime);
            if (currentPuzzleItem.localPosition == _EmptyPositon)
            {
                _EmptyPositon = currentPosition;
                clicked = false;
            }
        }

    }
}

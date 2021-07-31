using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] float screenWidthInUnits = 21f;
    [SerializeField] float minX = 4.5f;
    [SerializeField] float maxX = 16.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(xPos, minX, maxX);
        transform.position = paddlePos;
    }
}

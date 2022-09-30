using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorScript : ProcessingLite.GP21
{
    public Vector2 circlePos;
    public int circleColor = 0;
    public float speed = 1.2f;

    private Vector2 reflectVector;
    private Vector2 bouncePos;
    private Vector2 previousPos;

    public Vector2 mousePos2D;
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        //Fill(255);


    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(circlePos.x, 0, Width);
        Mathf.Clamp(circlePos.y, 0, Height);

        Background(0);

        Circle(circlePos.x, circlePos.y, 3);



        if (Input.GetMouseButtonDown(0))
        {
            circlePos.x = MouseX;
            circlePos.y = MouseY;

            velocity = Vector2.zero;

            if (circleColor == 0)
            {
                circleColor = 255;
            }
            else
            {
                circleColor = 0;
            }
            Fill(128, circleColor, 128);

        }
        Stroke(255);
        if (Input.GetMouseButton(0))
        {
            Line(circlePos.x, circlePos.y, MouseX, MouseY);
        }

        circlePos += velocity * Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            mousePos2D = new Vector2(MouseX, MouseY);

            velocity = (mousePos2D - circlePos);

        }

        BounceAlongEdges();
    }

    private void BounceAlongEdges()
    {


        if (circlePos.y > Height)
        {
            velocity = Vector2.Reflect(velocity, Vector2.down);
        }

        if (circlePos.y < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.up);
        }

        if (circlePos.x > Width)
        {
            velocity = Vector2.Reflect(velocity, Vector2.left);
        }

        if (circlePos.x < 0)
        {
            velocity = Vector2.Reflect(velocity, Vector2.right);
        }


    }
}

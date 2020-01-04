using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEnemyController : EnemyController
{
    // 
    public bool fly_up;

    public TypePath typePath;
    public Anchor_Plane anchor;

    //Start is called before the first frame update


    // Update is called once per frame
   
    protected void FixedUpdate()
    {
        offset = Time.deltaTime * speedMove;
        if (canMove == true)
        {
            Move();
        }

    }
    public void Move()
    {
        int direc;
        if (fly_up)
        {
            direc = -1;
        }
        else
        {
            direc = 1;
        }

        if (typePath == TypePath.curve_up)
        {
            transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z - speedTurn));
            transform.position += direc * transform.right * offset;
        }
        if (typePath == TypePath.curve_down)
        {
            transform.localScale = new Vector3(-direc * saveScale.x, saveScale.y, 0);
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, transform.eulerAngles.z + speedTurn));
            transform.position -= direc * transform.right * offset;
        }
        if (typePath == TypePath.line)
        {
            if (anchor == Anchor_Plane.top)
            {
                //transform.localScale = new Vector3(direc*saveScale.x,saveScale.y,0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.right)
            {
                //transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.left)
            {
                // transform.localScale = new Vector3(saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.top_left)
            {
                //transform.localScale = new Vector3(direc * saveScale.x, saveScale.y, 0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -60));
                transform.position += transform.right * offset;
            }
            else if (anchor == Anchor_Plane.top_right)
            {
                //transform.localScale = new Vector3(direc * saveScale.x,saveScale.y,0);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -120));
                transform.position += transform.right * offset;
            }
        }





    }
   
}

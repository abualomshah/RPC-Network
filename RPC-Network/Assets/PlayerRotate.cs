using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRotate : NetworkBehaviour
{

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
            CmdRotate(h);

        if (Input.GetMouseButtonDown(0))
        {
           GameObject b = Instantiate(bullet, new Vector3(0, 0, 0), Quaternion.identity);
            NetworkServer.Spawn(b);
            
        }
    }


    [Command]
   public void CmdRotate(float Hvalue)
    {
        if (Hvalue > 0)
        {

            RpcRotateLeft();

        }
        else
        {
            RpcRotateLRight();
        }
    }


    public void RpcRotateLeft()
    {
        transform.Rotate(new Vector3(0, 0, 90));
    }

    public void RpcRotateLRight()
    {
        transform.Rotate(new Vector3(0, 0, 0));
    }
}

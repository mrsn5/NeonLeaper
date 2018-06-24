using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour {

    public Player player;

    void FixedUpdate () {
        //Transform rabit_transform = player.transform;
        //Transform camera_transform = this.transform;
        //Vector3 rabit_position = rabit_transform.position; 
        //Vector3 camera_position = camera_transform.position;
        //camera_position.x = rabit_position.x; 
        //camera_position.y = rabit_position.y;
        //camera_transform.position = camera_position;

        Vector2 direction = player.transform.position - transform.position;
        transform.position += new Vector3(direction.x * .05f, direction.y * .05f, 0);
    }
}

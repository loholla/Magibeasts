using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [Header("Inscribed")]
    public float xBound;
    public float zBound;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.x > xBound){
            pos.x -= 0.1f;
            print("Off Right");
        }
        if(pos.x < -xBound){
            pos.x += 0.1f;
            print("Off Left");
        }
        if(pos.z > zBound){
            pos.z -= 0.1f;
            print("Off Top");
        }
        if(pos.z < -zBound){
            pos.z += 0.1f;
            print("Off Bottom");
        }

        transform.position = pos;
    }
}

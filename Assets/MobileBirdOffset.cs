using UnityEngine;

public class BirdOffset : MonoBehaviour
{
    void Start()
    {
        float ratio = (float)Screen.width / Screen.height;

        if (ratio < 0.65f)
        {
            Vector3 pos = transform.position;
            pos.x -= 2f;
            transform.position = pos;
        }
    }
}

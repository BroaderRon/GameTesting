using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    

    // Update is called once per frame
    void Update(){

        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);
    }

}
using UnityEngine;

public class CharacterSprite : MonoBehaviour
{
    
    [SerializeField] bool freezeXAxis = true;

    // Update is called once per frame
    private void Update(){

        if (freezeXAxis){

            transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, Camera.main.transform.rotation.eulerAngles.z);

        }
        else{

            transform.rotation = Camera.main.transform.rotation;

        }
        
    }

}

using UnityEngine;

public class CharacterSpriteDirectionalController : MonoBehaviour
{

    [SerializeField] float seAngle = -45f;
    [SerializeField] float nwAngle = 135f;
    [SerializeField] float neAngle = -135f;
    [SerializeField] Transform mainTransform;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Update is called once per frame
    private void LateUpdate()
    {
        
        Vector3 camForwardVector = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        Debug.DrawRay(Camera.main.transform.position, camForwardVector * 5f, Color.magenta);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVector, Vector3.up);

        Vector2 animationDirection = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if (angle < neAngle){

            // North-East anim
            animationDirection = new Vector2(1f, 1f);
        }
        else if (angle < nwAngle){
            
            //North-West anim
            animationDirection = new Vector2(-1f, 1f);
        }
        else if (angle < seAngle){

            // South-East anim
            animationDirection = new Vector2(1f, -1f);
        }
        else{

            // South-West anim
            animationDirection = new Vector2(-1f,-1f);
        }

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);

    }
}

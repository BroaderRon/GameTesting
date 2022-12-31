using UnityEngine;
using UnityEditor;
using System.Collections;

namespace EightDirectionalSpriteSystem
{
    [ExecuteInEditMode]
    public class DemoActor : MonoBehaviour
    {
        public enum State { NONE, IDLE, WALKING, AGGRESSIVE, ATTACK, DOWN, DIE, HSCENE};

        public ActorBillboard actorBillboard;

        public ActorAnimation idleAnim;
        public ActorAnimation walkAnim;
        public ActorAnimation aggressiveAnim;
        public ActorAnimation attackAnim;
        public ActorAnimation downAnim;
        public ActorAnimation dieAnim;
        public ActorAnimation hsceneAnim;


        private Transform myTransform;
        private ActorAnimation currentAnimation = null;
        private State currentState = State.NONE;

        void Awake()
        {
            myTransform = GetComponent<Transform>();
        }

        void Start()
        {
            SetCurrentState(State.IDLE);
        }

        private void OnEnable()
        {
            SetCurrentState(State.IDLE);
        }

        private void OnValidate()
        {
            if (actorBillboard != null && actorBillboard.CurrentAnimation == null)
                SetCurrentState(currentState);
        }

        void Update()
        {
            if (actorBillboard != null)
            {
                actorBillboard.SetActorForwardVector(myTransform.forward);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                State nextState = currentState;
                switch (currentState)
                {
                    case State.NONE:
                        nextState = State.IDLE;
                        break;

                    case State.IDLE:
                        nextState = State.AGGRESSIVE;
                        break;

                    case State.AGGRESSIVE:
                        nextState = State.ATTACK;
                        break;

                    case State.ATTACK:
                        nextState = State.DOWN;
                        break;

                    case State.DOWN:
                        nextState = State.DIE;
                        break;

                    case State.DIE:
                        nextState = State.HSCENE;
                        break;

                    case State.HSCENE:
                        nextState = State.IDLE;
                        break;

                    default:
                        nextState = State.IDLE;
                        break;
                }

                SetCurrentState(nextState);
            }
           
        }

        private void SetCurrentState(State newState)
        {
            currentState = newState;
            switch (currentState)
            {

                case State.AGGRESSIVE:
                    currentAnimation = aggressiveAnim;
                    break;

                case State.ATTACK:
                    currentAnimation = attackAnim;
                    break;

                case State.DOWN:
                    currentAnimation = downAnim;
                    break;

                case State.DIE:
                    currentAnimation = dieAnim;
                    break;

                case State.HSCENE:
                    currentAnimation = hsceneAnim;
                    break;

                default:
                    currentAnimation = idleAnim;
                    break;
            }

            if (actorBillboard != null)
            {
                actorBillboard.PlayAnimation(currentAnimation);
            }
        }

    }
}

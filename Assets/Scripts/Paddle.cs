using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{

    public class Paddle : MonoBehaviour
    {
        //declare the attribute for the peddle for future use
        [System.Flags]
        public enum peddleAttribute{
            normal = 1 << 0,
            fire = 1 << 1
        }
        public peddleAttribute attribute;

        [Tooltip("Put the peddle data here")]
        [SerializeField]
        public PaddleData data;
        float speed;
        public float length;
        private bool gameEnd;

        string input;
        [HideInInspector]
        public bool isRight;

        public void StopThePaddle()
        {
            gameEnd = true;
        }

        public void Init(bool isRightPaddle)
        {
            //activate the peddle and the input system according to the parameter passed by the game manager.
            Vector2 pos = Vector2.zero;
            if (isRightPaddle)
            {
                isRight = true;
                pos = new Vector2(GameManager.topRight.x, 0);
                pos -= Vector2.right * transform.localScale.x;
                input = "PaddleRight";
            }
            else
            {
                isRight = false;
                pos = new Vector2(GameManager.bottomLeft.x, 0);
                pos += Vector2.right * transform.localScale.x;
                input = "PaddleLeft";
            }

            transform.position = pos;
            transform.name = input;
        }
        // Start is called before the first frame update
        void Start()
        {
            gameEnd = false;
            //load the data from the peddle data
            attribute = peddleAttribute.normal;
            length = data.paddeLength;
            speed = data.paddleSpeed;
            transform.localScale = new Vector3(0.5f,data.paddeLength,0f);
            //using this to check the wrong data in the balldata.
            if (speed == 0 || length == 0)
            {
                Debug.Assert(speed != 0, "The paddle speed sould not be 0, you can change it in Asset/Data/PaddleData");
                Debug.Assert(length != 0, "The paddle length sould not be 0, you can change it in Asset/Data/PaddleData");
#if UnityEditor
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }

        }

        // Update is called once per frame
        void Update()
        {   if (gameEnd) return;
            //player can move the peddle in the game scene
            float move = Input.GetAxis(input) * Time.deltaTime * speed;
            //set the boundary of the game scene for the peddle
            if(transform.position.y < GameManager.bottomLeft.y + length / 2 && move < 0)
            {
                move = 0; 
            }
            if (transform.position.y > GameManager.topRight.y - length / 2 && move > 0)
            {
                move = 0;
            }

            transform.Translate(move * Vector2.up);
        }



        //the function to change the attribut of the peddle for the skill system
        public void ChangeAttribute(int attributeIndex)
        {
            attribute |= (peddleAttribute)attributeIndex;
            StartCoroutine(AttributeCoroutine(attributeIndex));
        }

        private IEnumerator AttributeCoroutine(int attributeIndex)
        {
            yield return new WaitForSeconds(5f);
            attribute &= ~(peddleAttribute)attributeIndex;
        }
        //stop the paddle when game ends

    }
}


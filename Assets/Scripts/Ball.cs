using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Events;

namespace Pong
{
    public class Ball : MonoBehaviour
    {   

        [Tooltip("Put the ball data here")]
        [SerializeField]
        private BallData data;

        float speed;
        float radius;
        Vector2 direction;

        public void StopTheBall()
        {
            speed = 0;

        }
        void Start()
        {   
            //load the argument from the ball data
            direction = data.ballStartDirection.normalized;
            radius = transform.localScale.x / 2;
            speed = data.ballSpeed;
            //using this to check the wrong data in the balldata.
            Debug.Assert(direction.x != 0 && direction.y != 0, "The direction of ball should not be up,right or zero, you can change it in Asset/Data/Ball Data");
            Debug.Assert(speed != 0, "The speed should not be 0, you can change it in Asset/Data/Ball Data");

        }

        void Update()
        {
            //move the ball in the game scene
            transform.Translate(direction * speed * Time.deltaTime);
            //set the boundary of the game scene for ball
            if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
            {
                direction.y = -direction.y;
            }

                
            if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
            {
                direction.y = -direction.y;
            }

            //set the game result condition
            if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().AddPoint(false);
                transform.position = Vector3.zero;
                int x = Random.Range(1, 10);
                direction = new Vector2(-x,Random.Range(1,x)).normalized;
            }
                
            if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
            {
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().AddPoint(true);
                transform.position = Vector3.zero;
                int x = Random.Range(1, 10);
                direction = new Vector2(x, Random.Range(1, x)).normalized;
            }
                

        }
        
        //using the collider system to do the function when ball hits the peddle
        private void OnTriggerEnter2D(Collider2D other)
        {   
            if(other.tag == "Paddle")
            {   
                bool isRight = other.GetComponent<Paddle>().isRight;
                if (isRight == true && direction.x > 0)
                {
                    direction.x = -direction.x;
                }
                if(isRight == false && direction.x<0)
                {
                    direction.x = -direction.x;
                }
                /*Attribute system
                 *using the bit operation to recognize the attribute of the peddle   
                 *using the enum to compare the attribute of the peddle
                 */
                if ((other.GetComponent<Paddle>().attribute & Paddle.peddleAttribute.fire) == Paddle.peddleAttribute.fire)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    speed = other.GetComponent<FireBall>().fireSpeed;
                }

            }
        }

        //when game ends stop the ball

    }
}


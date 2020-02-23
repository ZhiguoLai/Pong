using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pong
{
    public class GameManager : MonoBehaviour
    {
        [Tooltip("Put the data in this field")]
        [SerializeField] private GameData data;
        public Ball ball;
        public Paddle paddle;


        public PaddleAbility peddleRightAbilitie;
        public PaddleAbility peddleLeftAbilityies;

        public GameObject rightUI;
        public GameObject leftUI;

        public static Vector2 bottomLeft;
        public static Vector2 topRight;

        private int leftPlayerPoint;
        private int rightPlayerPoint;

        private bool gameEnd;

        [Tooltip("Put the left point UI component here")]
        [SerializeField]
        private Text leftPoint;
        [Tooltip("Put the right point UI component here")]
        [SerializeField]
        private Text RightPoint;
        void Start()
        {

            gameEnd = false;
            //set the boundary of the game to put the peddle in the correct position
            bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            Instantiate(ball);
            //Generate the left peddle and right peddle pass the parameter to the peddle acript and using it in the initialization
            Paddle paddleLeft = Instantiate(paddle) as Paddle;
            Paddle paddleRight = Instantiate(paddle) as Paddle;
            paddleLeft.Init(false);
            paddleRight.Init(true);
            // Assign the ability to different player 
            AbilityCoolDown rightCoolDownButtons = rightUI.GetComponentInChildren<AbilityCoolDown>();
            PaddleAbility rightPeddleAbility = peddleRightAbilitie;
            rightCoolDownButtons.Initialize(rightPeddleAbility.paddleAbility, paddleRight.gameObject);
            AbilityCoolDown leftCoolDownButtons = leftUI.GetComponentInChildren<AbilityCoolDown>();
            PaddleAbility leftPeddleAbility = peddleLeftAbilityies;
            leftCoolDownButtons.Initialize(leftPeddleAbility.paddleAbility, paddleLeft.gameObject);
        }      
        
        public void QuitTheGame()
        {
            Application.Quit();
        }

        public void AddPoint(bool isLeftPlayerScore)
        {
            if (isLeftPlayerScore)
            {
                leftPlayerPoint++;
                leftPoint.text = leftPlayerPoint.ToString();
            }
            else
            {
                rightPlayerPoint++;
                RightPoint.text = rightPlayerPoint.ToString();
            }
            CheckGameEnd();
            if (gameEnd) return;
        } 
        public void CheckGameEnd()
        {
            if(leftPlayerPoint >= data.winScore || rightPlayerPoint >= data.winScore)
            {
                data.gameEndEvent.Raise();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong
{

    public class StretchPaddle : MonoBehaviour
    {   

        [HideInInspector] public float afterLength;
        public void ChangePaddleLength()
        {
            transform.localScale = new Vector3(0.5f, afterLength, 0f);
            GetComponent<Paddle>().length = afterLength; 
            StartCoroutine(BuffDisappear());
        }

        private IEnumerator BuffDisappear()
        {
            yield return new WaitForSeconds(5f);
            transform.localScale = new Vector3(0.5f, GetComponent<Paddle>().data.paddeLength, 0f);
            GetComponent<Paddle>().length = afterLength;
        }
    }
}


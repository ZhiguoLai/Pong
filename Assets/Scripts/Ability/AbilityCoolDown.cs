using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a UI class to show the cool down and the icon of the ability
/// </summary>


namespace Pong
{
    public class AbilityCoolDown : MonoBehaviour
    {   [Tooltip("Write the input name here, you can set the input function for this skill in Editor/Project Setting/Input")]
        public string abilityBUttonAxisNmae = "Default";
        [Tooltip("Put the dark mask image here to express the CD")]
        public Image darkMask;
        [Tooltip("Put the text compnent here to express th CD")]
        public Text coolDownTextDisplay;

        private Ability ability;
        private GameObject paddle;
        private Image myButtonImage;
        private AudioSource abilitySource;
        private float coolDownDuration;
        private float nextReadyTime;
        private float coolDownTimeLeft;

        public void Initialize(Ability selectedAbility, GameObject paddle)
        {   // Initialization process, load the data from the ability file
            ability = selectedAbility;
            myButtonImage = GetComponent<Image>();
            Debug.Assert(myButtonImage != null, "you need an image to show your skill icon");
            abilitySource = GetComponent<AudioSource>();
            Debug.Assert(abilitySource != null, "you need a audiosource to play the audio");

            myButtonImage.sprite = ability.abilitySprite;
            darkMask.sprite = ability.abilitySprite;
            coolDownDuration = ability.abilityBaseCoolDown;
            ability.Initialize(paddle);
            AbilityReady();
        }

        void Update()
        {   //UI expression for the skill button
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
            {
                AbilityReady();
                if (Input.GetButtonDown(abilityBUttonAxisNmae))
                {
                    ButtonTriggerred();
                }

            }
            else
            {
                CoolDown();
            }
        }
        private void AbilityReady()
        {
            coolDownTextDisplay.enabled = false;
            darkMask.enabled = false;
        }
        private void CoolDown()
        {   //Cooldown process
            coolDownTimeLeft -= Time.deltaTime;
            float roundedCd = Mathf.Round(coolDownTimeLeft);
            coolDownTextDisplay.text = roundedCd.ToString();
            darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
        }

        private void ButtonTriggerred()
        {
            //call the ability function when player press the button set by the input
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            darkMask.enabled = true;
            coolDownTextDisplay.enabled = true;
            abilitySource.clip = ability.abilitySound;
            abilitySource.Play();
            ability.TriggerAbility();
        }

    }
}


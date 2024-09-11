using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReadyPlayerMe.Core
{
public class AnimationManager : MonoBehaviour
{
    public VoiceHandler voiceHandler; // Reference to the VoiceHandler component
    // public EyeAnimationHandler eyeHandler;
    public Animator animator; // Reference to the Animator component
    // private bool isBlinking;
    public GameObject panel_1;
    public GameObject panel_2;

    private void Start()
    {
        panel_1.SetActive(true);
        panel_2.SetActive(false);
    }

    public void Finish()
    {
        Application.Quit();
    }

    private void Update()
    {
    }

    // private void ResetBlinking()
    // {
    //     isBlinking = false;
    // }

    public void BeginAnimation()
    {
        if (voiceHandler != null)
        {
            voiceHandler.PlayCurrentAudioClip(); // Play the audio clip
        }

        StartCoroutine(PlayAnimationAfterDelay());
    }

      private IEnumerator PlayAnimationAfterDelay()
    {
        if (animator != null)
        {
            animator.SetTrigger("Greet"); 
        
            yield return new WaitForSeconds(2f); // Wait for the specified delay

            animator.SetTrigger("TalkAlternative");

            yield return new WaitForSeconds(2f); 

            animator.SetTrigger("Talk");

            yield return new WaitForSeconds(4f);


            animator.SetTrigger("Point");

        }
    }
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.Core.Fader;
using Liminal.SDK.Core;

public class EndingExample : MonoBehaviour
{
    /// <summary>
    /// This method constitutes a good way to end an experience as it uses ExperienceApp.Quit() and fades the camera and audio before exiting.
    /// This method results in a smooth exit from the liminal platform and takes users to the relevant psychometrics panel. 
    /// All users would be happy with this method.
    /// </summary>
    public void GoodWayToEnd()
    {
        StartCoroutine(FadeAndExit(2f));

        // This coroutine fades the camera and audio simultaneously over the same length of time.
        IEnumerator FadeAndExit(float fadeTime)
        {
            var elapsedTime = 0f; //instantiate a float witha  value of 0 for use as a timer.
            var startingVolume = AudioListener.volume; //this gets the current volume of the audio listener so that we can fade it to 0 over time.

            ScreenFader.Instance.FadeTo(Color.black, fadeTime); // Tell the system to fade the camera to black over X seconds where X is the value of fadeTime.
            
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime; // Count up
                AudioListener.volume = Mathf.Lerp(startingVolume, 0f, elapsedTime / fadeTime); // This uses linear interpolation to change the volume of AudioListener over time.
                yield return new WaitForEndOfFrame(); // Wait for a frame to avoid hangs.
            }

            // when the while-loop has ended the audiolistener volume should be 0 and the screen completely black. However, for safety's sake, we should manually set AudioListener volume to 0.
            AudioListener.volume = 0f;

            ExperienceApp.End(); // This tells the platform to exit the experience.

        }
    }
}
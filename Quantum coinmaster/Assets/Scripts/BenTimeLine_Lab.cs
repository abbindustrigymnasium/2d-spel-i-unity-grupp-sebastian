using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BenTimeLine_Lab : MonoBehaviour
{
    public PlayableDirector timelineToPlay;
    public Animator ScientistAnimator;
    public Animator portalAnimator;

    void Start()
    {
        timelineToPlay = GetComponent<PlayableDirector>();
    }
    public void AnimatePortal(){
        portalAnimator.SetTrigger("open");
    }
    public void stayOpen(){
        portalAnimator.SetTrigger("stay");
    }
    public void AnimateScientist()
    {
        ScientistAnimator.SetBool("chocked", true);
    }
    public void PlayTimeline()
    {
        if (timelineToPlay != null)
        {
            timelineToPlay.Play();
        }
    }

    public void StopTimeline()
    {
        if (timelineToPlay != null)
        {
            timelineToPlay.Stop(); // Stop the Timeline
        }
    }
}

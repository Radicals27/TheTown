using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ConversationHandler : MonoBehaviour
{
    public void ManageConversation(NavMeshAgent talker, GameObject receiver)
    {
        Person talker_person_obj = talker.GetComponentInParent<Person>();
        Person receiver_person_obj = receiver.GetComponentInParent<Person>();

        SpeechBubble talkers_speech_bubble = talker.GetComponentInParent<SpeechBubble>();
        SpeechBubble receivers_speech_bubble = receiver.GetComponentInParent<SpeechBubble>();

        NavMeshAgent receiver_nav_agent = receiver.GetComponentInParent<Person>().GetComponent<NavMeshAgent>();

        talker_person_obj.isTalking = true;
        receiver_person_obj.isTalking = true;

        talker.isStopped = true;
        talker.transform.LookAt(receiver.transform);

        receiver_nav_agent.isStopped = true;
        receiver_nav_agent.transform.LookAt(talker.transform);

        StartCoroutine(Test(talker, talkers_speech_bubble, receiver, receivers_speech_bubble));
    }

    IEnumerator Test(NavMeshAgent talker, SpeechBubble talkers_speech_bubble, GameObject receiver, SpeechBubble receivers_speech_bubble)
    {
        talkers_speech_bubble.Speak("hello!");
        receivers_speech_bubble.Speak("I know you!");

        yield return new WaitForSeconds(5);

        talkers_speech_bubble.Speak("Bye mate!");
        receivers_speech_bubble.Speak("Have a good one!");

        talker.isStopped = false;
        receiver.GetComponentInParent<NavMeshAgent>().isStopped = false;
    }
}

using UnityEngine;
using System.Collections;

public class Talk : MonoBehaviour
{
    public Transform playerTrans, speakerTrans, speakerLook, camTrans, speakerHead;
    public AudioSource dialogue1, dialogue2, dialogue3;
    public GameObject prompt;
    public Movement player;
    public Collider camCollider;
    public float talkTime1, talkTime2, talkTime3;

    private bool isPlayerNearby = false;
    private bool isTalking = false;

    void Update()
    {
        if (isPlayerNearby && !isTalking && Input.GetKeyDown(KeyCode.E))
        {
            StartConversation();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && prompt != null)
        {
            prompt.SetActive(true);
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") && prompt != null)
        {
            prompt.SetActive(false);
            isPlayerNearby = false;
        }
    }

    void StartConversation()
    {
        if (prompt != null) prompt.SetActive(false);
        if (player != null) player.enabled = false;
        if (camCollider != null) camCollider.enabled = false;

        if (speakerTrans != null && playerTrans != null)
            speakerTrans.LookAt(playerTrans.position + Vector3.up * 0.1f);

        if (camTrans != null && speakerHead != null)
            camTrans.LookAt(speakerHead.position + Vector3.up * 0.1f);

        AudioSource[] dialogues = { dialogue1, dialogue2, dialogue3 };
        float[] talkTimes = { talkTime1, talkTime2, talkTime3 };
        int index = Random.Range(0, dialogues.Length);

        if (dialogues[index] != null)
        {
            dialogues[index].Play();
            StopAllCoroutines(); // Ensure only one coroutine runs at a time
            StartCoroutine(EndConversation(talkTimes[index]));
        }
    }

    IEnumerator EndConversation(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (speakerTrans != null && speakerLook != null)
            speakerTrans.LookAt(speakerLook.position);

        if (player != null) player.enabled = true;
        if (camCollider != null) camCollider.enabled = true;

        isTalking = false;
    }
}

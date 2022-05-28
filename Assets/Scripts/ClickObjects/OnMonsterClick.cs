using UnityEngine;
using UnityEngine.EventSystems;

public class OnMonsterClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject monster;
    [SerializeField] private AudioClip tapOnMonsterClip;

    private float returnSizeTime = 0.5f;
    private float reducedSizeTime = 10f;
    private bool isStartAnimation = false;
    private Animator monsterAnimator;
    private AudioSource tapOnMonsterAS;

    public int ClickSum { get; set; } = 0;

    void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        tapOnMonsterAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= returnSizeTime && isStartAnimation)
        {
            monsterAnimator.ResetTrigger("Click");
            isStartAnimation = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickSum++;
        tapOnMonsterAS.PlayOneShot(tapOnMonsterClip, 1f);

        returnSizeTime = Time.time + reducedSizeTime;
        if (!(monsterAnimator == null))
        {
            monsterAnimator.SetTrigger("Click");
            isStartAnimation = true;
        }
    }
}

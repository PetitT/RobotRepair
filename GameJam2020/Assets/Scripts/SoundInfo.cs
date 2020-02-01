using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInfo : SoundManager
{
    [SerializeField] private AudioSource otherSource;
    private List<string> code = new List<string>();
    private int index;
    private bool isOverriden = false;

    private void Update()
    {
        if (Input.anyKeyDown && !isOverriden)
        {
            string letter = Input.inputString;
            if (letter == code[index])
            {
                index++;
                if (index == code.Count)
                {
                    isOverriden = true;
                }
            }
            else
            {
                index = 0;
            }
        }
    }

    private void Start()
    {
        code.Add("s");
        code.Add("y");
        code.Add("l");
        code.Add("v");
        code.Add("a");
        code.Add("n");
    }

    public override void PlaySound(AudioClip clip)
    {
        if (!isOverriden)
            base.PlaySound(clip);
        else
            otherSource.Play();
    }
}

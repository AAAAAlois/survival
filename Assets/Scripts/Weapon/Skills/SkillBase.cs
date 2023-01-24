using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    public SkillData skillData;



    public virtual void SetData(SkillData sd)
    {
        skillData = sd;

    }


}

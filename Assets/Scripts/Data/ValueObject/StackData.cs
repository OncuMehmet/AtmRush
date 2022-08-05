using System;
using Enums;

[Serializable]
public class StackData 
{
    StackType Type = StackType.UnStack;

    public StackScoreData scoreData;

    public StackScaleData scaleData;
}

[Serializable]
public class StackScoreData
{
    public int AtmScore;
    
    public int GameScore;
}

[Serializable]
public class StackScaleData
{
    public float ScaleMultiplier = .1f;

    public float ScaleDuration = .2f;
}

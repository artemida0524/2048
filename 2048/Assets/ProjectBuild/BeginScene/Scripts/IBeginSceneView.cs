using System;

public interface IBeginSceneView
{
    event Action OnBeginSceneView;
    event Action OnClickContinue;
    event Action OnFinishAnimation;

    bool CanClick { get; }

    void BeginAnimation();

    void ClickContinue();
    void FinishAnimation();
}

using Naninovel;
using UI;

public class HideArtifact : Command
{
    [RequiredParameter, ParameterAlias(NamelessParameterAlias)]
    public DecimalParameter time;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        IUIManager uiManager = Engine.GetService<IUIManager>();
        ArtifactUI artifactUI = uiManager.GetUI<ArtifactUI>();
            
        artifactUI.StartFade(
            () => artifactUI.Artifact.gameObject.SetActive(false), time.Value);

        return UniTask.CompletedTask;

    }
}

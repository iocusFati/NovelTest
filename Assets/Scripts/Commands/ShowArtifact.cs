using Naninovel;
using UI;

namespace Commands
{
    public class ShowArtifact : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            ArtifactUI artifactUI = uiManager.GetUI<ArtifactUI>();
            
            artifactUI.Artifact.gameObject.SetActive(true);

            return UniTask.CompletedTask;
        }
    }
}
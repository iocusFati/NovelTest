using Naninovel;
using UI;
using UnityEngine.SocialPlatforms.Impl;

namespace Commands
{
    public class UpdateQuest : Command
    {
        [RequiredParameter, ParameterAlias(NamelessParameterAlias)]
        public StringParameter Achievement;

        [ParameterAlias("location")] public StringParameter Location;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            IUIManager uiManager = Engine.GetService<IUIManager>();
            HUD hud = uiManager.GetUI<HUD>();

            if (Location.HasValue)
                hud.UpdateAchievement(Achievement.Value, Location.Value);
            else
                hud.UpdateAchievement(Achievement.Value);

            return UniTask.CompletedTask;
        }
    }
}
using DTT.MinigameMemory;
using Naninovel;

namespace UI.Services
{
    [EditInProjectSettings]
    public class MiniGameConfig : Configuration
    {
        public MemoryGameSettings GameSettings;
        
        public const string DefaultPathPrefix = "MiniGame";

        public ResourceLoaderConfiguration Loader = new ResourceLoaderConfiguration { PathPrefix = DefaultPathPrefix };
    }
}
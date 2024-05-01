namespace GH
{
	namespace SceneManager
	{
        using Godot;

        [GlobalClass]
        public partial class SceneManager : Node
        {
            [Export]
            public Node CurrentScene = null;

            public TScene SwitchScene<TScene>(TScene newScene) where TScene : Node
            {
                //If scene is already set to newScene - return
                if (CurrentScene == newScene) return newScene;

                //Remove CurrentScene node if it exists
                CurrentScene?.QueueFree();

                //Add newScene as a child, if it's not null
                if (newScene != null) AddChild(newScene);

                //Set CurrentScene to newScene
                CurrentScene = newScene;

                return newScene;
            }

            public Node SwitchScene(PackedScene newScene)
            {
                return SwitchScene(newScene.Instantiate());
            }
        }
    }
}
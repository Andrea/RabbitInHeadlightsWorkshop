using System;
using System.Linq;
using Duality;
using Duality.Components.Renderers;
using Duality.Helpers;
using Duality.Resources;

namespace RabbitsInCSharp
{
	[Serializable]
	public class HudComponent : Component, ICmpUpdatable, ICmpInitializable
	{
		[NonSerialized]
		private GameObject _scoreObj;
		[NonSerialized]
		private TextRenderer _textRenderer;
		
		[NonSerialized]
		private ScoreComponent _scoreComponent;

		public void OnUpdate()
		{
			if (_textRenderer != null)
				_textRenderer.Text.ApplySource("Score: " + (_scoreComponent == null ? "No score component in this scene" : _scoreComponent.Score.ToString()));
		}

		public void OnInit(InitContext context)
		{
			if (context != InitContext.Activate)
				return;

			_scoreObj = Scene.Current.AllObjects.FirstByName("Hud");
			Guard.NotNull(_scoreObj);

			_textRenderer = _scoreObj.GetComponent<TextRenderer>();
			Guard.NotNull(_textRenderer);

			_scoreComponent = Scene.Current.AllObjects.GetComponentsDeep<ScoreComponent>().FirstOrDefault();
		}


		public void OnShutdown(ShutdownContext context)
		{
		}
	}
}
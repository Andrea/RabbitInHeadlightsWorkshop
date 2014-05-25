using System;
using System.Linq;
using Duality;
using Duality.Editor;

namespace RabbitsInCSharp
{
	[Serializable]
	public class ScoreComponent : Component,  ICmpUpdatable, ICmpInitializable
	{
		[NonSerialized]
		private float _currentMultiplierLevel;

		[EditorHintFlags(MemberFlags.Invisible)]
		public int Score { get; private set; }
		[EditorHintFlags(MemberFlags.Invisible)]
		public int Multiplier { get; private set; }
		public int[] MultiplierThresholds { get; set; }
		public int[] MultiplierDrainSpeed { get; set; }
		

		public void OnUpdate()
		{
			UpdateMultiplier();
			DrainMultiplier();
		}

		public void IncreaseScore(int amount)
		{
			var score = amount * Multiplier;
			Score += score;
			_currentMultiplierLevel += score;
		}

		private void UpdateMultiplier()
		{
			while (_currentMultiplierLevel > MultiplierThresholds[Multiplier - 1] && Multiplier < MultiplierThresholds.Length)
			{
				_currentMultiplierLevel -= MultiplierThresholds[Multiplier - 1];
				Multiplier++;
			}
		}

		private void DrainMultiplier()
		{
			var drainIndex = Multiplier - 1;
			if (Multiplier > MultiplierDrainSpeed.Count())
			{
				drainIndex = MultiplierDrainSpeed.LastOrDefault();
			}

			_currentMultiplierLevel = MathF.Max(0,
				_currentMultiplierLevel - MultiplierDrainSpeed[drainIndex] * (Time.LastDelta / 1000) * Time.TimeScale);

		}

		public void OnInit(InitContext context)
		{
			MultiplierThresholds = new[] { 400, 800, 1600, 3200 };
			MultiplierDrainSpeed = new[] { 60, 130, 320, 800 };
			Multiplier = 1;
		}

		public void OnShutdown(ShutdownContext context)
		{
		}
	}
}
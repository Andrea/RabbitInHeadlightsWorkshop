using System;
using Duality;
using Duality.Components;
using Duality.Components.Renderers;
using Duality.Resources;
using OpenTK;
using OpenTK.Graphics.ES11;
using OpenTK.Input;

namespace Debug
{
	[Serializable]
	public class Brick : Component, ICmpCollisionListener
	{
		public void OnCollisionBegin(Component sender, CollisionEventArgs args)
		{
			GameObj.DisposeLater();
		}

		public void OnCollisionEnd(Component sender, CollisionEventArgs args)
		{
			
		}

		public void OnCollisionSolve(Component sender, CollisionEventArgs args)
		{
			
		}
	}

	public enum BallState
	{
		FixedToBat,
		Free
	}

	[Serializable]
	public class Ball : Component, ICmpUpdatable
	{
		[NonSerialized]
		private BallState _ballState;

		public BallState BallState
		{
			get { return _ballState; }
			set { _ballState = value; }
		}

		public void OnUpdate()
		{
			GameObj.RigidBody.LinearVelocity = GameObj.RigidBody.LinearVelocity.Normalized * 50;
		}
	}

	[Serializable]
	public class Bat : Component, ICmpUpdatable, ICmpInitializable
	{
		public void OnUpdate()
		{
			if (DualityApp.Keyboard.KeyPressed(Key.Left))
			{
				GameObj.Transform.MoveBy(-Vector2.UnitX * 10);
			}
			else if (DualityApp.Keyboard.KeyPressed(Key.Right))
			{
				GameObj.Transform.MoveBy(Vector2.UnitX * 10);
			}

			if(Scene.Current.FindComponent<Ball>().BallState == BallState.FixedToBat)
				Scene.Current.FindGameObject<Ball>().Transform.Pos = new Vector3(GameObj.Transform.Pos.X + 100, GameObj.Transform.Pos.Y - 50, 0);
		}

		public void OnInit(InitContext context)
		{
			
		}

		public void OnShutdown(ShutdownContext context)
		{
			
		}
	}

	[Serializable]
	public class Application : Component, ICmpUpdatable
	{
		public void OnUpdate()
		{
			var ball = Scene.Current.FindComponent<Ball>();
			if (DualityApp.Keyboard.KeyHit(Key.Space))
			{
				if (Scene.Current.FindComponent<LifeMeter>().Lives > 0 && ball.BallState == BallState.FixedToBat)
				{
					ball.GameObj.RigidBody.LinearVelocity = new Vector2((float) ((MathF.Rnd.NextDouble() - 0.5f)*2*100), -100);
					ball.BallState = BallState.Free;
				}
			}
		}
	}

	[Serializable]
	public class Ground : Component, ICmpCollisionListener
	{
		public void OnCollisionBegin(Component sender, CollisionEventArgs args)
		{
			GameObject ball = Scene.Current.FindGameObject<Ball>();
			if (args.CollideWith == ball)
			{
				Scene.Current.FindComponent<Ball>().BallState = BallState.FixedToBat;
				ball.Transform.Pos = Scene.Current.FindGameObject<Bat>().Transform.Pos;

				Scene.Current.FindComponent<LifeMeter>().Lives--;

				if (Scene.Current.FindComponent<LifeMeter>().Lives == 0)
				{
					Scene.Current.FindGameObject("GameOver", false).Active = true;
				}
			}
		}

		public void OnCollisionEnd(Component sender, CollisionEventArgs args)
		{

		}

		public void OnCollisionSolve(Component sender, CollisionEventArgs args)
		{

		}
	}

	[Serializable]
	public class LifeMeter : Component, ICmpUpdatable
	{
		public int Lives { get; set; }

		public void OnUpdate()
		{
			GameObj.GetComponent<TextRenderer>().Text.SourceText = "Lives: " + Lives;
		}
	}
}

using System;
using Duality;
using OpenTK;

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

	[Serializable]
	public class Ball : Component, ICmpUpdatable
	{
		public void OnUpdate()
		{
			GameObj.RigidBody.LinearVelocity = GameObj.RigidBody.LinearVelocity.Normalized * 100;
		}
	}
}

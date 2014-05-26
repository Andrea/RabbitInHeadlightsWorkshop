<root dataType="Struct" type="ScriptingPlugin.Resources.CSharpScript" id="129723834">
  <_x003C_Script_x003E_k__BackingField dataType="String">using Duality;
using Duality.Components;
using Duality.Resources;
using OpenTK;
using ScriptingPlugin;

namespace ScriptingNamespace
{
	public class Spawner : DualityScript
	{
		private int _lastSpawnTime;

		public float SpawnIntervalSeconds { get; set; }

		public override void Update()
		{
			base.Update();

			if (Time.GameTimer.TotalMilliseconds - _lastSpawnTime &gt; SpawnIntervalSeconds*1000)
			{
				var molePrefab = ContentProvider.RequestContent&lt;Prefab&gt;("Prefabs/Mole");
				if (molePrefab != null)
				{
					var mole = molePrefab.Res.Instantiate();
					var camera = Scene.Current.FindComponent&lt;Camera&gt;();

					var screenSize = new Vector2(DualityApp.UserData.GfxWidth, DualityApp.UserData.GfxHeight);
					var worldTopLeft = (screenSize / 2) * (camera.GameObj.Transform.Pos.Z / camera.FocusDist);
					var worldBottomRight = screenSize * (camera.GameObj.Transform.Pos.Z / camera.FocusDist);

//					var worldTopLeft = camera.GetSpaceCoord(screenTopLeft);
//					var worldBottomRight = camera.GetSpaceCoord(screenBottomRight);

					mole.Transform.Pos = new Vector3(
						(float)MathF.Rnd.NextDouble() * (worldBottomRight.X - worldTopLeft.X), 
						(float)MathF.Rnd.NextDouble() * (worldBottomRight.Y - worldTopLeft.Y), 
						0);

					Scene.Current.AddObject(mole);

					_lastSpawnTime = (int) Time.GameTimer.TotalMilliseconds;
				}
			}
		}
	}
}</_x003C_Script_x003E_k__BackingField>
  <sourcePath dataType="String">Source\Media\Scripts\Spawner.cs</sourcePath>
</root>
<!-- XmlFormatterBase Document Separator -->

/*
 * A set of static helper classes that provide easy runtime access to the games resources.
 * This file is auto-generated. Any changes made to it are lost as soon as Duality decides
 * to regenerate it.
 */
namespace GameRes
{
	public static class Data {
		public static class Prefabs {
			public static Duality.ContentRef<Duality.Resources.Prefab> Brick_Prefab { get { return Duality.ContentProvider.RequestContent<Duality.Resources.Prefab>(@"Data\Prefabs\Brick.Prefab.res"); }}
			public static Duality.ContentRef<Duality.Resources.Prefab> Mole_Prefab { get { return Duality.ContentProvider.RequestContent<Duality.Resources.Prefab>(@"Data\Prefabs\Mole.Prefab.res"); }}
			public static void LoadAll() {
				Brick_Prefab.MakeAvailable();
				Mole_Prefab.MakeAvailable();
			}
		}
		public static class Scripts {
			public static Duality.ContentRef<ScriptingPlugin.Resources.FSharpScript> ColoursPowerUp_FSharpScript { get { return Duality.ContentProvider.RequestContent<ScriptingPlugin.Resources.FSharpScript>(@"Data\Scripts\ColoursPowerUp.FSharpScript.res"); }}
			public static Duality.ContentRef<ScriptingPlugin.Resources.FSharpScript> DoubleScorePowerUp_FSharpScript { get { return Duality.ContentProvider.RequestContent<ScriptingPlugin.Resources.FSharpScript>(@"Data\Scripts\DoubleScorePowerUp.FSharpScript.res"); }}
			public static Duality.ContentRef<ScriptingPlugin.Resources.FSharpScript> SlowBallPowerUp_FSharpScript { get { return Duality.ContentProvider.RequestContent<ScriptingPlugin.Resources.FSharpScript>(@"Data\Scripts\SlowBallPowerUp.FSharpScript.res"); }}
			public static void LoadAll() {
				ColoursPowerUp_FSharpScript.MakeAvailable();
				DoubleScorePowerUp_FSharpScript.MakeAvailable();
				SlowBallPowerUp_FSharpScript.MakeAvailable();
			}
		}
		public static Duality.ContentRef<Duality.Resources.Scene> Scene_Scene { get { return Duality.ContentProvider.RequestContent<Duality.Resources.Scene>(@"Data\Scene.Scene.res"); }}
		public static void LoadAll() {
			Prefabs.LoadAll();
			Scripts.LoadAll();
			Scene_Scene.MakeAvailable();
		}
	}

}

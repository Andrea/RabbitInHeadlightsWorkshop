namespace Dualityscript

open ScriptingPlugin
open Duality
open Duality.Resources

    type DoubleScorePowerUp() =
        inherit DualityScript()
        
            override this.CollisionBegin(args) =
                Log.Game.Write("Collided with {0}", args.CollideWith.Name)
                let scoreComponent = Scene.Current.FindComponent<Debug.ScoreComponent>()
                scoreComponent.IncreaseScore(scoreComponent.Score)
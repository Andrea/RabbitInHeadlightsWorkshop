module Dualityscript

open ScriptingPlugin
open Duality
open Duality.Resources
open OpenTK

    type SlowBallPowerUp() =
        inherit DualityScript()          
            
            let changeBallVelocity changeRate =
                  let ball = Scene.Current.FindGameObject "ball"                        
                  ball.RigidBody.LinearVelocity <-  ball.RigidBody.LinearVelocity.Normalized  * changeRate

                member this.stopwatch = new System.Diagnostics.Stopwatch()
            
                override this.Update () =                
                    if(this.stopwatch.ElapsedMilliseconds > int64 500) then
                        changeBallVelocity 50.0f 
                        this.stopwatch.Reset()               

                override this.CollisionBegin(args) =
                    this.stopwatch.Start()
                    changeBallVelocity 0.5f
                
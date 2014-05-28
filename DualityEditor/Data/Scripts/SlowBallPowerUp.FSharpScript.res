<root dataType="Struct" type="ScriptingPlugin.Resources.FSharpScript" id="129723834">
  <_x003C_Script_x003E_k__BackingField dataType="String">module Dualityscript

open ScriptingPlugin
open Duality
open Duality.Resources
open OpenTK

    type SlowBallPowerUp() =
        inherit DualityScript()          
            
            let changeBallVelocity changeRate =
                  let ball = Scene.Current.FindGameObject "ball"                        
                  ball.RigidBody.LinearVelocity &lt;-  ball.RigidBody.LinearVelocity.Normalized  * changeRate

                member this.stopwatch = new System.Diagnostics.Stopwatch()
            
                override this.Update () =                
                    if(this.stopwatch.ElapsedMilliseconds &gt; int64 500) then
                        changeBallVelocity 50.0f 
                        this.stopwatch.Reset()               

                override this.CollisionBegin(args) =
                    this.stopwatch.Start()
                    changeBallVelocity 0.5f
                </_x003C_Script_x003E_k__BackingField>
  <sourcePath dataType="String">Source\Media\Scripts\SlowBallPowerUp.fs</sourcePath>
</root>
<!-- XmlFormatterBase Document Separator -->

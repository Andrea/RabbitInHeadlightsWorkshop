module Dualityscript

open ScriptingPlugin
open Duality
open OpenTK

    type MoveBall() =
        inherit DualityScript()
        
            override this.Update () =                
                this.GameObj.Transform.Pos <- this.GameObj.Transform.Pos + new Vector3(0.0f,0.0f,1.0f)
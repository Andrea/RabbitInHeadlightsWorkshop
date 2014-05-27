<root dataType="Struct" type="ScriptingPlugin.Resources.FSharpScript" id="129723834">
  <_x003C_Script_x003E_k__BackingField dataType="String">module Dualityscript

open ScriptingPlugin
open Duality
open OpenTK

    type MoveBall() =
        inherit DualityScript()
        
            override this.Update () =                
                this.GameObj.Transform.Pos &lt;- this.GameObj.Transform.Pos + new Vector3(0.0f,0.0f,2.0f)</_x003C_Script_x003E_k__BackingField>
  <sourcePath dataType="String">Source\Media\Scripts\MoveBall.fs</sourcePath>
</root>
<!-- XmlFormatterBase Document Separator -->

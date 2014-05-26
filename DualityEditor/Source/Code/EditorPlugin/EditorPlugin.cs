using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality.Editor;

namespace Debug.Editor
{
	/// <summary>
	/// Defines a Duality editor plugin.
	/// </summary>
    public class DebugEditorPlugin : EditorPlugin
	{
		public override string Id
		{
			get { return "DebugEditorPlugin"; }
		}
	}
}

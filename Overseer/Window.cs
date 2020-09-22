using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;

namespace AngelLight.Overseer
{
	public class Window : GameWindow
	{
		// Values are only temporarily hardcoded to ease learning.
		private readonly float[] _vertices =
		{
			-0.5f, -0.5f, 0.0f, // Btm-Lf
			 0.5f, -0.5f, 0.0f, // Btm-Rt
			 0.0f,  0.5f, 0.0f, // Top
		};

		private int _vertexBufferObject;
		private int _vertexArrayObject;
		public Window(int width, int height, string title)
			: base(width, height, GraphicsMode.Default, title) { }

		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			// Stores the KeyboardState each frame. KeyboardState allows the status of key pressing to be reported.
			var input = Keyboard.GetState();

			// Exits the application if the Escape key is pressed.
			if (input.IsKeyDown(Key.Escape))
			{
				Exit();
			}

			base.OnUpdateFrame(e);
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}

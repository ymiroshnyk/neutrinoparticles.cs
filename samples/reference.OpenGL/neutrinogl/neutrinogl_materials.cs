using OpenGL;
using System.Diagnostics;

partial class NeutrinoGl
{
	public class MaterialsGl
	{
		ShaderProgram program_, programMultiply_;
		int positionAttribLocation_;
		int colorAttribLocation_;
		int texAttribLocation_;

		ShaderProgram currentProgram_;
		Matrix4 projMatrix_;
		Matrix4 viewMatrix_;
		Matrix4 modelMatrix_;

		public MaterialsGl()
		{
			program_ = new ShaderProgram(VertexShader, FragmentShader);
			programMultiply_ = new ShaderProgram(VertexShader, FragmentShaderMultiply);
			currentProgram_ = null;

			positionAttribLocation_ = Gl.GetAttribLocation(program_.ProgramID, "vertexPosition");
			Debug.Assert(positionAttribLocation_ == Gl.GetAttribLocation(programMultiply_.ProgramID, "vertexPosition"));

			colorAttribLocation_ = Gl.GetAttribLocation(program_.ProgramID, "vertexColor");
			Debug.Assert(colorAttribLocation_ == Gl.GetAttribLocation(programMultiply_.ProgramID, "vertexColor"));

			texAttribLocation_ = Gl.GetAttribLocation(program_.ProgramID, "vertexUV");
			Debug.Assert(texAttribLocation_ == Gl.GetAttribLocation(programMultiply_.ProgramID, "vertexUV"));
		}

		public void shutdown()
		{
			program_.DisposeChildren = true;
			program_.Dispose();
			programMultiply_.DisposeChildren = true;
			programMultiply_.Dispose();
		}

		public int positionAttribLocation() { return positionAttribLocation_; }
		public int colorAttribLocation() { return colorAttribLocation_; }
		public int tex0AttribLocation() { return texAttribLocation_; }

		public void setup(ref Matrix4 projMatrix, ref Matrix4 viewMatrix, ref Matrix4 modelMatrix)
		{
			Gl.Disable(EnableCap.DepthTest);
			Gl.Enable(EnableCap.Blend);

			currentProgram_ = null;
			projMatrix_ = projMatrix;
			viewMatrix_ = viewMatrix;
			modelMatrix_ = modelMatrix;
		}

		public void switchToNormal()
		{
			setProgram(program_);
			Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
		}

		public void switchToAdd()
		{
			setProgram(program_);
			Gl.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.One);
		}

		public void switchToMultiply()
		{
			setProgram(programMultiply_);
			Gl.BlendFunc(BlendingFactorSrc.Zero, BlendingFactorDest.SrcColor);
		}

		void setProgram(ShaderProgram program)
		{
			if (currentProgram_ != program)
			{
				program.Use();
				program["projection_matrix"].SetValue(projMatrix_);
				program["view_matrix"].SetValue(viewMatrix_);
				program["model_matrix"].SetValue(modelMatrix_);
			}
		}

		static string VertexShader = @"
#version 130

in vec3 vertexPosition;
in vec4 vertexColor;
in vec2 vertexUV;

out vec2 uv;
out vec4 color;

uniform mat4 projection_matrix;
uniform mat4 view_matrix;
uniform mat4 model_matrix;

void main(void)
{
	uv = vertexUV;
	color = vertexColor;
	gl_Position = projection_matrix * view_matrix * model_matrix * vec4(vertexPosition, 1);
}
";
		static string FragmentShader = @"
#version 130

uniform sampler2D texture;

in vec2 uv;
in vec4 color;

void main(void)
{
	gl_FragColor = color * texture2D(texture, uv);
}
";
		static string FragmentShaderMultiply = @"
#version 130

uniform sampler2D texture;

in vec2 uv;
in vec4 color;

void main(void)
{
	vec4 texel = texture2D(texture, uv);
	vec3 rgb = color.rgb * texel.rgb;
	float a = color.a * texel.a;
	gl_FragColor = vec4(mix(vec3(1, 1, 1), rgb, a), 1);
}
";
	}
}
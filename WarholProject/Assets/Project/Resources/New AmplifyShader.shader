// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "New AmplifyShader"
{
	Properties
	{
		_WebcamTexture("WebcamTexture", 2D) = "white" {}
		_Falloff("Falloff", Range( 0 , 3)) = 1.4
		_Color1("Color 1", Color) = (1,0,0.8377495,1)
		_Color2("Color 2", Color) = (0.9670749,1,0,1)
	}
	
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		CGINCLUDE
		#pragma target 3.0
		ENDCG
		Blend Off
		Cull Back
		ColorMask RGBA
		ZWrite On
		ZTest LEqual
		Offset 0 , 0
		
		

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			

			struct appdata
			{
				float4 vertex : POSITION;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				float4 ase_texcoord : TEXCOORD0;
			};
			
			struct v2f
			{
				float4 vertex : SV_POSITION;
				UNITY_VERTEX_OUTPUT_STEREO
				float4 ase_texcoord : TEXCOORD0;
			};

			uniform sampler2D _WebcamTexture;
			uniform float4 _WebcamTexture_ST;
			uniform float _Falloff;
			uniform float4 _Color1;
			uniform float4 _Color2;
			
			v2f vert ( appdata v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				o.ase_texcoord.xy = v.ase_texcoord.xy;
				
				//setting value to unused interpolator channels and avoid initialization warnings
				o.ase_texcoord.zw = 0;
				
				v.vertex.xyz +=  float3(0,0,0) ;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i ) : SV_Target
			{
				fixed4 finalColor;
				float2 uv_WebcamTexture = i.ase_texcoord.xy * _WebcamTexture_ST.xy + _WebcamTexture_ST.zw;
				float4 temp_cast_0 = (0.2).xxxx;
				float temp_output_8_0 = length( max( tex2D( _WebcamTexture, uv_WebcamTexture ) , temp_cast_0 ) );
				float4 ifLocalVar24 = 0;
				if( temp_output_8_0 > _Falloff )
				ifLocalVar24 = _Color1;
				else if( temp_output_8_0 < _Falloff )
				ifLocalVar24 = _Color2;
				
				
				finalColor = ifLocalVar24;
				return finalColor;
			}
			ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=15401
1096;100;918;1277;1227.655;-127.2514;1;True;False
Node;AmplifyShaderEditor.TexturePropertyNode;1;-1440.236,-200.0272;Float;True;Property;_WebcamTexture;WebcamTexture;0;0;Create;False;0;0;False;0;None;None;False;white;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;3;-1205.502,-87.62669;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;22;-659.6949,152.4647;Float;False;Constant;_Float2;Float 2;1;0;Create;True;0;0;False;0;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;2;-956.994,-160.1277;Float;True;Property;_TextureSample0;Texture Sample 0;1;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMaxOpNode;23;-598.1972,57.09212;Float;False;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;26;-903.6579,564.4135;Float;False;Property;_Color1;Color 1;2;0;Create;False;0;0;False;0;1,0,0.8377495,1;1,0,0.8377495,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LengthOpNode;8;-601.6008,318.9493;Float;False;1;0;COLOR;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;25;-798.6108,489.0315;Float;False;Property;_Falloff;Falloff;1;0;Create;True;0;0;False;0;1.4;1.4;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;6;-906.7404,740.5049;Float;False;Property;_Color2;Color 2;3;0;Create;False;0;0;False;0;0.9670749,1,0,1;0.9670749,1,0,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;16;-132.5353,761.6159;Float;False;Property;_Color3;Color 3;4;0;Create;True;0;0;False;0;0,0.7750714,1,1;0,0.7750714,1,1;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;12;-94.33763,525.5569;Float;False;Constant;_Float0;Float 0;1;0;Create;True;0;0;False;0;1.08;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ConditionalIfNode;24;-498.2911,546.5386;Float;False;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;FLOAT;0;False;4;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ConditionalIfNode;17;131.6512,625.0643;Float;False;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;FLOAT;0;False;4;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-546.7429,-203.6863;Float;False;Constant;_Float1;Float 1;1;0;Create;True;0;0;False;0;2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-298.6955,-229.709;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;4;694.0008,5.072403;Float;False;True;2;Float;ASEMaterialInspector;0;1;New AmplifyShader;0770190933193b94aaa3065e307002fa;0;0;SubShader 0 Pass 0;2;True;0;1;False;-1;0;False;-1;0;1;False;-1;0;False;-1;True;-1;False;-1;-1;False;-1;True;0;False;-1;True;True;True;True;True;0;False;-1;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;1;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;1;RenderType=Opaque;True;2;0;False;False;False;False;False;False;False;False;False;False;0;;0;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;3;2;1;0
WireConnection;2;0;1;0
WireConnection;2;1;3;0
WireConnection;23;0;2;0
WireConnection;23;1;22;0
WireConnection;8;0;23;0
WireConnection;24;0;8;0
WireConnection;24;1;25;0
WireConnection;24;2;26;0
WireConnection;24;4;6;0
WireConnection;17;0;8;0
WireConnection;17;1;12;0
WireConnection;17;2;24;0
WireConnection;17;4;16;0
WireConnection;19;0;20;0
WireConnection;4;0;24;0
ASEEND*/
//CHKSM=8FACA2C47660F8A6A891EC7E3CD11CF4C5B6C956
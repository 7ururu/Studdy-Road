Shader "Studdy Road/Bending Tree" {

	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_BendAmplitude("Bend amplitude", Vector) = (0.0, 0.0, 0.0, 0.0)
		_BendSpeed("Bend speed", float) = 1.0
	}

	SubShader {

		Tags { 
			"RenderType" = "Opaque" 
		}

		CGPROGRAM

		#pragma surface surf Lambert vertex:vert addshadow

		struct Input {
			float2 uv_MainTex;
		};
		sampler2D _MainTex;
		float4 _BendAmplitude;
		float _BendSpeed;

		void vert (inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			v.vertex += _BendAmplitude * v.color.r * sin(_Time.y * _BendSpeed + v.color.g);			
		}

		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
		}

		ENDCG
    }

    Fallback "Diffuse"
}
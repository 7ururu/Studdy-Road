Shader "Studdy Road/Tests/MemeDistortion" {

	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_Distortion("Distortion", 2D) = "white" {}
		_Mask("Mask", 2D) = "white" {}

		_Speed("Speed", float) = 1.0
	}

	SubShader {

		Tags { 
			"RenderType" = "Opaque"
		}

		CGPROGRAM

		#pragma surface surf Lambert

		struct Input {
			float2 uv_MainTex;
			float2 uv_Distortion;
			float2 uv_Mask;
		};
		sampler2D _MainTex;
		sampler2D _Distortion;
		sampler2D _Mask;
		fixed _Speed;
		
		void surf (Input IN, inout SurfaceOutput o) {
			fixed2 offset = (tex2D(_Distortion, IN.uv_Distortion + float2(_Time.x, _Time.x)).rg - 0.5) * 2;
			fixed mask = tex2D(_Mask, IN.uv_Mask).a;
				
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex + offset * mask * _Speed).rgb;
		}

		ENDCG
    }

    Fallback "Diffuse"
}
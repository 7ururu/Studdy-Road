Shader "Studdy Road/Characters/Ninja" {

	Properties {
		_MainTex("Texture", 2D) = "white" {}

		_Mask("Mask", 2D) = "white" {}
		_UVMult("ScreenUV mult", float) = 1.0

		_Power("Power", Range(0.0, 1.0)) = 1.0

		_EdgeColor("Edge color", Color) = (1.0, 1.0, 1.0, 1.0)
		_EdgeValue("Edge value", float) = 0.05
	}

	SubShader {

		Tags { 
			"RenderType" = "Opaque"
		}

		CGPROGRAM

		#pragma surface surf Lambert addshadow

		struct Input {
			float2 uv_MainTex;
			float4 screenPos;
		};
		sampler2D _MainTex;
		sampler2D _Mask;
		float _UVMult;
		float _Power;
		float4 _EdgeColor;
		float _EdgeValue;
		
		void surf (Input IN, inout SurfaceOutput o) {
			float2 screenUV = IN.screenPos.xy / IN.screenPos.w * _UVMult;
			float a = tex2D(_Mask, screenUV).a;
			float v = ((a + 1.0) * _Power - 0.5) * 2.0;
			clip(v);
			if (v <= _EdgeValue) {
				o.Albedo = _EdgeColor;
			} else {
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			}
		}

		ENDCG
    }

    Fallback "Diffuse"
}
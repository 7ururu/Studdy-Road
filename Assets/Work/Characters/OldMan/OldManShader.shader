Shader "Studdy Road/Characters/OldMan" {

	Properties {
		_MainTex("Texture", 2D) = "white" {}
		_SecondTex("Texture", 2D) = "white" {}
		_Power("Power", Range(0, 1)) = 0
		_Amplitude("Amplitude", float) = 0
		_BlendPower("BlendPower", Range(0, 1)) = 0
	}

	SubShader {

		Tags { 
			"RenderType" = "Opaque" 
		}

		CGPROGRAM
		
		#pragma surface surf Lambert vertex:vert addshadow

		struct Input {
			float2 uv_MainTex;
			float2 uv2_SecondTex;
		};
		sampler2D _MainTex;
		sampler2D _SecondTex;
		float _Power;
		float _Amplitude;
		float _BlendPower;

		void vert (inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			v.vertex.x += _Power * v.color.r * _Amplitude * sign(v.vertex.x);	
		}

		void surf (Input IN, inout SurfaceOutput o) {
			fixed3 a = tex2D(_MainTex, IN.uv_MainTex).rgb;
			fixed4 b = tex2D(_SecondTex, IN.uv2_SecondTex).rgba;
			o.Albedo = lerp(a, a * (1 - b.a) + b.rgb * b.a, _BlendPower);
		}

		ENDCG
    }

    Fallback "Diffuse"
}
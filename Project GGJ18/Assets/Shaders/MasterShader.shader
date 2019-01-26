Shader "GGJ18/Master" 
{
    Properties {
		_myTex("Texture", 2D) = "white" {}
		_myTexColor("Texture Color", Color) = (1,1,1,1)
		_myRange("Emission", Range(0,1)) = 1
        _myEmissionColor ("Emission Color", Color) = (1,1,1,1)
    }
    SubShader {

      CGPROGRAM
        #pragma surface surf Lambert
        
		sampler2D _myTex;
		fixed4 _myTexColor;
		half _myRange;
        fixed4 _myEmissionColor;

        struct Input {
            float2 uv_myTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = (tex2D(_myTex, IN.uv_myTex) * _myTexColor).rgb;
            o.Emission = ((tex2D(_myTex, IN.uv_myTex) * _myEmissionColor) * _myRange).rgb;
        }
      
      ENDCG
    }
    Fallback "Diffuse"
  }

Shader "Custom/WaterWaveShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _WaterColor ("Water Color", Color) = (0, 0.5, 1, 0.8)
        _RippleColor ("Ripple Color", Color) = (1, 1, 1, 1)
        _Amplitude ("Amplitude", Range(0, 1)) = 0.1
        _Frequency ("Frequency", Range(0, 10)) = 4
        _Speed ("Speed", Range(0, 5)) = 2
    }

    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        float4 _WaterColor;
        float4 _RippleColor;
        float _Amplitude;
        float _Frequency;
        float _Speed;

        struct Input {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o) {
            float2 wave = _Amplitude * sin(_Frequency * (IN.uv_MainTex * 2 - _Speed * _Time.y));
            float2 uv = IN.uv_MainTex + wave;
            o.Albedo = _WaterColor.rgb;
            o.Alpha = _WaterColor.a;
            o.Specular = tex2D(_MainTex, uv).r;
            o.Gloss = 1;
            o.Normal = UnpackNormal(tex2D(_MainTex, uv));
            o.Emission = o.Normal * _RippleColor;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

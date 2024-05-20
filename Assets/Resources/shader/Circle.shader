Shader "Custom/Circle"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _AreaColor ("Area Color", Color) = (1,1,1,1)
        _Center ("Center", Vector) = (0,0,0,0)
        _Radius ("Radius", Range(0,500)) = 75
        _Border ("Border", Range(0,100)) = 12
        _Alpha ("Alpha", Range(0,1)) = 0.5 // 추가: 강제로 설정할 반투명 알파값
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha

        sampler2D _MainTex;
        fixed4 _AreaColor;
        float3 _Center;
        float _Radius;
        float _Border;
        float _Alpha; // 추가: 사용자가 설정한 반투명 알파값

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };
     
        void surf (Input IN, inout SurfaceOutput o)
        {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);
            float dist = distance(_Center, IN.worldPos);

            // Clip pixels outside the radius plus the border
            if(dist > _Radius + _Border)
            {
                clip(-1); // Clip this pixel
            }

            if(dist > _Radius && dist < _Radius + _Border)
            {
                o.Albedo = _AreaColor.rgb;
            }
            else
            {
                o.Albedo = c.rgb;
            }

            o.Alpha = _Alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

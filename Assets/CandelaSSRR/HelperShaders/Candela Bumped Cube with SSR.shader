Shader "CandelaSSRR/Bumped Cubemap Specular SSR" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
	_Shininess ("Shininess", Range (0.01, 1)) = 0.078125
	_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
	_MainTex ("Base (RGB) RefStrGloss (A)", 2D) = "white" {}
	_SpecTex ("Specular(RGB) Roughness(A)", 2D) = "white" {}
	_Cube ("Reflection Cubemap", Cube) = "" 
	_BumpMap ("Normalmap", 2D) = "bump" {}
}

SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 400
CGPROGRAM
#pragma surface surf BlinnPhong
#pragma target 3.0
//input limit (8) exceeded, shader uses 9
#pragma exclude_renderers d3d11_9x

sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _SpecTex;
samplerCUBE _Cube;

fixed4 _Color;
fixed4 _ReflectColor;
half _Shininess;

struct Input {
	float2 uv_MainTex;
	float2 uv_BumpMap;
	float3 worldRefl;
	INTERNAL_DATA
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	half4 SPG = tex2D(_SpecTex, IN.uv_MainTex);
			
	fixed4 c = tex * _Color;
	o.Albedo = c.rgb;
	
	o.Gloss = tex.a;
	o.Specular = clamp(_Shininess*SPG.a,0.01,1.0);
	
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	
	float3 worldRefl = WorldReflectionVector (IN, o.Normal);
	fixed4 reflcol = texCUBE (_Cube, worldRefl);
	reflcol *= tex.a;
	o.Emission = reflcol.rgb * _ReflectColor.rgb;
	o.Alpha = _Color.a*tex.a;
}
ENDCG
}

FallBack "Reflective/Bumped Diffuse"
}

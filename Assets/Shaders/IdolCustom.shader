// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-110-OUT,clip-3845-A,olwid-9105-OUT,olcol-9248-OUT;n:type:ShaderForge.SFN_NormalVector,id:4285,x:30474,y:32453,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:1827,x:30509,y:32692,varname:node_1827,prsc:2;n:type:ShaderForge.SFN_Dot,id:8470,x:30779,y:32625,varname:node_8470,prsc:2,dt:0|A-4285-OUT,B-1827-OUT;n:type:ShaderForge.SFN_Tex2d,id:4069,x:31124,y:32262,ptovrint:False,ptlb:BaseTexture,ptin:_BaseTexture,varname:node_4069,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:856256c2c5af03f44afdcaf410414a7f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:2440,x:32050,y:32665,varname:node_2440,prsc:2|A-4387-OUT,B-7290-OUT,T-1606-OUT;n:type:ShaderForge.SFN_Multiply,id:7290,x:31465,y:32365,varname:node_7290,prsc:2|A-4069-RGB,B-5808-OUT;n:type:ShaderForge.SFN_RemapRange,id:1944,x:30976,y:32767,varname:node_1944,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8470-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7919,x:31321,y:33473,varname:node_7919,prsc:2|IN-321-OUT,IMIN-7106-OUT,IMAX-4614-OUT,OMIN-3871-OUT,OMAX-7153-OUT;n:type:ShaderForge.SFN_Clamp01,id:1172,x:31626,y:33426,varname:node_1172,prsc:2|IN-7919-OUT;n:type:ShaderForge.SFN_Slider,id:6941,x:31920,y:33633,ptovrint:False,ptlb:OutLineWidth,ptin:_OutLineWidth,varname:node_6941,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01,max:0.01;n:type:ShaderForge.SFN_Slider,id:2326,x:30554,y:33828,ptovrint:False,ptlb:Mix_Shadow,ptin:_Mix_Shadow,varname:node_2326,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.4999;n:type:ShaderForge.SFN_Slider,id:4614,x:30537,y:33985,ptovrint:False,ptlb:Mix_Base,ptin:_Mix_Base,varname:node_4614,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:0.4999;n:type:ShaderForge.SFN_Color,id:7685,x:31576,y:32238,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_7685,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:4387,x:31874,y:32444,varname:node_4387,prsc:2|A-7685-RGB,B-4069-RGB;n:type:ShaderForge.SFN_Color,id:5761,x:31571,y:33833,ptovrint:False,ptlb:OutLineColor,ptin:_OutLineColor,varname:node_5761,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:6147,x:31571,y:33583,varname:node_6147,prsc:2|A-4069-RGB,B-4069-RGB;n:type:ShaderForge.SFN_Multiply,id:9248,x:31764,y:33672,varname:node_9248,prsc:2|A-5761-RGB,B-6147-OUT;n:type:ShaderForge.SFN_OneMinus,id:5550,x:31159,y:32797,varname:node_5550,prsc:2|IN-1944-OUT;n:type:ShaderForge.SFN_OneMinus,id:7106,x:30988,y:33488,varname:node_7106,prsc:2|IN-2326-OUT;n:type:ShaderForge.SFN_Color,id:152,x:31101,y:32623,ptovrint:False,ptlb:ShadowColor,ptin:_ShadowColor,varname:node_152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:9725,x:31659,y:32750,ptovrint:False,ptlb:shadowmask,ptin:_shadowmask,varname:node_9725,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1fa1c5547e037ec4dafe55d6ecd0f0b8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1606,x:31865,y:32819,varname:node_1606,prsc:2|A-9725-RGB,B-1172-OUT;n:type:ShaderForge.SFN_Multiply,id:8841,x:32041,y:33744,varname:node_8841,prsc:2|A-6941-OUT,B-2455-RGB;n:type:ShaderForge.SFN_Tex2d,id:2455,x:31810,y:33927,ptovrint:False,ptlb:outlinemask,ptin:_outlinemask,varname:node_2455,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ComponentMask,id:9105,x:32900,y:33218,varname:node_9105,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8841-OUT;n:type:ShaderForge.SFN_Tex2d,id:8786,x:31101,y:32451,ptovrint:False,ptlb:ShadowColorTexture,ptin:_ShadowColorTexture,varname:node_8786,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:5808,x:31290,y:32497,varname:node_5808,prsc:2|A-8786-RGB,B-152-RGB;n:type:ShaderForge.SFN_Vector1,id:3871,x:31041,y:33691,varname:node_3871,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7153,x:31098,y:33833,varname:node_7153,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:321,x:30957,y:33092,varname:node_321,prsc:2|A-5550-OUT,B-1090-OUT;n:type:ShaderForge.SFN_Slider,id:689,x:30299,y:33080,ptovrint:False,ptlb:ShadowSize,ptin:_ShadowSize,varname:node_689,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_NormalVector,id:6439,x:30975,y:34011,prsc:2,pt:False;n:type:ShaderForge.SFN_NormalVector,id:2865,x:30996,y:34183,prsc:2,pt:False;n:type:ShaderForge.SFN_SwitchProperty,id:5739,x:31205,y:34089,ptovrint:False,ptlb:node_5739,ptin:_node_5739,varname:node_5739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-6439-OUT,B-2865-OUT;n:type:ShaderForge.SFN_ViewVector,id:3645,x:31187,y:34318,varname:node_3645,prsc:2;n:type:ShaderForge.SFN_Dot,id:4549,x:31392,y:34172,varname:node_4549,prsc:2,dt:0|A-5739-OUT,B-3645-OUT;n:type:ShaderForge.SFN_OneMinus,id:2684,x:31568,y:34203,varname:node_2684,prsc:2|IN-4549-OUT;n:type:ShaderForge.SFN_Power,id:766,x:31818,y:34230,varname:node_766,prsc:2|VAL-2684-OUT,EXP-5873-OUT;n:type:ShaderForge.SFN_Multiply,id:5873,x:31619,y:34376,varname:node_5873,prsc:2|A-9659-OUT,B-5747-OUT;n:type:ShaderForge.SFN_Vector1,id:5747,x:31398,y:34524,varname:node_5747,prsc:2,v1:2;n:type:ShaderForge.SFN_Slider,id:9659,x:31241,y:34445,ptovrint:False,ptlb:Rim_Sharpness,ptin:_Rim_Sharpness,varname:node_9659,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Clamp01,id:3772,x:32020,y:34242,varname:node_3772,prsc:2|IN-766-OUT;n:type:ShaderForge.SFN_Multiply,id:5621,x:32218,y:34305,varname:node_5621,prsc:2|A-3772-OUT,B-1668-RGB;n:type:ShaderForge.SFN_Color,id:1668,x:31882,y:34548,ptovrint:False,ptlb:Rim_Color,ptin:_Rim_Color,varname:node_1668,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:110,x:32380,y:32868,varname:node_110,prsc:2|A-2440-OUT,B-1252-OUT;n:type:ShaderForge.SFN_Multiply,id:8458,x:32383,y:34040,varname:node_8458,prsc:2|A-8470-OUT,B-5621-OUT;n:type:ShaderForge.SFN_Multiply,id:1090,x:30711,y:33192,varname:node_1090,prsc:2|A-689-OUT,B-5317-RGB;n:type:ShaderForge.SFN_Tex2d,id:5317,x:30456,y:33274,ptovrint:False,ptlb:ShasowSizeMap,ptin:_ShasowSizeMap,varname:node_5317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1252,x:32118,y:33078,varname:node_1252,prsc:2|A-5317-RGB,B-8458-OUT;n:type:ShaderForge.SFN_Tex2d,id:3845,x:32438,y:32700,ptovrint:False,ptlb:node_3845,ptin:_node_3845,varname:node_3845,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;proporder:4069-7685-689-2326-4614-8786-152-9725-6941-5761-2455-5739-9659-1668-5317-3845;pass:END;sub:END;*/

Shader "Shader Forge/sd" {
    Properties {
        _BaseTexture ("BaseTexture", 2D) = "white" {}
        _BaseColor ("BaseColor", Color) = (1,1,1,1)
        _ShadowSize ("ShadowSize", Range(0, 3)) = 1
        _Mix_Shadow ("Mix_Shadow", Range(0, 0.4999)) = 0
        _Mix_Base ("Mix_Base", Range(0, 0.4999)) = 0
        _ShadowColorTexture ("ShadowColorTexture", 2D) = "white" {}
        _ShadowColor ("ShadowColor", Color) = (1,1,1,1)
        _shadowmask ("shadowmask", 2D) = "white" {}
        _OutLineWidth ("OutLineWidth", Range(0, 0.01)) = 0.01
        _OutLineColor ("OutLineColor", Color) = (0,0,0,1)
        _outlinemask ("outlinemask", 2D) = "white" {}
        [MaterialToggle] _node_5739 ("node_5739", Float ) = 0
        _Rim_Sharpness ("Rim_Sharpness", Range(0, 5)) = 0
        _Rim_Color ("Rim_Color", Color) = (0.5,0.5,0.5,1)
        _ShasowSizeMap ("ShasowSizeMap", 2D) = "white" {}
        _node_3845 ("node_3845", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _OutLineWidth;
            uniform float4 _OutLineColor;
            uniform sampler2D _outlinemask; uniform float4 _outlinemask_ST;
            uniform sampler2D _node_3845; uniform float4 _node_3845_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 _outlinemask_var = tex2Dlod(_outlinemask,float4(TRANSFORM_TEX(o.uv0, _outlinemask),0.0,0));
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*(_OutLineWidth*_outlinemask_var.rgb).r,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_3845_var = tex2D(_node_3845,TRANSFORM_TEX(i.uv0, _node_3845));
                clip(_node_3845_var.a - 0.5);
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                return fixed4((_OutLineColor.rgb*(_BaseTexture_var.rgb*_BaseTexture_var.rgb)),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _Mix_Shadow;
            uniform float _Mix_Base;
            uniform float4 _BaseColor;
            uniform float4 _ShadowColor;
            uniform sampler2D _shadowmask; uniform float4 _shadowmask_ST;
            uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
            uniform float _ShadowSize;
            uniform fixed _node_5739;
            uniform float _Rim_Sharpness;
            uniform float4 _Rim_Color;
            uniform sampler2D _ShasowSizeMap; uniform float4 _ShasowSizeMap_ST;
            uniform sampler2D _node_3845; uniform float4 _node_3845_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _node_3845_var = tex2D(_node_3845,TRANSFORM_TEX(i.uv0, _node_3845));
                clip(_node_3845_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _BaseTexture_var = tex2D(_BaseTexture,TRANSFORM_TEX(i.uv0, _BaseTexture));
                float4 _ShadowColorTexture_var = tex2D(_ShadowColorTexture,TRANSFORM_TEX(i.uv0, _ShadowColorTexture));
                float4 _shadowmask_var = tex2D(_shadowmask,TRANSFORM_TEX(i.uv0, _shadowmask));
                float node_8470 = dot(i.normalDir,lightDirection);
                float4 _ShasowSizeMap_var = tex2D(_ShasowSizeMap,TRANSFORM_TEX(i.uv0, _ShasowSizeMap));
                float node_7106 = (1.0 - _Mix_Shadow);
                float node_3871 = 1.0;
                float3 emissive = (lerp((_BaseColor.rgb*_BaseTexture_var.rgb),(_BaseTexture_var.rgb*(_ShadowColorTexture_var.rgb*_ShadowColor.rgb)),(_shadowmask_var.rgb*saturate((node_3871 + ( (((1.0 - (node_8470*0.5+0.5))*(_ShadowSize*_ShasowSizeMap_var.rgb)) - node_7106) * (0.0 - node_3871) ) / (_Mix_Base - node_7106)))))+(_ShasowSizeMap_var.rgb*(node_8470*(saturate(pow((1.0 - dot(lerp( i.normalDir, i.normalDir, _node_5739 ),viewDirection)),(_Rim_Sharpness*2.0)))*_Rim_Color.rgb))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _BaseTexture; uniform float4 _BaseTexture_ST;
            uniform float _Mix_Shadow;
            uniform float _Mix_Base;
            uniform float4 _BaseColor;
            uniform float4 _ShadowColor;
            uniform sampler2D _shadowmask; uniform float4 _shadowmask_ST;
            uniform sampler2D _ShadowColorTexture; uniform float4 _ShadowColorTexture_ST;
            uniform float _ShadowSize;
            uniform fixed _node_5739;
            uniform float _Rim_Sharpness;
            uniform float4 _Rim_Color;
            uniform sampler2D _ShasowSizeMap; uniform float4 _ShasowSizeMap_ST;
            uniform sampler2D _node_3845; uniform float4 _node_3845_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _node_3845_var = tex2D(_node_3845,TRANSFORM_TEX(i.uv0, _node_3845));
                clip(_node_3845_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_3845; uniform float4 _node_3845_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_3845_var = tex2D(_node_3845,TRANSFORM_TEX(i.uv0, _node_3845));
                clip(_node_3845_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

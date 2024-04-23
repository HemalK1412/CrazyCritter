Shader "ColorFilter"
{
    Properties
    {
        _MainTexture ("Base (RGB)", 2D) = "white" {}
        RV("RedMix", Color) = (1,0,0,1)
        GV("GreenMix", Color) = (0,1,0,1)
        BV("BlueMix", Color) = (0,0,1,1)
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            uniform sampler2D _MainTexture;
            uniform fixed3 RV;
            uniform fixed3 GV;
            uniform fixed3 BV;

            fixed4 frag(v2f_img uvLocation) : COLOR
            {
                fixed4 pixelLocation = tex2D(_MainTexture, uvLocation.uv);
                
                return fixed4
                (
                    pixelLocation.r * RV[0] + pixelLocation.g * RV[1] + pixelLocation.b * RV[2],
                    pixelLocation.r * GV[0] + pixelLocation.g * GV[1] + pixelLocation.b * GV[2],
                    pixelLocation.r * BV[0] + pixelLocation.g * BV[1] + pixelLocation.b * BV[2],
                    pixelLocation.a
                );
            }
            ENDCG
        }
    }
}

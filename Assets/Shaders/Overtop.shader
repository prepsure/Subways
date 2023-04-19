Shader "Overtop"
{
    Properties
    {
        [MainColor]
        _ColorInfront("Color Infront", Color) = (1,1,1,1)
        _ColorBehind("Color Behind", Color) = (1,1,1,1)
        
    }
        SubShader
    {
        Tags { "Queue" = "Transparent+1" }
        Pass
        {
            ZTest Less
            Color[_ColorInfront]
        }

        Pass
        {
            ZTest Greater
            Color[_ColorBehind]
        }

    }
}
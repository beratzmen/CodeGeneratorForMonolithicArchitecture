﻿using CodeGenerator.Extensions;

namespace CodeGenerator.Generator;

public static partial class Generate
{
    private static string GetFileHeader()
    {
        return @"
//---------------------------------------------------------------------//
// <auto-generated>                                                    //
// This code was generated by a tool. Changes to this file may cause   //
// incorrect behavior and will be lost if the code is regenerated.     //
// I would like to thank Mehmet Yasin Akar for his vision and effort.  //
// Written by Berat Özmen.                                             //
// </auto-generated>                                                   //
//---------------------------------------------------------------------//
            ".TrimFileContent();
    }

    private static string TernaryHelper(bool condition, string @true, string @false)
        => condition ? @true : @false;
}
﻿using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
public class ClientVersion
{
    public int Version;//存档版本
    public string strVersion;//软件版本
}

public class AppInfo
{
    public const string versionKey = "APPVERSION";
    public static string AppVersion()
    {
        string sVersion = PlayerPrefs.GetString(versionKey);
        if (string.IsNullOrEmpty(sVersion))
            PlayerPrefs.SetString(versionKey, "0.0.0.0");
        return PlayerPrefs.GetString(versionKey);
    }

    public static void SetAppVersion(string v)
    {
        PlayerPrefs.SetString(versionKey, v);
    }
    public const int Version = 20180502;
    public static string MeteorVersion = "9.07";
    //运行帧速率设置 60 = 12 30 = 6 120 = 24
#if UNITY_IOS || UNITY_ANDROID
    public static int waitForNextInput = 10;//2个输入中间最大间隔6帧超过即断开.
    public static int targetFrame = 30;
#elif UNITY_EDITOR
    public static int waitForNextInput = 12;//2个输入中间最大间隔24帧超过即断开.
    public static int targetFrame = 120;
#endif
#if LOCALHOST
    public static string Domain = "127.0.0.1";
#else
    public static string Domain = "www.idevgame.com";
#endif
    public static ushort GatePort = 7200;
}
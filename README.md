# Android Auxiliary Demo

Android Auxiliary插件的Demo演示，对应的aar包及安卓部分查看[JYX-MOD/Android-Auxiliary](https://github.com/JYX-MOD/Android-Auxiliary)

## 使用方法

本项目`Assets\Scripts\Test.cs`是一个实例调用功能的脚本。

主要包括以下几个功能：

### 1. 弹窗显示

``` csharp
AndroidTools.ShowToast(the-Text-You-Want-ToShow);
```

### 2. 安卓10+的存储权限获取

``` csharp
// 下面这三个是Unity自带的权限获取，实测没有什么作用
Permission.RequestUserPermission(Permission.ExternalStorageRead);
Permission.RequestUserPermission(Permission.ExternalStorageWrite);
Permission.RequestUserPermission("android.permission.MANAGE_EXTERNAL_STORAGE");
// 这个是本项目内自带的权限获取功能
AndroidTools.GetFileAccessPermission();
```

具体使用时候可以在应用程序启动时尽早获取，可以写成如下形式：

``` csharp
[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
public static void Init()
{
    Permission.RequestUserPermission(Permission.ExternalStorageRead);
    Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    Permission.RequestUserPermission("android.permission.MANAGE_EXTERNAL_STORAGE");
    // 获取文件权限
    AndroidTools.GetFileAccessPermission();
}
```

### 3. 选择文件夹并获取其路径

执行这一步骤前必须先获得安卓对应的权限（对应第2步）

``` csharp
AndroidTools.PickDirectory(path =>
{
    // 获取到path后执行的操作
});
```

## 参考

[How can I browse files on Android outside of the Unity App folder?](https://answers.unity.com/questions/1279669/how-can-i-browse-files-on-android-outside-of-the-u.html)

[Permission.RequestUserPermission - Unity官方文档](https://docs.unity3d.com/2021.3/Documentation/ScriptReference/Android.Permission.RequestUserPermission.html)

[【100个 Unity踩坑小知识点】| Unity调用API ，动态获取Android权限，附带所有Android权限表格](https://blog.csdn.net/zhangay1998/article/details/123397449?spm=1001.2014.3001.5506)
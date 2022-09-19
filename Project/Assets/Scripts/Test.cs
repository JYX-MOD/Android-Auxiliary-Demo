using System.IO;
using AndroidAuxiliary.Plugins.Auxiliary.AndroidBridge;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class Test : MonoBehaviour
{
    public Button toastBtn;
    public Button dirPickBtn;

    public InputField toastContent;
    public InputField dirPath;
    public InputField fileName;
    public InputField fileContent;

    private void Start()
    {
        toastBtn.onClick.AddListener(() =>
        {
            // 调用弹窗显示
            AndroidTools.ShowToast(toastContent.text);
        });

        dirPickBtn.onClick.AddListener(delegate
        {
            // 调用文件夹选择
            AndroidTools.PickDirectory(path =>
            {
                dirPath.text = path;
                // 写入文本内容
                if (!Directory.Exists(path)) return;
                var fs = new FileStream(Path.Combine(path, fileName.text),
                    FileMode.Create); //path为你想保存文件的路径。downloadVideoName 为文件名
                fs.Write(System.Text.Encoding.UTF8.GetBytes(fileContent.text));
                fs.Close();
            });
        });
    }
    
    //初始化，权限申请要尽可能早
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {
        Permission.RequestUserPermission(Permission.ExternalStorageRead);
        Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        Permission.RequestUserPermission("android.permission.MANAGE_EXTERNAL_STORAGE");
        // 获取文件权限
        AndroidTools.GetFileAccessPermission();
    }
}

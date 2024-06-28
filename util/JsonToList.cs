using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mini_Game_Godot.util
{
    public static class JsonToList
    {
        public static List<T> getList<T>(string jsonFilePath) where T : class
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            // 检查文件路径是否为空
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new ArgumentNullException(nameof(jsonFilePath), "JSON文件路径不能为空");
            }
            // 检查文件是否存在
            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("找不到指定的JSON文件", jsonFilePath);
            }
            // 读取文件内容
            string jsonString = File.ReadAllText(jsonFilePath);
            // 空值检查
            if (string.IsNullOrEmpty(jsonString))
            {
                throw new ArgumentException("JSON文件内容为空", nameof(jsonFilePath));
            }
            // 将JSON字符串转化为Person对象
            List<T> list = JsonSerializer.Deserialize<List<T>>(jsonString);
            // 空值检查
            if (list == null)
            {
                throw new InvalidOperationException("无法将JSON内容反序列化为对象列表");
            }
            return list;
        }
    }
}

using Mini_Game_Godot.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Game_Godot.util
{
    public static class ReorderList
    {
        //洗牌算法生成新随机集合
        public static List<T> GenerateRandomList<T>(List<T> list, int numbern)
        {
            Random random = new Random();

            // 复制原始集合以防止修改原始数据
            List<T> newList = new List<T>(list);

            // 使用 Fisher-Yates 洗牌算法来打乱集合顺序
            newList = Shuffle(newList);

            // 如果 n 大于新集合的长度，则将新集合扩展为 n 长度
            while (newList.Count < numbern)
            {
                //长度不够  用多个拼接
                newList.AddRange(list);
            }

            // 如果 n 小于新集合的长度，则从新集合中随机选择 n 个元素
            if (newList.Count > numbern)
            {
                newList = newList.OrderBy(x => random.Next()).Take(numbern).ToList();
            }
            return newList;
        }
        //随机生成特定描述的垃圾清单
        public static List<Rubbish> getRubbishRandomListSpecial(List<Rubbish> rubbish, int description, int TrueRequired, int BoxNumber)
        {
            // 复制原始集合以防止修改原始数据
            List<Rubbish> newList = new List<Rubbish>(rubbish);
            // 用于存储已经添加过的 id
            HashSet<int> addedId = new HashSet<int>();
            // 最终垃圾清单
            List<Rubbish> randomizedRubbishList = new List<Rubbish>();
            int num = BoxNumber;
            int count = TrueRequired;
            randomizedRubbishList.Clear();

            // 添加特定描述的对象
            for (int i = 0; randomizedRubbishList.Count < count; i++)
            {
                if (newList[i].description == description && addedId.Add(newList[i].id))
                {
                    randomizedRubbishList.Add(newList[i]);
                    num--;
                }
            }
            // 添加非特定描述的对象
            foreach (var rubbishItem in newList)
            {
                if (num == 0)
                    break;

                if (rubbishItem.description != description && addedId.Add(rubbishItem.id))
                {
                    randomizedRubbishList.Add(rubbishItem);
                    num--;
                }
            }
            // 随机化列表顺序
            randomizedRubbishList = Shuffle(randomizedRubbishList);
            return randomizedRubbishList;
        }
        // 随机化列表顺序的方法
        private static List<T> Shuffle<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }
    }
}

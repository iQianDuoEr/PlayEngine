using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrameWork
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// 尝试将键和值添加到字典中:如果不存在，才添加；存在，不添加也不抛异常
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key) == false)
                dict.Add(key, value);
            return dict;
        }

        /// <summary>
        /// 将键和值添加或者替换到字典中：如果不存在，则添加；存在，则替换
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
            return dict;
        }
    }
}

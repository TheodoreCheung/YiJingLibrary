using System;
using System.Collections.Generic;

namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 可扩展属性类，用于为易经元素添加额外的属性信息。
/// </summary>
public class ExtensibleAttribute
{
    /// <summary>
    /// 存储扩展属性的字典。
    /// </summary>
    private readonly Dictionary<string, YiJingElement> _attributes = new();

    /// <summary>
    /// 获取所有扩展属性。
    /// </summary>
    public IReadOnlyCollection<YiJingElement> All => _attributes.Values;
    
    /// <summary>
    /// 添加扩展属性。
    /// </summary>
    /// <param name="attribute">扩展元素属性。派生自<see cref="YiJingElement"/>。</param>
    /// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
    /// <returns>返回当前实例，支持链式调用。</returns>
    public ExtensibleAttribute Set<T>(T attribute) where T : YiJingElement
    {
        ArgumentNullException.ThrowIfNull(attribute);
    
        _attributes.Add(typeof(T).Name, attribute);
    
        return this;
    }
    
    /// <summary>
    /// 获取指定类型的扩展属性。
    /// </summary>
    /// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
    /// <returns>返回指定类型的扩展属性，如果不存在则返回null。</returns>
    public T? Get<T>() where T : YiJingElement
    {
        if (_attributes.TryGetValue(typeof(T).Name, out var attribute))
            return (T)attribute;
    
        return null;
    }
    
    /// <summary>
    /// 尝试获取指定类型的扩展属性。
    /// </summary>
    /// <param name="result">如果成功获取，则返回指定类型的扩展属性；否则返回null。</param>
    /// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
    /// <returns>返回是否成功获取指定类型的扩展属性。</returns>
    public bool TryGet<T>(out T? result) where T : YiJingElement
    {
        if (_attributes.TryGetValue(typeof(T).Name, out var attribute))
        {
            result = (T)attribute;
            return true;
        }
        result = null;
        return false;
    }

    /// <summary>
    /// 根据属性名称获取扩展属性。
    /// </summary>
    /// <param name="attributeName">属性名称。</param>
    /// <returns>返回指定名称的扩展属性，如果不存在则返回null。</returns>
    public YiJingElement? Get(string attributeName) => _attributes.GetValueOrDefault(attributeName);
}
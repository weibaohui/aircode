using System.Text;
using System.Text.Json;
using AntDesign;
using Microsoft.AspNetCore.Components;

namespace AirCode.Pages;

public partial class Index : ComponentBase
{
    private Course _course;

    List<Course> _courses = new()
    {
        new("第一章 JS", "IA==", "97")
        {
            Items = new List<Course>()
            {
                new("第一节 认识JS", "IA==", "98")
                {
                    Items = new List<Course>()
                    {
                        new("JS简介",
                            "PGEgaHJlZj0iamF2YXNjcmlwdDp2b2lkKDApOyI+ZGF0ZTwvYT4KICAgICAgICAgICAgICAgIDxicj4KICAgICAgICAgICAgICAgIDxhIGhyZWY9ImphdmFzY3JpcHQ6dm9pZCgwKTsiIG9uY2xpY2s9ImNhbGxDaGlsZCh0aGlzKSI+a3ViZWN0bCBnZXQgcG9kcyA8L2E+CiAgICAgICAgICAgICAgICA8YnI+CiAgICAgICAgICAgICAgICA8YSBocmVmPSJqYXZhc2NyaXB0OnZvaWQoMCk7IiBvbmNsaWNrPSJjYWxsQ2hpbGQodGhpcykiPndob2FtaTwvYT4KICAgICAgICAgICAgICAgIDxicj4="
                            , "0"),
                        new("JS输出",
                            "MTExMTExCgo8YSBocmVmPSJqYXZhc2NyaXB0OnZvaWQoMCk7IiAgb25jbGljaz0iY2FsbENoaWxkKHRoaXMpIj5kYXRlPC9hPgogICAgICAgICAgICAgICAgPGJyPgogICAgICAgICAgICAgICAgPGEgaHJlZj0iamF2YXNjcmlwdDp2b2lkKDApOyIgb25jbGljaz0iY2FsbENoaWxkKHRoaXMpIj5rdWJlY3RsIGdldCBwb2RzIDwvYT4KICAgICAgICAgICAgICAgIDxicj4KICAgICAgICAgICAgICAgIDxhIGhyZWY9ImphdmFzY3JpcHQ6dm9pZCgwKTsiIG9uY2xpY2s9ImNhbGxDaGlsZCh0aGlzKSI+d2hvYW1pPC9hPgogICAgICAgICAgICAgICAgPGJyPg==",
                            "1"
                        ),
                        new("JS语句",
                            "SlPor63lj6UKPGEgaHJlZj0iamF2YXNjcmlwdDp2b2lkKDApOyIgIG9uY2xpY2s9ImNhbGxDaGlsZCh0aGlzKSI+Z2V0IGpzIDwvYT4KICAgICAgICAgICAgICAgIDxicj4KICAgICAgICAgICAgICAgIDxhIGhyZWY9ImphdmFzY3JpcHQ6dm9pZCgwKTsiIG9uY2xpY2s9ImNhbGxDaGlsZCh0aGlzKSI+anF1ZXJ5PC9hPgogICAgICAgICAgICAgICAgPGJyPgogICAgICAgICAgICAgICAgPGEgaHJlZj0iamF2YXNjcmlwdDp2b2lkKDApOyIgb25jbGljaz0iY2FsbENoaWxkKHRoaXMpIj5qcyBhcnJheTwvYT4KICAgICAgICAgICAgICAgIDxicj4=",
                            "2"
                        )
                    }
                },
                new("第二节 JS语法", "IA==", "99")
                {
                    Items = new List<Course>()
                    {
                        new("JS 数组", "IA==", "3"),
                        new("JS 日期", "IA==", "4"),
                        new("JS 随机", "IA==", "5"),
                    }
                },
                new("第三节 JS调试", "IA==", "6")
                {
                    Items = new List<Course>()
                    {
                        new("JS 错误", "IA==", "7"),
                        new("JS 性能", "IA==", "8"),
                        new("JS 保留词", "IA==", "9"),
                    }
                },
            }
        },
        new("第二章 JS对象", "IA==", "10")
        {
            Items = new List<Course>()
            {
                new("JS 对象定义", "IA==", "11"),
                new("JS 对象方法", "IA==", "12"),
                new("JS 对象属性", "IA==", "13"),
            }
        },
        new("第三章 JS函数", "IA==", "14")
        {
            Items = new List<Course>()
            {
                new("JS 函数定义", "IA==", "15"),
                new("JS 函数参数", "IA==", "16"),
            }
        }
    };

    private string[] _selectedKeys = Array.Empty<string>();

    Tree<Course>? tree;

    void OnCourseClicked(TreeEventArgs<Course> e)
    {
        _course       = e.Node.DataItem;
        _selectedKeys = new[] { $"{_course.Key}" };
        Console.WriteLine(JsonSerializer.Serialize(e.Node.DataItem));
    }

    void OnNextClicked()
    {
        var s = _course.Key;
        var n = Convert.ToInt32(s) + 1;
        _selectedKeys = new[] { $"{n}" };
    }

    void OnSelect(TreeEventArgs<string> e)
    {
        Console.WriteLine(JsonSerializer.Serialize(e.Node.DataItem));
    }

    string Decode(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return "";
        }

        byte[] bytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(bytes);
    }
}

internal struct Course
{
    public List<Course>? Items;
    public string?       Id;
    public string?       Title;
    public string?       Text;
    public string        Key;

    public Course(string title, string text, string key)
    {
        Title = title;
        Text  = text;
        Key   = key;
    }
}

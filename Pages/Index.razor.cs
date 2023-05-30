using AntDesign;
using Microsoft.AspNetCore.Components;

namespace AirCode.Pages;

public partial class Index : ComponentBase
{
    List<Course> _courses = new()
    {
        new("第一章 JS", "0-0")
        {
            Items = new List<Course>()
            {
                new("第一节 认识JS", "0-0-0")
                {
                    Items = new List<Course>()
                    {
                        new("JS简介", "0-0-0-0"),
                        new("JS输出", "0-0-0-1"),
                        new("JS语句", "0-0-0-2"),
                    }
                },
                new("第二节 JS语法", "0-0-1")
                {
                    Items = new List<Course>()
                    {
                        new("JS 数组", "0-0-1-0"),
                        new("JS 日期", "0-0-1-1"),
                        new("JS 随机", "0-0-1-2"),
                    }
                },
                new("第三节 JS调试", "0-0-2")
                {
                    Items = new List<Course>()
                    {
                        new("JS 错误", "0-0-2-0"),
                        new("JS 性能", "0-0-2-1"),
                        new("JS 保留词", "0-0-2-2"),
                    }
                },
            }
        },
        new("第二章 JS对象", "0-1")
        {
            Items = new List<Course>()
            {
                new("JS 对象定义", "0-1-0"),
                new("JS 对象方法", "0-1-0"),
                new("JS 对象属性", "0-1-2"),
            }
        },
        new("第三章 JS函数", "0-2")
        {
            Items = new List<Course>()
            {
                new("JS 函数定义", "0-2-0"),
                new("JS 函数参数", "0-2-1"),
            }
        }
    };

    Tree<Course>? tree;
}

internal struct Course
{
    public List<Course>? Items;
    public string?       Id;
    public string        Text;
    public string        Icon;

    public Course(string text, string icon)
    {
        Text = text;
        Icon = icon;
    }
}

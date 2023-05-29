using AntDesign;
using Microsoft.AspNetCore.Components;

namespace AirCode.Pages;

public partial class Index : ComponentBase
{
    public List<BasicItem> data = new List<BasicItem>
    {
        new BasicItem { Title = "JS简介" },
        new BasicItem { Title = "JS使用" },
        new BasicItem { Title = "JS赋值" },
        new BasicItem { Title = "JS注释" },
        new BasicItem { Title = "JS变量" },
    };

    List<GameElement> games = new()
    {
        new("第一章 JS", "0-0")
        {
            Items = new List<GameElement>()
            {
                new("第一节 认识JS", "0-0-0")
                {
                    Items = new List<GameElement>()
                    {
                        new("JS简介", "0-0-0-0"),
                        new("JS输出", "0-0-0-1"),
                        new("JS语句", "0-0-0-2"),
                    }
                },
                new("第二节 JS语法", "0-0-1")
                {
                    Items = new List<GameElement>()
                    {
                        new("JS 数组", "0-0-1-0"),
                        new("JS 日期", "0-0-1-1"),
                        new("JS 随机", "0-0-1-2"),
                    }
                },
                new("第三节 JS调试", "0-0-2")
                {
                    Items = new List<GameElement>()
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
            Items = new List<GameElement>()
            {
                new("JS 对象定义", "0-1-0"),
                new("JS 对象方法", "0-1-0"),
                new("JS 对象属性", "0-1-2"),
            }
        },
        new("第三章 JS函数", "0-2")
        {
            Items = new List<GameElement>()
            {
                new("JS 函数定义", "0-2-0"),
                new("JS 函数参数", "0-2-1"),
            }
        }
    };

    Tree<GameElement> tree;

    public void ItemClick(string title)
    {
        Console.WriteLine($"item was clicked: {title}");
    }

    public class BasicItem
    {
        public string Title { get; set; }
    }
}

internal struct GameElement
{
    public List<GameElement> Items;
    public string            Id;
    public string            Text;
    public string            Icon;

    public GameElement(string text, string icon)
    {
        Text = text;
        Icon = icon;
    }
}

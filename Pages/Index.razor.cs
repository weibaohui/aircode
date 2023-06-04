using System.Text;
using System.Text.Json;
using AntDesign;
using Microsoft.AspNetCore.Components;
using YamlDotNet.Serialization;

namespace AirCode.Pages;

public partial class Index : ComponentBase
{
    private Course _course;


    //将下面这段代码转换为yaml
    private List<Course> _courses = new();

    private string[] _selectedKeys = Array.Empty<string>();

    Tree<Course>? tree;

    protected override async Task OnInitializedAsync()
    {
        ReadCoursesFromYaml();
        await base.OnInitializedAsync();
    }


    public void ReadCoursesFromYaml()
    {
        var deserializer = new DeserializerBuilder().Build();
        var yaml         = File.ReadAllText("course.yaml");
        _courses = deserializer.Deserialize<List<Course>>(yaml);
    }


    public void ToYaml()
    {
        var serializer = new SerializerBuilder().Build();
        var yaml       = serializer.Serialize(_courses);
        Console.WriteLine(yaml);
    }

    void OnCourseClicked(TreeEventArgs<Course> e)
    {
        _course       = e.Node.DataItem;
        _selectedKeys = new[] { $"{_course.Key}" };
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
            return string.Empty;
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

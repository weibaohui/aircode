using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;

namespace AirCode;

public partial class BasicLayout : LayoutComponentBase
{
    public MenuDataItem[]? MenuData;

    protected override async Task OnInitializedAsync()
    {
        MenuData = new MenuDataItem[]
        {
            new MenuDataItem
            {
                Path = "/counter",
                Name = "Counter",
                Key  = "Counter",
                Icon = "smile",
            },
            new MenuDataItem
            {
                Path = "/",
                Name = "试一试",
                Key  = "LessonIndex",
                Icon = "smile",
            }
        };
        await base.OnInitializedAsync();
    }
}
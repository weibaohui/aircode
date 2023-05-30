using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;

namespace AirCode;

public partial class BasicLayout : LayoutComponentBase
{
    private MenuDataItem[]? _menuData;

    protected override async Task OnInitializedAsync()
    {
        _menuData = new MenuDataItem[]
        {
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

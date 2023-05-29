using Microsoft.AspNetCore.Components;

namespace AirCode.Pages;

public partial class Counter : ComponentBase
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount += 1;
    }
}

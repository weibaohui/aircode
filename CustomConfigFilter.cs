using Yarp.ReverseProxy.Configuration;

namespace AirCode;

public class CustomConfigFilter : IProxyConfigFilter
{
    public ValueTask<ClusterConfig> ConfigureClusterAsync(ClusterConfig cluster, CancellationToken cancel)
    {
        //
        // "route1": {
        //     "ClusterId": "cluster1",
        //     "Match": {
        //         "Path": "{**catch-all}"
        //     }
        // }


        return new ValueTask<ClusterConfig>(cluster);
    }

    public ValueTask<RouteConfig> ConfigureRouteAsync(RouteConfig route, ClusterConfig? cluster,
        CancellationToken                                         cancel)
    {
        // "route1": {
        //     "ClusterId": "cluster1",
        //     "Match": {
        //         "Path": "{**catch-all}"
        //     }
        // }


        return new ValueTask<RouteConfig>(route);
    }
}

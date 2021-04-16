namespace ModelFactory
{
    public interface ICoreTechContext
    {
        IApplicationContext App { get; }

        INetworkReachability NetworkReachability { get; }

        IPermissionsService Permissions { get; }

        IAnalyticsEventService AnalyticsEvents { get; }

        
    }

    public interface IAnalyticsEventService
    {
    }

    public interface IPermissionsService
    {
    }

    public interface INetworkReachability
    {
    }

    public interface IApplicationContext
    {
    }

    
}
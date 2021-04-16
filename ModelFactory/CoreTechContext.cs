namespace ModelFactory
{
    class CoreTechContext : ICoreTechContext
    {
        public IApplicationContext App { get; }
        public INetworkReachability NetworkReachability { get; }
        public IPermissionsService Permissions { get; }
        public IAnalyticsEventService AnalyticsEvents { get; }
    }
}
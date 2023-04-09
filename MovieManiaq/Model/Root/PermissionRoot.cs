namespace MovieManiaq.Model.Root
{
    public class PermissionRoot
    {
        public PermissionRoot()
        {
            
        }

        public static async Task RequestPermission()
        {
            var statusStorageRead = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (statusStorageRead != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            var statusStorageWrite = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

            if (statusStorageWrite != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            var statusLocation = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (statusLocation != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
        }
    }
}

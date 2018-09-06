using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace RealmTest.Core.Services.Backgrounds
{
    public class BackgroundHelper
    {
        public static async Task RegisterBackgroundServices()
        {
            var req = await BackgroundExecutionManager.RequestAccessAsync();
            if (req != BackgroundAccessStatus.DeniedByUser && req != BackgroundAccessStatus.DeniedBySystemPolicy)
            {
                if (!BackgroundTaskRegistration.AllTasks.Where(x => x.Value.Name == "QuickAction").Any())
                {
                    var LiveTileTask = new BackgroundTaskBuilder
                    {
                        Name = "QuickAction",
                        TaskEntryPoint = "RealmTest.Services.Background.QuickAction",
                        CancelOnConditionLoss = false
                    };
                    LiveTileTask.SetTrigger(new TimeTrigger(15, false));
                    var LiveTileTaskRegistration = LiveTileTask.Register();
                }
            }
        }
        public static void DeleteBackgroundServices()
        {
            var list = BackgroundTaskRegistration.AllTasks.Where(x => x.Value.Name == "QuickAction");
            foreach (var item in list)
                item.Value.Unregister(true);
        }
    }
}

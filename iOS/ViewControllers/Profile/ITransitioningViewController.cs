using System;
using System.Threading.Tasks;

namespace hyperios.iOS.ViewControllers.Profile
{
    public interface ITransitioningViewController
    {
        TaskCompletionSource<bool> ViewChanging { get; set; }
    }
}

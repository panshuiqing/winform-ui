using System;
using System.Windows;
using System.Threading;

namespace Tlw.ZPG.Infrastructure.Events
{
    /// <summary>
    /// Wraps the Application Dispatcher.
    /// </summary>
    public class DefaultDispatcher : IDispatcherFacade
    {
        private SynchronizationContext synchronizationContext;

        public DefaultDispatcher(SynchronizationContext synchronizationContext)
        {
            this.synchronizationContext = synchronizationContext;
        }
        /// <summary>
        /// Forwards the BeginInvoke to the current application's <see cref="Dispatcher"/>.
        /// </summary>
        /// <param name="method">Method to be invoked.</param>
        /// <param name="arg">Arguments to pass to the invoked method.</param>
        public void BeginInvoke(Delegate method, object arg)
        {
            synchronizationContext.Send((o) => { method.DynamicInvoke(o); }, arg);
        }
    }
}
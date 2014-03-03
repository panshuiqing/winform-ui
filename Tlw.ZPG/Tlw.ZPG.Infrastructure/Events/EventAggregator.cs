using System;
using System.Collections.Generic;

namespace Tlw.ZPG.Infrastructure.Events
{
    /// <summary>
    /// Implements <see cref="IEventAggregator"/>.
    /// </summary>
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, EventBase> events = new Dictionary<Type, EventBase>();

        /// <summary>
        /// Gets the single instance of the event managed by this EventAggregator. Multiple calls to this method with the same <typeparamref name="TEventType"/> returns the same event instance.
        /// </summary>
        /// <typeparam name="TEventType">The type of event to get. This must inherit from <see cref="EventBase"/>.</typeparam>
        /// <returns>A singleton instance of an event object of type <typeparamref name="TEventType"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            EventBase existingEvent = null;

            if (!this.events.TryGetValue(typeof(TEventType), out existingEvent))
            {
                TEventType newEvent = new TEventType();
                this.events[typeof(TEventType)] = newEvent;

                return newEvent;
            }
            else
            {
                return (TEventType)existingEvent;
            }
        }
    }
}

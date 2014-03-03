
namespace Tlw.ZPG.Infrastructure.Events
{
    /// <summary>
    /// Specifies on which thread a <see cref="CompositePresentationEvent{TPayload}"/> subscriber will be called.
    /// </summary>
    public enum ThreadOption
    {
        /// <summary>
        /// The call is done on the same thread on which the <see cref="CompositePresentationEvent{TPayload}"/> was published.
        /// </summary>
        PublisherThread,

        /// <summary>
        /// The call is done on the UI thread.
        /// </summary>
        UIThread,

        /// <summary>
        /// The call is done asynchronously on a background thread.
        /// </summary>
        BackgroundThread
    }
}
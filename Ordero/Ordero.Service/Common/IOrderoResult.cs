using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    /// <summary>
    /// Ordero result interface
    /// </summary>
    public interface IOrderoResult
    {
        /// <summary>
        /// Gets a value indicating whether request has been completed successfully
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        void AddError(string error);

        /// <summary>
        /// Errors
        /// </summary>
        IList<string> Errors { get; }
    }
}

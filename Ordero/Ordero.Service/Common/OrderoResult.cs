using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordero.Service
{
    /// <summary>
    /// Ordero result
    /// </summary>
    public class OrderoResult : IOrderoResult
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OrderoResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// Gets a value indicating whether request has been completed successfully
        /// </summary>
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        /// <summary>
        /// Errors
        /// </summary>
        public IList<string> Errors { get; private set; }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}

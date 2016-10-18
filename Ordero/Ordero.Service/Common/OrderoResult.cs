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
        /// Gets a value indicating whether request has been completed successfully
        /// </summary>
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        public IList<string> Errors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddError(string error)
        {
            throw new NotImplementedException();
        }
    }
}

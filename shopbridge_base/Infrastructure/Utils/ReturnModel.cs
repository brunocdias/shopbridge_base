using System.Collections.Generic;
using System.Linq;

namespace Shopbridge_base.Infrastructure.Utils
{
    public class ReturnModel<T>
    {
        public bool Success { get; set; }
        public T Return { get; set; }
        public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<string> SuccessList { get; set; } = Enumerable.Empty<string>();
    }
}

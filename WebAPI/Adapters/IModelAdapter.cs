using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Adapters
{
    interface IModelAdapter<T,F>
    {
        T AdaptTo(F fromInstance);

        F AdaptTo(T fromInstance);

        IEnumerable<T> AdaptAll(IEnumerable<F> fromList);

        IEnumerable<F> AdaptAll(IEnumerable<T> fromList);
    }
}

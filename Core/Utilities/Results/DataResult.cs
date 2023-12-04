using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T Data,bool success,string message ):base(success,message)
        {
            this.Data = Data;
        }

        public DataResult(T Data,bool success):base(success)
        {
            this.Data= Data;
        }

        public T Data { get; }

    }
}

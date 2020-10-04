using System;

namespace Util.Logging {

    public interface ILogBook {
        void WriteEntry(string message);

        void WriteEntry(Exception e);
    }

}



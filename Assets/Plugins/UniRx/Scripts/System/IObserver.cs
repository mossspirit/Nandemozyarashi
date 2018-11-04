<<<<<<< HEAD
﻿// defined from .NET Framework 4.0 and NETFX_CORE

#if !(NETFX_CORE || NET_4_6 || NET_STANDARD_2_0 || UNITY_WSA_10_0)

using System;

namespace UniRx
{
    public interface IObserver<T>
    {
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(T value);
    }
}

=======
﻿// defined from .NET Framework 4.0 and NETFX_CORE

#if !(NETFX_CORE || NET_4_6)

using System;

namespace UniRx
{
    public interface IObserver<T>
    {
        void OnCompleted();
        void OnError(Exception error);
        void OnNext(T value);
    }
}

>>>>>>> c82f9d2c57929125d03fd2866298ec0a17415fc4
#endif
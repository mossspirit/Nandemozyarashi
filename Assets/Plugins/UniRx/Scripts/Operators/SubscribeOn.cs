<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace UniRx.Operators
{
    internal class SubscribeOnObservable<T> : OperatorObservableBase<T>
    {
        readonly IObservable<T> source;
        readonly IScheduler scheduler;

        public SubscribeOnObservable(IObservable<T> source, IScheduler scheduler)
            : base(scheduler == Scheduler.CurrentThread || source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
            this.scheduler = scheduler;
        }

        protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
        {
            var m = new SingleAssignmentDisposable();
            var d = new SerialDisposable();
            d.Disposable = m;

            m.Disposable = scheduler.Schedule(() =>
            {
                d.Disposable = new ScheduledDisposable(scheduler, source.Subscribe(observer));
            });

            return d;
        }
    }
=======
﻿using System;
using System.Collections.Generic;

namespace UniRx.Operators
{
    internal class SubscribeOnObservable<T> : OperatorObservableBase<T>
    {
        readonly IObservable<T> source;
        readonly IScheduler scheduler;

        public SubscribeOnObservable(IObservable<T> source, IScheduler scheduler)
            : base(scheduler == Scheduler.CurrentThread || source.IsRequiredSubscribeOnCurrentThread())
        {
            this.source = source;
            this.scheduler = scheduler;
        }

        protected override IDisposable SubscribeCore(IObserver<T> observer, IDisposable cancel)
        {
            var m = new SingleAssignmentDisposable();
            var d = new SerialDisposable();
            d.Disposable = m;

            m.Disposable = scheduler.Schedule(() =>
            {
                d.Disposable = new ScheduledDisposable(scheduler, source.Subscribe(observer));
            });

            return d;
        }
    }
>>>>>>> c82f9d2c57929125d03fd2866298ec0a17415fc4
}
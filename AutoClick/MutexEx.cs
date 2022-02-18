using System;
using System.Threading;

namespace AutoClick
{
    /// <summary>
    /// Disposeで解放出来るようにしたラッパークラスです。
    /// </summary>
    public class MutexEx : IDisposable
    {
        /// <summary>
        /// ミューテックス名称を取得します。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// ミューテックスが取得出来たかどうかを取得します。
        /// </summary>
        public bool HasMutex { get; private set; }

        /// <summary>
        /// ミューテックスオブジェクト。
        /// </summary>
        private Mutex Mutex { get; set; }

        /// <summary>
        /// 名称を指定して<see cref="MutexEx"/>インスタンスを初期化します。
        /// </summary>
        /// <param name="name"></param>
        public MutexEx(string name)
        {
            Name = name;
            Mutex = new Mutex(false, Name);

            try
            {
                HasMutex = Mutex.WaitOne(0, false);
            }
            catch (AbandonedMutexException)
            {
                HasMutex = true;
            }
        }

        #region IDisposable
        private bool disposedValue = false;

        /// <summary>
        /// リソースを破棄します。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (HasMutex)
                {
                    Mutex?.ReleaseMutex();
                }
                Mutex?.Dispose();
                Mutex = null;

                disposedValue = true;
            }
        }

        /// <summary>
        /// デストラクタ。
        /// </summary>
        ~MutexEx()
        {
            Dispose(false);
        }

        /// <summary>
        /// リソースを破棄します。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
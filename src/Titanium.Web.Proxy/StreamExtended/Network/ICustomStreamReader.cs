﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Titanium.Web.Proxy.StreamExtended.Network
{
    /// <summary>
    ///     This concrete implemetation of interface acts as the source stream for CopyStream class.
    /// </summary>
    public interface ICustomStreamReader
    {
        int Available { get; }

        bool DataAvailable { get; }

        /// <summary>
        /// Fills the buffer asynchronous.
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> FillBufferAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Peeks a byte from buffer.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Index is out of buffer size</exception>
        byte PeekByteFromBuffer(int index);

        /// <summary>
        /// Peeks a byte asynchronous.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<int> PeekByteAsync(int index, CancellationToken cancellationToken = default);

        /// <summary>
        /// Peeks bytes asynchronous.
        /// </summary>
        /// <param name="buffer">The buffer to copy.</param>
        /// <param name="offset">The offset where copying.</param>
        /// <param name="index">The index.</param>
        /// <param name="count">The count.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<int> PeekBytesAsync(byte[] buffer, int offset, int index, int count, CancellationToken cancellationToken = default);

        byte ReadByteFromBuffer();

        /// <summary>
        /// When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="offset" /> and (<paramref name="offset" /> + <paramref name="count" /> - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer" /> at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// Read the specified number (or less) of raw bytes from the base stream to the given buffer to the specified offset
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="bytesToRead"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The number of bytes read</returns>
        Task<int> ReadAsync(byte[] buffer, int offset, int bytesToRead, CancellationToken cancellationToken = default);

        /// <summary>
        /// Read the specified number (or less) of raw bytes from the base stream to the given buffer to the specified offset
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The number of bytes read</returns>
        ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default);

        /// <summary>
        /// Read a line from the byte stream
        /// </summary>
        /// <returns></returns>
        ValueTask<string?> ReadLineAsync(CancellationToken cancellationToken = default);
    }
}

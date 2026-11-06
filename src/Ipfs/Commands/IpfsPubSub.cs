using System;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using Ipfs;
using Ipfs.Json;

namespace Ipfs.Commands
{
    public class IpfsPubSub : IpfsCommand
    {
        internal IpfsPubSub(Uri commandUri, HttpClient httpClient, IJsonSerializer jsonSerializer)
            : base(commandUri, httpClient, jsonSerializer)
        {
        }

        /// <summary>
        /// Show peers in the bootstrap list
        /// Peers are output in the format '[multiaddr]/[peerID]'.
        /// </summary>
        /// <param name="cancellationToken">Token allowing you to cancel the request</param>
        /// <returns></returns>
        public async Task<HttpContent> State(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecutePostAsync("state", cancellationToken);
        }
    }
}

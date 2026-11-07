using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Ipfs.Json;

namespace Ipfs.Commands
{
    /// <summary>
    /// Name service PubSub subsystem (IPNS)
    /// 
    /// Calls to functions /api/v0/name/pubsub/[SubCommandName]
    /// </summary>
    public class IpfsNamePubSub : IpfsCommand
    {
        internal IpfsNamePubSub(Uri commandUri, HttpClient httpClient, IJsonSerializer jsonSerializer)
            : base(commandUri, httpClient, jsonSerializer)
        {
        }

        /// <summary>
        /// Query the state of IPNS pubsub.
        /// 
        /// curl -X POST "http://127.0.0.1:5001/api/v0/name/pubsub/state"
        /// 
        /// https://docs.ipfs.tech/reference/kubo/rpc/#api-v0-name-pubsub-state
        /// </summary>
        /// <param name="cancellationToken">Token allowing you to cancel the request</param>
        /// <returns></returns>
        public async Task<HttpContent> State(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecutePostAsync("state", cancellationToken);
        }
    }
}

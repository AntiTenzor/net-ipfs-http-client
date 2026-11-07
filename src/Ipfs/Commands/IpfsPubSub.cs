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
    /// <summary>
    /// Actual PubSub (ls, peers, pub, sub, reset)
    /// </summary>
    public class IpfsPubSub : IpfsCommand
    {
        internal IpfsPubSub(Uri commandUri, HttpClient httpClient, IJsonSerializer jsonSerializer)
            : base(commandUri, httpClient, jsonSerializer)
        {
        }

        /// <summary>
        /// List subscribed topics by name.
        /// Topics are output as the array of strings in some unclear encoding
        /// (multibase encoded???).
        /// 
        /// curl -X POST "http://127.0.0.1:5001/api/v0/pubsub/ls"
        /// 
        /// https://docs.ipfs.tech/reference/kubo/rpc/#api-v0-pubsub-ls
        /// </summary>
        /// <param name="cancellationToken">Token allowing you to cancel the request</param>
        /// <returns></returns>
        public async Task<HttpContent> Ls(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecutePostAsync("ls", cancellationToken);
        }

        /// <summary>
        /// List peers we are currently pubsubbing with.
        /// Peers are output as the array of strings with PeerID(s).
        /// 
        /// curl -X POST "http://127.0.0.1:5001/api/v0/pubsub/peers?arg=[topic]"
        /// 
        /// https://docs.ipfs.tech/reference/kubo/rpc/#api-v0-pubsub-peers
        /// </summary>
        /// <param name="arg">Topic to list connected peers of. Required: no</param>
        /// <param name="cancellationToken">Token allowing you to cancel the request</param>
        /// <returns></returns>
        public async Task<HttpContent> Peers(string arg = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await ExecutePostAsync("peers", arg, cancellationToken);
        }

        /// <summary>
        /// Publish data to a given pubsub topic.
        /// Peers are output as the array of strings with PeerID(s).
        /// 
        /// curl -X POST "http://127.0.0.1:5001/api/v0/pubsub/peers?arg=[topic]"
        /// 
        /// https://docs.ipfs.tech/reference/kubo/rpc/#api-v0-pubsub-pub
        /// </summary>
        /// <param name="topic">Topic to publish to (multibase encoded when sent over HTTP RPC). Required: yes</param>
        /// <param name="cancellationToken">Token allowing you to cancel the request</param>
        /// <returns></returns>
        public async Task<HttpContent> Pub(string topic, byte[] message, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (String.IsNullOrWhiteSpace(topic))
                throw new ArgumentNullException(nameof(topic));

            return await ExecutePostAsync("pub", topic, cancellationToken);
        }
    }
}

using System;

namespace Ipfs.Json
{
    /// <summary>
    /// Information about version of the IPFS node
    /// </summary>
    public class IpfsVersion
    {
        public string Version { get; set; }

        public string Commit { get; set; }

        public string Repo { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            string res = "Ver:" + (this.Version ?? "NULL") + "; " +
                "Repo:" + (this.Repo ?? "NULL") + "; " +
                "Commit:" + (this.Commit ?? "NULL");
            return res;
        }
    }
}

// ---------------------------------------------------------------------------
// Copyright (c) Hassan Habib & Shri Humrudha Jagathisun All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------------------

using YamlDotNet.Serialization;

namespace ADotNet.Models.Pipelines.GithubPipelines.DotNets
{
    // more here
    // https://ashishb.net/tech/common-pitfalls-of-github-actions/
    public class Concurrency
    {
        public string Group { get; set; } = "${{ github.workflow }}-${{ github.ref }}";

        [YamlMember(Alias = "cancel-in-progress")]
        public bool CancelInProgress { get; set; } = true;
    }
}

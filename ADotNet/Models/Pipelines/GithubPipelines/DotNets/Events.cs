// ---------------------------------------------------------------------------
// Copyright (c) Hassan Habib & Shri Humrudha Jagathisun All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------------------

using YamlDotNet.Serialization;

namespace ADotNet.Models.Pipelines.GithubPipelines.DotNets
{
    public class Events
    {
        [YamlMember(Description = "the workflow will be triggered when you push to this branch")]
        public PushEvent Push { get; set; }

        [YamlMember(Alias = "pull_request", Description = "the workflow will be triggered when you make a PR to this branch")]
        public PullRequestEvent PullRequest { get; set; }
    }
}

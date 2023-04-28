// ---------------------------------------------------------------------------
// Copyright (c) Hassan Habib & Shri Humrudha Jagathisun All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------------------

using System;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace ADotNet.Models.Pipelines.GithubPipelines.DotNets
{
    public class TriggerEvent
    {
        [YamlMember(ScalarStyle = ScalarStyle.Folded, Description = "Actions towards those branches will trigger the workflow")]
        public string[] Branches { get; set; } = Array.Empty<string>();

        [YamlMember(
            ScalarStyle = ScalarStyle.Folded,
            DefaultValuesHandling = DefaultValuesHandling.OmitEmptyCollections,
            Description = "Which files should trigger the workflow")]
        public string[] Paths { get; set; } = Array.Empty<string>();
    }
}

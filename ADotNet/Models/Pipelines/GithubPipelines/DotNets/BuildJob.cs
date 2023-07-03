// ---------------------------------------------------------------------------
// Copyright (c) Hassan Habib & Shri Humrudha Jagathisun All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using YamlDotNet.Serialization;

namespace ADotNet.Models.Pipelines.GithubPipelines.DotNets
{
    public class BaseJob
    {
        [YamlMember(Alias = "name", Description = "name of the job, it is used as label in other places")]
        public string Name { get; set; }

        [YamlMember(Alias = "runs-on", Description = "server tags")]
        public IEnumerable<string> RunsOn { get; set; }

        [DefaultValue(0)]
        [YamlMember(Alias = "timeout-minutes", DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        public int TimeoutInMinutes { get; set; }

        [YamlMember(Alias = "env", DefaultValuesHandling = DefaultValuesHandling.OmitDefaults)]
        public Dictionary<string, string> EnvironmentVariables { get; set; }

        public List<GithubTask> Steps { get; set; }
    }

    public class BuildJob : BaseJob { }

    public class TestJob : BaseJob
    {
        [YamlMember(Alias = "needs", DefaultValuesHandling = DefaultValuesHandling.OmitNull, Description = "Declares which jobs have to be ready before this one")]
        public string Needs { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace KubeClient.Models
{
    /// <summary>
    ///     CronJob represents the configuration of a single cron job.
    /// </summary>
    [KubeObject("CronJob", "v2alpha1")]
    [KubeApi("apis/batch/v2alpha1/namespaces/{namespace}/cronjobs", KubeAction.Create, KubeAction.DeleteCollection, KubeAction.List)]
    [KubeApi("apis/batch/v2alpha1/namespaces/{namespace}/cronjobs/{name}", KubeAction.Delete)]
    [KubeApi("apis/batch/v2alpha1/namespaces/{namespace}/cronjobs/{name}/status", KubeAction.Get, KubeAction.Patch, KubeAction.Update)]
    [KubeApi("apis/batch/v2alpha1/watch/namespaces/{namespace}/cronjobs", KubeAction.WatchList)]
    [KubeApi("apis/batch/v2alpha1/watch/namespaces/{namespace}/cronjobs/{name}", KubeAction.Watch)]
    public partial class CronJobV2Alpha1 : KubeResourceV1
    {
        /// <summary>
        ///     Specification of the desired behavior of a cron job, including the schedule. More info: https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status
        /// </summary>
        [JsonProperty("spec")]
        [YamlMember(Alias = "spec")]
        public CronJobSpecV2Alpha1 Spec { get; set; }

        /// <summary>
        ///     Current status of a cron job. More info: https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status
        /// </summary>
        [JsonProperty("status")]
        [YamlMember(Alias = "status")]
        public CronJobStatusV2Alpha1 Status { get; set; }
    }
}

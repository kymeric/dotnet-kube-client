using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace KubeClient.Models
{
    /// <summary>
    ///     Scale represents a scaling request for a resource.
    /// </summary>
    [KubeObject("Scale", "v1beta1")]
    [KubeApi("apis/apps/v1beta1/namespaces/{namespace}/deployments/{name}/scale", KubeAction.Get, KubeAction.Patch, KubeAction.Update)]
    public partial class ScaleV1Beta1 : KubeResourceV1
    {
        /// <summary>
        ///     defines the behavior of the scale. More info: https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status.
        /// </summary>
        [JsonProperty("spec")]
        [YamlMember(Alias = "spec")]
        public ScaleSpecV1Beta1 Spec { get; set; }

        /// <summary>
        ///     current status of the scale. More info: https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status. Read-only.
        /// </summary>
        [JsonProperty("status")]
        [YamlMember(Alias = "status")]
        public ScaleStatusV1Beta1 Status { get; set; }
    }
}

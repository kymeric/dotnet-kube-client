using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace KubeClient.Models
{
    /// <summary>
    ///     ClusterRoleBinding references a ClusterRole, but not contain it.  It can reference a ClusterRole in the global namespace, and adds who information via Subject.
    /// </summary>
    [KubeObject("ClusterRoleBinding", "v1beta1")]
    [KubeApi("apis/rbac.authorization.k8s.io/v1beta1/clusterrolebindings", KubeAction.Create, KubeAction.DeleteCollection, KubeAction.List)]
    [KubeApi("apis/rbac.authorization.k8s.io/v1beta1/clusterrolebindings/{name}", KubeAction.Delete, KubeAction.Get, KubeAction.Patch, KubeAction.Update)]
    [KubeApi("apis/rbac.authorization.k8s.io/v1beta1/watch/clusterrolebindings", KubeAction.WatchList)]
    [KubeApi("apis/rbac.authorization.k8s.io/v1beta1/watch/clusterrolebindings/{name}", KubeAction.Watch)]
    public partial class ClusterRoleBindingV1Beta1 : KubeResourceV1
    {
        /// <summary>
        ///     RoleRef can only reference a ClusterRole in the global namespace. If the RoleRef cannot be resolved, the Authorizer must return an error.
        /// </summary>
        [JsonProperty("roleRef")]
        [YamlMember(Alias = "roleRef")]
        public RoleRefV1Beta1 RoleRef { get; set; }

        /// <summary>
        ///     Subjects holds references to the objects the role applies to.
        /// </summary>
        [YamlMember(Alias = "subjects")]
        [JsonProperty("subjects", NullValueHandling = NullValueHandling.Ignore)]
        public List<SubjectV1Beta1> Subjects { get; set; } = new List<SubjectV1Beta1>();
    }
}

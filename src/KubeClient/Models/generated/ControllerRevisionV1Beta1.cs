using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace KubeClient.Models
{
    /// <summary>
    ///     ControllerRevision implements an immutable snapshot of state data. Clients are responsible for serializing and deserializing the objects that contain their internal state. Once a ControllerRevision has been successfully created, it can not be updated. The API Server will fail validation of all requests that attempt to mutate the Data field. ControllerRevisions may, however, be deleted. Note that, due to its use by both the DaemonSet and StatefulSet controllers for update and rollback, this object is beta. However, it may be subject to name and representation changes in future releases, and clients should not depend on its stability. It is primarily for internal use by controllers.
    /// </summary>
    [KubeObject("ControllerRevision", "v1beta1")]
    [KubeApi("apis/apps/v1beta1/namespaces/{namespace}/controllerrevisions", KubeAction.Create, KubeAction.DeleteCollection, KubeAction.List)]
    [KubeApi("apis/apps/v1beta1/namespaces/{namespace}/controllerrevisions/{name}", KubeAction.Delete, KubeAction.Get, KubeAction.Patch, KubeAction.Update)]
    [KubeApi("apis/apps/v1beta1/watch/namespaces/{namespace}/controllerrevisions", KubeAction.WatchList)]
    [KubeApi("apis/apps/v1beta1/watch/namespaces/{namespace}/controllerrevisions/{name}", KubeAction.Watch)]
    public partial class ControllerRevisionV1Beta1 : KubeResourceV1
    {
        /// <summary>
        ///     Data is the serialized representation of the state.
        /// </summary>
        [JsonProperty("data")]
        [YamlMember(Alias = "data")]
        public RawExtensionRuntime Data { get; set; }

        /// <summary>
        ///     Revision indicates the revision of the state represented by Data.
        /// </summary>
        [JsonProperty("revision")]
        [YamlMember(Alias = "revision")]
        public int Revision { get; set; }
    }
}

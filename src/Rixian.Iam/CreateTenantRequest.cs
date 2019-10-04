// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Rixian.Iam
{
    using Newtonsoft.Json;

    /// <summary>
    /// Request object for creating a new tenant.
    /// </summary>
    public class CreateTenantRequest
    {
        /// <summary>
        /// Gets or sets the name of the tenant to be created.
        /// </summary>
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Grpc.Core;
using Grpc.Net.Client;

namespace Rixian.Iam.Grpc
{
    public class IamClient
    {
        private readonly GrpcChannel grpcChannel;
        private readonly Main.MainClient client;

        public IamClient(GrpcChannel grpcChannel)
        {
            this.grpcChannel = grpcChannel;
            this.client = new Main.MainClient(this.grpcChannel);
        }

        /// <summary>List Tenants.</summary>
        /// <param name="subjectId">The ID of the subject (e.g. user ID).</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        public async Task<ICollection<Tenant>> ListTenantsAsync(string subjectId = null, System.Threading.CancellationToken cancellationToken = default)
        {
            AsyncServerStreamingCall<Tenant> response = this.client.ListTenants(new ListTenantsRequest
            {
                SubjectId = subjectId,
            });

            var tenants = new List<Tenant>();
            await foreach (Tenant tenant in response.ResponseStream.ReadAllAsync())
            {
                tenants.Add(tenant);
            }

            return tenants;
        }

        ///// <summary>Create Tenant.</summary>
        ///// <param name="iamClient">The IamClient to use.</param>
        ///// <param name="request">The request body.</param>
        ///// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        ///// <returns>The raw HttpResponseMessage.</returns>
        //public static async Task<Tenant> CreateTenantAsync(this IIamClient iamClient, CreateTenantRequest request, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    if (iamClient is null)
        //    {
        //        throw new ArgumentNullException(nameof(iamClient));
        //    }

        //    Result<Tenant> result = await iamClient.CreateTenantResultAsync(request, cancellationToken).ConfigureAwait(false);

        //    if (result.IsResult)
        //    {
        //        return result.Value;
        //    }

        //    throw ApiException.Create(result.Error);
        //}

        ///// <summary>Get Tenant.</summary>
        ///// <param name="iamClient">The IamClient to use.</param>
        ///// <param name="tenantId">The ID of the requested tenant.</param>
        ///// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        ///// <returns>The raw HttpResponseMessage.</returns>
        //public static async Task<Tenant> GetTenantAsync(this IIamClient iamClient, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    if (iamClient is null)
        //    {
        //        throw new ArgumentNullException(nameof(iamClient));
        //    }

        //    Result<Tenant> result = await iamClient.GetTenantResultAsync(tenantId, cancellationToken).ConfigureAwait(false);

        //    if (result.IsResult)
        //    {
        //        return result.Value;
        //    }

        //    throw ApiException.Create(result.Error);
        //}

        ///// <summary>List Accounts.</summary>
        ///// <param name="iamClient">The IamClient to use.</param>
        ///// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        ///// <returns>The raw HttpResponseMessage.</returns>
        //public static async Task<object> ListAccountsAsync(this IIamClient iamClient, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    if (iamClient is null)
        //    {
        //        throw new ArgumentNullException(nameof(iamClient));
        //    }

        //    Result<object> result = await iamClient.ListAccountsResultAsync(cancellationToken).ConfigureAwait(false);

        //    if (result.IsResult)
        //    {
        //        return result.Value;
        //    }

        //    throw ApiException.Create(result.Error);
        //}

        ///// <summary>Check Member Users.</summary>
        ///// <param name="iamClient">The IamClient to use.</param>
        ///// <param name="request">The request body with values to check for tenant access.</param>
        ///// <param name="tenantId">The tenant ID to check access.</param>
        ///// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        ///// <returns>The raw HttpResponseMessage.</returns>
        //public static async Task<CheckTenantAccessResponse> CheckTenantAccessAsync(this IIamClient iamClient, CheckTenantAccessRequest request, Guid tenantId, System.Threading.CancellationToken cancellationToken = default)
        //{
        //    if (iamClient is null)
        //    {
        //        throw new ArgumentNullException(nameof(iamClient));
        //    }

        //    Result<CheckTenantAccessResponse> result = await iamClient.CheckTenantAccessResultAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

        //    if (result.IsResult)
        //    {
        //        return result.Value;
        //    }

        //    throw ApiException.Create(result.Error);
        //}
    }

    public static class GrpcExtensions
    {
        public static async IAsyncEnumerable<T> ReadAllAsync<T>(this IAsyncStreamReader<T> streamReader, CancellationToken cancellationToken = default)
        {
            if (streamReader == null)
            {
                throw new System.ArgumentNullException(nameof(streamReader));
            }

            while (await streamReader.MoveNext(cancellationToken).ConfigureAwait(false))
            {
                yield return streamReader.Current;
            }
        }
    }
}

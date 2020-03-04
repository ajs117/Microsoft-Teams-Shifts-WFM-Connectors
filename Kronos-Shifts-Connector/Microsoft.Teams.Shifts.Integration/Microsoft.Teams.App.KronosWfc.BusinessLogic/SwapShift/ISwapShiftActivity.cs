﻿// <copyright file="ISwapShiftActivity.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.App.KronosWfc.BusinessLogic.SwapShift
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Teams.App.KronosWfc.Models.RequestEntities.SwapShift;
    using Microsoft.Teams.App.KronosWfc.Models.ResponseEntities.SwapShift;
    using FetchApprove = Microsoft.Teams.App.KronosWfc.Models.ResponseEntities.SwapShift.FetchApprovals;
    using SubmitResponse = Microsoft.Teams.App.KronosWfc.Models.ResponseEntities.SwapShift.SubmitSwapShift;

    /// <summary>
    /// The Swap Shift Activity interface.
    /// </summary>
    public interface ISwapShiftActivity
    {
        /// <summary>
        /// Fecth time off request details for displaying history.
        /// </summary>
        /// <param name="endPointUrl">The Kronos WFC endpoint URL.</param>
        /// <param name="jSession">JSession.</param>
        /// <param name="queryDateSpan">Date range for querying kronos.</param>
        /// <param name="personNumbers">Person number who created request.</param>
        /// <param name="statusName">Status of request.</param>
        /// <returns>Request details response object.</returns>
        Task<FetchApprove.SwapShiftData.Response> GetSwapShiftRequestDetailsAsync(
           Uri endPointUrl,
           string jSession,
           string queryDateSpan,
           List<string> personNumbers,
           string statusName);

        /// <summary>
        /// The method to post a SwapShift request in a draft state.
        /// </summary>
        /// <param name="jSession">The JSession (Kronos "token").</param>
        /// <param name="swapShiftobj">The SwapShift Object.</param>
        /// <param name="kronosApiEndpoint">The Kronos API Endpoint.</param>
        /// <returns>A response that is boxed in a unit of execution.</returns>
        Task<SubmitResponse.Response> DraftSwapShiftAsync(
            string jSession,
            SwapShiftObj swapShiftobj,
            string kronosApiEndpoint);

        /// <summary>
        /// This method definition will perform the action of submitting the SwapShift.
        /// </summary>
        /// <param name="jSession">The JSession (Kronos "token").</param>
        /// <param name="personNumber">The person number.</param>
        /// <param name="reqId">The SwapShift request ID.</param>
        /// <param name="querySpan">The query date span for the swap shift request.</param>
        /// <param name="comment">The comment to apply for the submission - if there is any comment.</param>
        /// <param name="endpointUrl">The Kronos WFC API Endpoint URL.</param>
        /// <returns>A unit of execution that contains a response object.</returns>
        Task<SubmitResponse.Response> SubmitSwapShiftAsync(
            string jSession,
            string personNumber,
            string reqId,
            string querySpan,
            string comment,
            Uri endpointUrl);

        /// <summary>
        /// This method definition will submit the approval.
        /// </summary>
        /// <param name="jSession">The JSession (Kronos "token").</param>
        /// <param name="reqId">The SwapShift request ID.</param>
        /// <param name="personNumber">The Kronos person number.</param>
        /// <param name="status">The status of the SwapShift request.</param>
        /// <param name="querySpan">The query date span.</param>
        /// <param name="comment">The comment to apply, if any comment is applicable.</param>
        /// <param name="endpointUrl">The Kronos WFC API Endpoint URL.</param>
        /// <returns>A unit of execution that contains a response.</returns>
        Task<Response> SubmitApprovalAsync(
            string jSession,
            string reqId,
            string personNumber,
            string status,
            string querySpan,
            string comment,
            Uri endpointUrl);
    }
}
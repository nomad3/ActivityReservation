﻿using ActivityReservation.WechatAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeihanLi.Extensions;

namespace ActivityReservation.WechatAPI.Controllers
{
    [Area("Wechat")]
    public class WeChatBaseController : Controller
    {
        /// <summary>
        /// logger
        /// </summary>
        protected readonly ILogger Logger;

        public WeChatBaseController(ILogger logger)
        {
            Logger = logger;
        }

        internal async System.Threading.Tasks.Task<ContentResult> WechatAsync(WechatContext wechatContext)
        {
            var response = await wechatContext.GetResponseAsync();
            if (response.IsNullOrEmpty())
            {
                return Content("");
            }
            return new WechatResult(response);
        }
    }
}

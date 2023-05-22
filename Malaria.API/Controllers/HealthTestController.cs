﻿
using Common.ViewModels;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using QueryServices.HealthTest;
using Services.Queries;

namespace MalariaDataAPI
{
    [Route("api/health-check")]
    [ApiController]
    [Produces("application/json")]
    public class HealthTestController : ControllerBase
    {
        private readonly ILogger<HealthTestController> _logger;
        IHealthTestInterface _testService;

        public HealthTestController(ILogger<HealthTestController> logger, IHealthTestInterface service)
        {
            _logger = logger;
            _testService = service;
        }

        /// <summary>
        /// Basic health test to check if service is running. No db access is attempted.
        /// </summary>
        /// <returns></returns>
        [HttpGet("basic")]
        public HealthTestMessage BasicTest()
        {
            _logger.LogInformation($"Basic health test: {_testService.GetBasicHeatlthTestString().Message} - {_testService.GetBasicHeatlthTestString().Timestamp}");
            
            return new HealthTestMessage { Message = _testService.GetBasicHeatlthTestString().Message,
                Timestamp = _testService.GetBasicHeatlthTestString().Timestamp
            };
        }

        /// <summary>
        /// Health check with db access to make sure app is connected to db. It attempts to return basic information from db.
        /// </summary>
        /// <returns></returns>
        [HttpGet("db")]
        public HealthTestMessage DBTest()
        {
            HealthTestMessage testMessage = _testService.GetDbTestString();
            _logger.LogInformation(string.Format("{0} - {1}", testMessage.Message, testMessage.Timestamp));
            return testMessage;
        }

    }

}
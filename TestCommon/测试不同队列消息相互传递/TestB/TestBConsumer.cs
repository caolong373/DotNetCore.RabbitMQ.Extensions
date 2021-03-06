﻿using DotNetCore.RabbitMQ.Extensions;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCommon
{
    public class TestBConsumer : ConsumerService
    {
        public override string Queue => "test.query";

        public override string ServiceKey => nameof(TestBConsumer);

        public override bool AutoAck => false;

        public override string ConnectionKey => nameof(TestBConnection);

        private int count = 1;

        public TestBConsumer(ILogger<TestBConsumer> logger, IEnumerable<IConnectionChannelPool> connectionList) : base(logger, connectionList)
        {
        }

        public override void Received(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine($"{ServiceKey}收到testA第{count++}消息：{Encoding.UTF8.GetString(e.Body)}");
        }
    }
}

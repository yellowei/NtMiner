﻿using System;
using System.Text;

namespace NTMiner.Profile {
    public class SetCoinKernelProfilePropertyRequest : RequestBase, ISignatureRequest {
        public SetCoinKernelProfilePropertyRequest() { }
        public Guid WorkId { get; set; }
        public Guid CoinKernelId { get; set; }
        public string PropertyName { get; set; }
        public object Value { get; set; }

        public StringBuilder GetSignData() {
            StringBuilder sb = new StringBuilder();
            sb.Append(nameof(WorkId)).Append(WorkId)
                .Append(nameof(CoinKernelId)).Append(CoinKernelId)
                .Append(nameof(PropertyName)).Append(PropertyName)
                .Append(nameof(Value)).Append(Value)
                .Append(nameof(Timestamp)).Append(Timestamp.ToUlong());
            return sb;
        }
    }
}

﻿// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Xunit;

namespace Google.Cloud.VideoIntelligence.V1.Tests
{
    public class VideoAnnotationResultsTest
    {

        [Fact]
        public void ThrowOnError_NoError()
        {
            var results = new VideoAnnotationResults
            {
                ShotLabelAnnotations =
                {
                    new LabelAnnotation
                    {
                        Entity = new Entity { Description = "X" }
                    }
                }
            };
            Assert.Same(results, results.ThrowOnError());
        }

        [Fact]
        public void ThrowOnError_Error()
        {
            var results = new VideoAnnotationResults { Error = new Rpc.Status { Message = "Bang" } };
            var exception = Assert.Throws<VideoAnnotationResultsException>(() => results.ThrowOnError());
            Assert.Equal("Bang", exception.Message);
            Assert.Same(results, exception.Response);
        }

    }
}
﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using NUnit.Framework;

namespace Google.Maps.Roads
{
	[TestFixture]
	class RoadsServiceTests
	{
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			GoogleSigned.AssignAllServices(SigningHelper.GetApiKey());
		}

		[Test]
		public void EmptyPathShouldThrow()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				var request = new SnapToRoadsRequest { Path = Array.Empty<LatLng>() };
				new RoadsService().GetResponse(request);
			});
		}

		[Test]
		public void SnapToRoadWithoutInterpolationShouldReturnTheSameAmountOfPoints()
		{
			var req = new SnapToRoadsRequest
			{
				Path = new[]
				{
					new LatLng(54.327387, 18.752565),
					new LatLng(54.327731, 18.755843),
					new LatLng(54.327753, 18.759932),
					new LatLng(54.328535, 18.766938)
				},
				Interpolate = false
			};

			var response = new RoadsService().GetResponse(req);

			Assert.AreEqual(4, response.SnappedPoints.Length);
		}
	}
}
